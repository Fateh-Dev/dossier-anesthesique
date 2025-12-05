using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Net.Data;
using Server.Net.DTOs.DMSI;
using Server.Net.Models.DMSI;
using Server.Net.Services;

namespace Server.Net.Controllers.DMSI
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "Suivi_Dossiers_Reanimation")]
    public partial class ConduiteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ExternalAuthService _ExternalAuthService;
        private readonly IMapper _mapper;

        private IWebHostEnvironment Environment { get; set; }

        public ConduiteController(
            ApplicationDbContext context,
            ExternalAuthService externalAuthService,
            IWebHostEnvironment environment,
            IMapper mapper
        )
        {
            _context = context;
            _ExternalAuthService = externalAuthService;
            Environment = environment;
            _mapper = mapper;
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
                _context.DMSI_Conduites.Add(_mapper.Map<DMSI_Conduite>(conduite));
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
                        .CurrentValues.SetValues(_mapper.Map<DMSI_Conduite>(conduite));
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
