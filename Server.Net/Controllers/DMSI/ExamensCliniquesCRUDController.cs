using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbpCompanyName.AbpProjectName.Controllers;
using DivisionEcole;
using DivisionEcole.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Server.Net.Controllers.DMSI;

[Produces("application/json")]
[Route("api/[controller]")]
[Abp.Web.Models.DontWrapResult]
[ApiExplorerSettings(GroupName = "Suivi_Dossiers_Reanimation")]
public class ExamensCliniquesController : AbpProjectNameControllerBase
{
    private readonly DivisionEcoleDbContext _context;

    public ExamensCliniquesController(DivisionEcoleDbContext context)
    {
        _context = context;
    }

    // ✅ GET: api/ExamensCliniques (Récupérer tous les examens)
    [HttpGet("GetAllExamensCliniques")]
    public async Task<ActionResult<IEnumerable<DMSI_Examins_Cliniques>>> GetAllExamensCliniques()
    {
        return await _context.DMSI_Examins_Cliniques.Include(e => e.Dossier).ToListAsync();
    }

    // ✅ GET: api/ExamensCliniques/{id} (Récupérer un examen par ID)
    [HttpGet("GetExamenByIdDMSI_Examins_Cliniques/{id}")]
    public async Task<ActionResult<DMSI_Examins_Cliniques>> GetExamenByIdDMSI_Examins_Cliniques(
        Guid id
    )
    {
        var examen = await _context.DMSI_Examins_Cliniques.FirstOrDefaultAsync(e =>
            e.DossierId == id
        );

        if (examen == null)
        {
            return NotFound();
        }

        return examen;
    }

    // ✅ POST: api/ExamensCliniques (Créer un nouvel examen)
    [HttpPost("createExaminClinique")]
    public async Task<ActionResult<DMSI_Examins_Cliniques>> createExaminClinique(
        [FromBody] DMSI_Examins_CliniquesCreateOrUpdateDo examen
    )
    {
        if (examen.Id == null || examen.Id == Guid.Empty)
        {
            examen.Id = Guid.NewGuid();
            _context.DMSI_Examins_Cliniques.Add(ObjectMapper.Map<DMSI_Examins_Cliniques>(examen));
        }
        else
        {
            var existingDMSI_Examins = await _context.DMSI_Examins_Cliniques.FirstOrDefaultAsync(
                x => x.Id == examen.Id
            );

            if (existingDMSI_Examins != null)
            {
                _context
                    .Entry(existingDMSI_Examins)
                    .CurrentValues.SetValues(ObjectMapper.Map<DMSI_Examins_Cliniques>(examen));
            }
            else
            {
                return NotFound();
            }
        }

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // ✅ PUT: api/ExamensCliniques/{id} (Mettre à jour un examen)
    [HttpPut("updateExaminClinique/{id}")]
    public async Task<ActionResult<string>> updateExaminClinique(
        Guid id,
        [FromBody] DMSI_Examins_Cliniques examen
    )
    {
        if (id != examen.Id)
        {
            return BadRequest();
        }

        _context.Entry(examen).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ExamenExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // ✅ DELETE: api/ExamensCliniques/{id} (Supprimer un examen)
    [HttpDelete("deleteExaminClinique/{id}")]
    public async Task<ActionResult<string>> deleteExaminClinique(Guid id)
    {
        var examen = await _context.DMSI_Examins_Cliniques.FindAsync(id);
        if (examen == null)
        {
            return NotFound();
        }

        _context.DMSI_Examins_Cliniques.Remove(examen);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // 🔎 Vérifie si un examen existe dans la base de données
    private bool ExamenExists(Guid id)
    {
        return _context.DMSI_Examins_Cliniques.Any(e => e.Id == id);
    }
}
