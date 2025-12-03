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
    public partial class ConduiteController : AbpProjectNameControllerBase
    {
        private readonly DivisionEcoleDbContext _context;
        private readonly ExternalAuthService _ExternalAuthService;

        private IWebHostEnvironment Environment { get; set; }

        public ConduiteController(
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
        // GET: api/DMSI_Conduite
        [HttpGet("getConduites")]
        public async Task<ActionResult<IEnumerable<DMSI_Conduite>>> GetAllConduite()
        {
            return await _context.Set<DMSI_Conduite>().ToListAsync();
        }

        // GET: api/DMSI_Conduite/{id}
        [HttpGet("getConduite/{id}")]
        public async Task<ActionResult<DMSI_Conduite>> GetConduiteById(Guid id)
        {
            var conduite = await _context
                .Set<DMSI_Conduite>()
                .FirstOrDefaultAsync(e => e.IdDossier == id);

            if (conduite == null)
            {
                return NotFound();
            }

            return conduite;
        }

        // POST: api/DMSI_Conduite
        [HttpPost("createConduite")]
        public async Task<ActionResult<DMSI_Conduite>> CreateConduite(
            [FromBody] DMSI_ConduiteCreateOrUpdateDto conduite
        )
        {
            if (conduite.Id == null || conduite.Id == Guid.Empty)
            {
                conduite.Id = Guid.NewGuid();
                _context.DMSI_Conduites.Add(ObjectMapper.Map<DMSI_Conduite>(conduite));
            }
            else
            {
                var existingDMSI_Conduites = await _context.DMSI_Conduites.FirstOrDefaultAsync(x =>
                    x.Id == conduite.Id
                );

                if (existingDMSI_Conduites != null)
                {
                    _context
                        .Entry(existingDMSI_Conduites)
                        .CurrentValues.SetValues(ObjectMapper.Map<DMSI_Conduite>(conduite));
                }
                else
                {
                    return NotFound();
                }
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/DMSI_Conduite/{id}
        [HttpDelete("Conduite{id}")]
        public async Task<ActionResult<string>> DeleteConduite(Guid id)
        {
            var conduite = await _context.Set<DMSI_Conduite>().FindAsync(id);
            if (conduite == null)
            {
                return NotFound();
            }

            _context.Set<DMSI_Conduite>().Remove(conduite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConduiteExists(Guid id)
        {
            return _context.Set<DMSI_Conduite>().Any(e => e.Id == id);
        }
    }
}
