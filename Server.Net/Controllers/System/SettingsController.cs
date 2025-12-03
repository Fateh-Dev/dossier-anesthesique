using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbpCompanyName.AbpProjectName;
using AbpCompanyName.AbpProjectName.Configuration;
using AbpCompanyName.AbpProjectName.Controllers;
using DivisionEcole.Services;
    // [Abp.Auditing.DisableAuditing]
    // TODO Add Auth
    // [Abp.Authorization.AbpAuthorize()]

    public class AppSettingsController : AbpProjectNameControllerBase
    {
        private DivisionEcoleDbContext _context;
        private readonly FakeDbContext _fakecontext;
        private readonly IConfigurationRoot _configuration;
        private readonly IServiceProvider _serviceProvider;

        private IWebHostEnvironment Environment { get; set; }

        public AppSettingsController(
            DivisionEcoleDbContext s2icontext,
            FakeDbContext fakecontext,
            UserDivisionEcoleClaimsService _service,
            IWebHostEnvironment environment,
            IServiceProvider serviceProvider
        )
        {
            _context = s2icontext;
            _fakecontext = fakecontext;
            Environment = environment;
            _serviceProvider = serviceProvider;
            _configuration = Environment.GetAppConfiguration();
        }

        [HttpGet("Get_Params_By_App")]
        public async Task<ActionResult<AppSetting>> Get(string appName)
        {
            if (appName == null)
            {
                return Ok();
            }
            // var userid = this.AbpSession.GetUserId();
            // var UserUnitesPermission = _context.UserUnitesPermissions.Where(e => e.IdUtilisateur == userid).FirstOrDefault();

            var ev = await _context
                .AppSettings.Where(x => x.AppName == appName)
                .FirstOrDefaultAsync();

            // if (UserUnitesPermission != null && UserUnitesPermission.IdsUnite != null)
            // {

            //     ev.IdUnite = UserUnitesPermission.IdsUnite[0];
            // }
            if (ev == null)
            {
                return NotFound();
            }
            return Ok(ev);
        }

        [HttpGet("LoadSettings")]
        public async Task<ActionResult<AppSetting>> LoadSettings(string appName)
        {
            if (appName == null)
            {
                return Ok();
            }
            var ev = await _context
                .AppSettings.Where(x => x.AppName == appName)
                .FirstOrDefaultAsync();

            if (ev == null)
            {
                return NotFound();
            }
            return Ok(ev);
        }

        [HttpGet("LoadLookUps")]
        public async Task<ActionResult<LookUpDataViewer>> LoadLookUps()
        {
            var val = new LookUpDataViewer();
            val._Settings = await _context
                .AppSettings.Select(e => new AppSettingsDto()
                {
                    AppName = e.AppName,
                    AnneeScolaire = e.AnneeScolaire,
                    Children = e.Children,
                    IdUnite = e.IdUnite,
                    IsFakeDb = e.IsFakeDb,
                })
                .FirstOrDefaultAsync();

            if (val._Settings == null)
                val._Settings = new AppSettingsDto() { IsFakeDb = true };

            // List<Guid> uniteChildren = val._Settings.Children.Split("|").Select(Guid.Parse).ToList();
            try
            {
                //TODO FILL LOOKUPS DEPENDS ON UNITE (params)
                val._Specialite = await _context
                    .Specialites.OrderBy(o => o.Order)
                    .AsNoTracking()
                    .Select(ev => new ModalData
                    {
                        Id = ev.Id,
                        Display = ev.Label,
                        Abreviation = ev.Abreviation,
                    })
                    .ToListAsync();
                val._Respirateurs = await _context
                    .Respirateurs.OrderBy(o => o.Order)
                    .AsNoTracking()
                    .Select(ev => new ModalData
                    {
                        Id = ev.Id,
                        Display = ev.Label,
                        Abreviation = ev.Abreviation,
                    })
                    .ToListAsync();
                val._TypeAnesthesie = await _context
                    .TypesAnesthesies.OrderBy(o => o.Order)
                    .AsNoTracking()
                    .Select(ev => new ModalData
                    {
                        Id = ev.Id,
                        Display = ev.Label,
                        Abreviation = ev.Abreviation,
                    })
                    .ToListAsync();
                val._Agents = await _context
                    .Agents.OrderBy(o => o.Order)
                    .AsNoTracking()
                    .Select(ev => new ModalData
                    {
                        Id = ev.Id,
                        Display = ev.Label,
                        Abreviation = ev.Abreviation,
                    })
                    .ToListAsync();
                val._GradesScientifiques = await _context
                    .GradesScientifiques.OrderBy(o => o.Order)
                    .AsNoTracking()
                    .Select(ev => new ModalData
                    {
                        Id = ev.Id,
                        Display = ev.Label,
                        Abreviation = ev.Abreviation,
                    })
                    .ToListAsync();

                val._Armes = await _context
                    .Armes.AsNoTracking()
                    .OrderBy(o => o.Order)
                    .Select(ev => new ModalData
                    {
                        Id = ev.Id,
                        Display = ev.Label,
                        Abreviation = ev.Abreviation,
                    })
                    .ToListAsync();
                val._Grades = await _context
                    .Grades.AsNoTracking()
                    .OrderBy(o => o.Order)
                    .Select(ev => new ModalData
                    {
                        Id = ev.Id,
                        Display = ev.Label,
                        Abreviation = ev.Abreviation,
                    })
                    .ToListAsync();
                val._Defaults = await _context
                    .Defaults.AsNoTracking()
                    .OrderBy(o => o.Profile)
                    .ThenBy(o => o.NiveauScolaire)
                    .ThenBy(o => o.TypeAeronefLabel)
                    .ThenBy(o => o.Timing)
                    .ThenBy(o => o.IdUnite)
                    .ToListAsync();
                val._ExternalServers = await _context.ExternalEntities.AsNoTracking().ToListAsync();
            }
            catch (Exception e)
            {
                return Ok(e);
            }

            val._Settings.IsFakeDb = UserDivisionEcoleAppService.isFake;
            UserDivisionEcoleAppService.lookups = val;
            return Ok(val);
        }

        [HttpGet("SetToFakeDb")]
        public async Task<ActionResult> SetIsFakeDb(bool isFake)
        {
            UserDivisionEcoleAppService.isFake = isFake;

            return Ok();
        }

        [HttpGet("isItFake")]
        public async Task<ActionResult> isItFake()
        {
            return Ok(UserDivisionEcoleAppService.isFake);
        }
    }
}
