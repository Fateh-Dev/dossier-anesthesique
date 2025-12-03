using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbpCompanyName.AbpProjectName.Controllers;
using DivisionEcole.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Server.Net.Controllers.DMSI
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Abp.Web.Models.DontWrapResult]
    [ApiExplorerSettings(GroupName = "Suivi_Dossiers_Reanimation")]
    public class DMSI_Examins_ComplementairesController : AbpProjectNameControllerBase
    {
        private readonly DivisionEcoleDbContext _context;

        public DMSI_Examins_ComplementairesController(
            DivisionEcoleDbContext context,
            ExternalAuthService externalAuthService,
            IWebHostEnvironment environment
        )
        {
            _context = context;
        }

        // GET: api/DMSI_Metrics_Admission

        //****************************************************************************************************
        //****************************************************************************************************
        //****************************************************************************************************
        //****************************************************************************************************
        // ---------------------------------DMSI_Examins_Complementaires
        //****************************************************************************************************
        //****************************************************************************************************
        //****************************************************************************************************
        //****************************************************************************************************

        // GET: api/DMSI_Examins_Complementaires
        [HttpGet]
        public async Task<
            ActionResult<IEnumerable<DMSI_Examins_Complementaires>>
        > GetDMSI_Examins_Complementaires()
        {
            return await _context.DMSI_Examins_Complementaires.ToListAsync();
        }

        // GET: api/DMSI_Examins_Complementaires/5
        [HttpGet("GetDMSI_Examins_ComplementairesByID/{id}")]
        public async Task<
            ActionResult<DMSI_Examins_Complementaires>
        > GetDMSI_Examins_ComplementairesByID(Guid id)
        {
            var dmsiExaminsComplementaires =
                await _context.DMSI_Examins_Complementaires.FirstOrDefaultAsync(e =>
                    e.DossierId == id
                );

            if (dmsiExaminsComplementaires == null)
            {
                return NotFound();
            }

            return dmsiExaminsComplementaires;
        }

        // POST: api/DMSI_Examins_Complementaires
        [HttpPost("DMSI_Examins_Complementaires")]
        public async Task<ActionResult<string>> PostDMSI_Examins_Complementaires(
            [FromBody] DMSI_Examins_ComplementairesCreateDto dmsiExaminsComplementaires
        )
        {
            if (
                dmsiExaminsComplementaires.Id == null
                || dmsiExaminsComplementaires.Id == Guid.Empty
            )
            {
                dmsiExaminsComplementaires.Id = Guid.NewGuid();
                _context.DMSI_Examins_Complementaires.Add(
                    ObjectMapper.Map<DMSI_Examins_Complementaires>(dmsiExaminsComplementaires)
                );
            }
            else
            {
                var existingDMSI_Examins_Complementaires =
                    await _context.DMSI_Examins_Complementaires.FirstOrDefaultAsync(x =>
                        x.Id == dmsiExaminsComplementaires.Id
                    );

                if (existingDMSI_Examins_Complementaires != null)
                {
                    _context
                        .Entry(existingDMSI_Examins_Complementaires)
                        .CurrentValues.SetValues(
                            ObjectMapper.Map<DMSI_Examins_Complementaires>(
                                dmsiExaminsComplementaires
                            )
                        );
                }
                else
                {
                    return NotFound();
                }
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/DMSI_Examins_Complementaires/5
        [HttpDelete("DMSI_Examins_Complementaires/{id}")]
        public async Task<
            ActionResult<DMSI_Examins_Complementaires>
        > DeleteDMSI_Examins_Complementaires(Guid id)
        {
            var dmsiExaminsComplementaires = await _context.DMSI_Examins_Complementaires.FindAsync(
                id
            );
            if (dmsiExaminsComplementaires == null)
            {
                return NotFound();
            }

            _context.DMSI_Examins_Complementaires.Remove(dmsiExaminsComplementaires);
            await _context.SaveChangesAsync();

            return dmsiExaminsComplementaires;
        }

        private bool DMSI_Examins_ComplementairesExists(Guid id)
        {
            return _context.DMSI_Examins_Complementaires.Any(e => e.Id == id);
        }
    }
}
