using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Runtime.Session;
using AbpCompanyName.AbpProjectName.Controllers;
using DivisionEcole.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Server.Net.Data;

namespace Server.Net.Controllers.System
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Suivi_Dossiers_Anesthesiques")]
    // TODO Check
    // [Abp.Auditing.DisableAuditing]

    // [Abp.Authorization.AbpAuthorize()]

    public class StatController : AbpProjectNameControllerBase
    {
        private readonly DivisionEcoleDbContext _context;
        private readonly ExternalAuthService _ExternalAuthService;

        private IWebHostEnvironment Environment { get; set; }

        public StatController(
            DivisionEcoleDbContext context,
            ExternalAuthService externalAuthService,
            IWebHostEnvironment environment,
            [FromServices] IAbpSession abpSession
        )
        {
            _context = context;
            Environment = environment;
            _ExternalAuthService = externalAuthService;
            this.AbpSession = abpSession;
        }
    }
}
