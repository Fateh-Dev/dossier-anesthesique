using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Net.Data;
using Server.Net.Services;

namespace Server.Net.Controllers.System
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "Suivi_Dossiers_Anesthesiques")]
    public class StatController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ExternalAuthService _ExternalAuthService;

        private IWebHostEnvironment Environment { get; set; }

        public StatController(
            ApplicationDbContext context,
            ExternalAuthService externalAuthService,
            IWebHostEnvironment environment
        // [FromServices] IAbpSession abpSession
        )
        {
            _context = context;
            Environment = environment;
            _ExternalAuthService = externalAuthService;
            // this.AbpSession = abpSession;
        }
    }
}
