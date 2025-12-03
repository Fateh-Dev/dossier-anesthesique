using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AbpCompanyName.AbpProjectName.Controllers;
using DivisionEcole.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OfficeOpenXml;

namespace Server.Net.Controllers.DMSI
{
    [Produces("application/json")]
    [Route("api/DossiersReanimation")]
    [ApiExplorerSettings(GroupName = "Suivi_Dossiers_Reanimation")]
    //TODO TO BE REMOVED
    // [Abp.Authorization.AbpAuthorize()]
    public partial class ObservationController : AbpProjectNameControllerBase
    {
        private readonly DivisionEcoleDbContext _context;
        private readonly ExternalAuthService _ExternalAuthService;

        private IWebHostEnvironment Environment { get; set; }

        public ObservationController(
            DivisionEcoleDbContext context,
            ExternalAuthService externalAuthService,
            IWebHostEnvironment environment
        )
        {
            _context = context;
            _ExternalAuthService = externalAuthService;
            Environment = environment;
        }

        // Create or Update
        [HttpPost("CreateOrUpdate")]
        public async Task<ActionResult<MedicalDossier>> CreateOrUpdate(
            [FromBody] MedicalDossier request
        )
        {
            if (request == null)
            {
                return BadRequest("Request body is null.");
            }

            // Check if it's an update (ID is provided)
            if (request.Id.HasValue)
            {
                return await UpdateMedicalDossier(request);
            }
            else
            {
                return await CreateMedicalDossier(request);
            }
        }

        private async Task<ActionResult<MedicalDossier>> CreateMedicalDossier(
            MedicalDossier request
        )
        {
            // Create the parent entity (if needed)
            var p = _context.DMSI_Dossiers_Medicaux.FirstOrDefault(x => x.Id == request.Id);
            if (p == null)
                return null;
            p.AvoirCovid = request.AvoirCovid;
            p.VaccinationCovid = request.VaccinationCovid;
            p.HistoireDuMalade = request.HistoireDuMalade;

            // Add antecedents
            foreach (var antecedentInput in request.Antecedents)
            {
                _context.DMSI_Antecedents.Add(
                    new DMSI_Antecedents
                    {
                        Description = antecedentInput.Description,
                        DMSI_Dossiers_MedicauxId = request.Id.Value,
                    }
                );
            }
            // Add traitements
            foreach (var traitementInput in request.TraitementsEncours)
            {
                _context.DMSI_Traitements_Encours.Add(
                    new DMSI_Traitements_Encours
                    {
                        Description = traitementInput.Description,
                        DossierId = request.Id.Value,
                    }
                );
            }

            await _context.SaveChangesAsync();

            return Ok(MapToResponse(p));
        }

        private async Task<ActionResult> UpdateMedicalDossier(MedicalDossier request)
        {
            var dossier = await _context
                .DMSI_Dossiers_Medicaux.Include(d => d.Antecedents)
                .Include(d => d.Traitements)
                .FirstOrDefaultAsync(d => d.Id == request.Id);

            if (dossier == null)
            {
                return NotFound("Dossier non trouvé.");
            }

            // Mise à jour des champs simples
            dossier.AvoirCovid = request.AvoirCovid;
            dossier.VaccinationCovid = request.VaccinationCovid;
            dossier.HistoireDuMalade = request.HistoireDuMalade;

            // Supprimer anciens antécédents
            await _context.Entry(dossier).Collection(d => d.Antecedents).LoadAsync();
            foreach (var oldAntecedent in dossier.Antecedents.ToList())
            {
                _context.Entry(oldAntecedent).State = EntityState.Deleted;
            }

            // Ajouter les nouveaux antécédents
            dossier.Antecedents = request
                .Antecedents.Select(a => new DMSI_Antecedents
                {
                    Id = Guid.NewGuid(),
                    Description = a.Description,
                    DMSI_Dossiers_MedicauxId = dossier.Id,
                })
                .ToList();

            // Supprimer anciens traitements
            await _context.Entry(dossier).Collection(d => d.Traitements).LoadAsync();
            foreach (var oldTraitement in dossier.Traitements.ToList())
            {
                _context.Entry(oldTraitement).State = EntityState.Deleted;
            }

            // Ajouter les nouveaux traitements
            dossier.Traitements = request
                .TraitementsEncours.Select(t => new DMSI_Traitements_Encours
                {
                    Id = Guid.NewGuid(),
                    Description = t.Description,
                    DossierId = dossier.Id,
                })
                .ToList();

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Mise à jour réussie.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Conflict(
                    "Erreur de concurrence : l'entité a peut-être été supprimée ou modifiée."
                );
            }
        }

        // Retrieve
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<MedicalDossier>> GetById(Guid id)
        {
            var dossier = await _context
                .DMSI_Dossiers_Medicaux.Include(d => d.Antecedents)
                .Include(d => d.Traitements)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (dossier == null)
            {
                return NotFound("Dossier not found.");
            }

            return Ok(MapToResponse(dossier));
        }

        // Delete
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<string>> Delete(Guid id)
        {
            var dossier = await _context
                .DMSI_Dossiers_Medicaux.Include(d => d.Antecedents)
                .Include(d => d.Traitements)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (dossier == null)
            {
                return NotFound("Dossier not found.");
            }

            _context.DMSI_Dossiers_Medicaux.Remove(dossier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private MedicalDossier MapToResponse(DMSI_Dossiers_Medicaux dossier)
        {
            return new MedicalDossier
            {
                Id = dossier.Id,
                AvoirCovid = dossier.AvoirCovid,
                VaccinationCovid = dossier.VaccinationCovid,
                Antecedents = dossier.Antecedents.ToList(),
                TraitementsEncours = dossier.Traitements.ToList(),
            };
        }
    }
}
