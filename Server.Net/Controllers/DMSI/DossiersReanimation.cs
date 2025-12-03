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
    public partial class DossierReanimationController : AbpProjectNameControllerBase
    {
        private readonly DivisionEcoleDbContext _context;
        private readonly ExternalAuthService _ExternalAuthService;

        private IWebHostEnvironment Environment { get; set; }

        public DossierReanimationController(
            DivisionEcoleDbContext context,
            ExternalAuthService externalAuthService,
            IWebHostEnvironment environment
        )
        {
            _context = context;
            _ExternalAuthService = externalAuthService;
            Environment = environment;
        }

        [HttpPost("Get_All_Dossiers_Filter")]
        public async Task<ActionResult<PagedResultDto<DMSI_Dossiers_Medicaux>>> GetAllFilter(
            [FromBody] PatientQuery query
        )
        {
            var ret = new PagedResultDto<DMSI_Dossiers_Medicaux>();

            var retquery = _context.DMSI_Dossiers_Medicaux.Include(o => o.Patients).AsQueryable();

            if (!String.IsNullOrEmpty(query.Matricule))
            {
                // retquery = retquery.Where(k => k.Matricule.Contains(query.Matricule));
            }

            // retquery = retquery.OrderBy(e => e.Nom);
            ret.TotalCount = await retquery.CountAsync();
            var ar = await retquery.Skip(query.SkipCount).Take(query.MaxResultCount).ToArrayAsync();
            ret.Items = ar;
            return ret;
        }

        [HttpPost("Create_Dossier")]
        public async Task<ActionResult<string>> Create_Patient(
            [FromBody] DMSI_Dossiers_MedicauxDto item
        )
        {
            var el = ObjectMapper.Map<DMSI_Dossiers_Medicaux>(item);
            el.Id = Guid.NewGuid();
            // TODO Check If Exists In DataBase
            _context.DMSI_Dossiers_Medicaux.Add(el);
            await _context.SaveChangesAsync();

            return Ok("Success");
        }

        [HttpGet("Get_Dossier_ById/{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<DMSI_Dossiers_Medicaux>> Get_Dossier_ById(Guid id)
        {
            // TODO Check If Exists In DataBase
            var res = await _context
                .DMSI_Dossiers_Medicaux.Include(e => e.Patients)
                .Include(e => e.Medecin)
                .Include(e => e.A_Admission)
                .Include(e => e.Examins_Complementaires)
                .Include(e => e.Antecedents)
                .Include(e => e.Traitements)
                .Include(e => e.DMSI_Conduite)
                .Include(e => e.Evolutions)
                .ThenInclude(e => e.Medecin_1)
                .Include(e => e.Evolutions)
                .ThenInclude(e => e.Medecin_2)
                .Include(e => e.Examins_Cliniques)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (res == null)
            {
                return NotFound();
            }
            res.Evolutions = res.Evolutions.OrderByDescending(x => x.Date).ToList();
            return Ok(res);
        }

        [HttpDelete("Delete_Dossier/{id}")]
        public async Task<ActionResult<string>> Delete_Dossier(Guid id)
        {
            var el = await _context.DMSI_Dossiers_Medicaux.FindAsync(id);
            if (el == null)
            {
                return NotFound();
            }
            _context.DMSI_Dossiers_Medicaux.Remove(el);
            await _context.SaveChangesAsync();
            return Ok("Success");
        }
    }
}
