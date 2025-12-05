using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Net.Data;
using Server.Net.Models.DMSI;
using Server.Net.Services;

namespace Server.Net.Controllers.DMSI
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "Suivi_Dossiers_Reanimation")]
    public class DMSI_Metrics_AdmissionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ExternalAuthService _ExternalAuthService;

        private IWebHostEnvironment Environment { get; set; }

        public DMSI_Metrics_AdmissionController(
            ApplicationDbContext context,
            ExternalAuthService externalAuthService,
            IWebHostEnvironment environment
        )
        {
            _context = context;
            _ExternalAuthService = externalAuthService;
            Environment = environment;
        }

        // GET: api/DMSI_Metrics_Admission
        [HttpGet("DMSI_Metrics_Admission")]
        public async Task<
            ActionResult<IEnumerable<DMSI_Metrics_Admission>>
        > GetDMSI_Metrics_Admission()
        {
            return await _context.DMSI_Metrics_Admission.ToListAsync();
        }

        // GET: api/DMSI_Metrics_Admission/5
        [HttpGet("GetDMSI_Metrics_AdmissionByID/{id}")]
        public async Task<ActionResult<DMSI_Metrics_Admission>> GetDMSI_Metrics_AdmissionByID(
            Guid id
        )
        {
            var dmsiMetricsAdmission = await _context.DMSI_Metrics_Admission.FirstOrDefaultAsync(
                e => e.DossierId == id
            );

            if (dmsiMetricsAdmission == null)
            {
                return NotFound();
            }

            return dmsiMetricsAdmission;
        }

        // POST: api/DMSI_Metrics_Admission
        [HttpPost("DMSI_Metrics_Admission")]
        public async Task<ActionResult<string>> PostDMSI_Metrics_Admission(
            [FromBody] DMSI_Metrics_Admission dmsiMetricsAdmission
        )
        {
            if (dmsiMetricsAdmission.Id == null || dmsiMetricsAdmission.Id == Guid.Empty)
            {
                dmsiMetricsAdmission.Id = Guid.NewGuid();
                _context.DMSI_Metrics_Admission.Add(dmsiMetricsAdmission);
            }
            else
            {
                var existingDMSI_Metrics_Admission =
                    await _context.DMSI_Metrics_Admission.FirstOrDefaultAsync(x =>
                        x.Id == dmsiMetricsAdmission.Id
                    );

                if (existingDMSI_Metrics_Admission != null)
                {
                    _context
                        .Entry(existingDMSI_Metrics_Admission)
                        .CurrentValues.SetValues(dmsiMetricsAdmission);
                }
                else
                {
                    return NotFound();
                }
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // PUT: api/DMSI_Metrics_Admission/5
        [HttpPut("DMSI_Metrics_Admission/{id}")]
        public async Task<ActionResult<string>> PutDMSI_Metrics_Admission(
            Guid id,
            [FromBody] DMSI_Metrics_Admission dmsiMetricsAdmission
        )
        {
            if (id != dmsiMetricsAdmission.Id)
            {
                return BadRequest();
            }

            _context.Entry(dmsiMetricsAdmission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DMSI_Metrics_AdmissionExists(id))
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

        // DELETE: api/DMSI_Metrics_Admission/5
        [HttpDelete("DMSI_Metrics_Admission/{id}")]
        public async Task<ActionResult<DMSI_Metrics_Admission>> DeleteDMSI_Metrics_Admission(
            Guid id
        )
        {
            var dmsiMetricsAdmission = await _context.DMSI_Metrics_Admission.FindAsync(id);
            if (dmsiMetricsAdmission == null)
            {
                return NotFound();
            }

            _context.DMSI_Metrics_Admission.Remove(dmsiMetricsAdmission);
            await _context.SaveChangesAsync();

            return dmsiMetricsAdmission;
        }

        private bool DMSI_Metrics_AdmissionExists(Guid id)
        {
            return _context.DMSI_Metrics_Admission.Any(e => e.Id == id);
        }
    }
}
