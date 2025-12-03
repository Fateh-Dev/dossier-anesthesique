using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
    //TODO TO BE REMOVED
    // [Abp.Authorization.AbpAuthorize()]
    public class InterventionController : AbpProjectNameControllerBase
    {
        private readonly DivisionEcoleDbContext _context;
        private readonly ExternalAuthService _ExternalAuthService;
        private IWebHostEnvironment Environment { get; set; }

        public InterventionController(
            DivisionEcoleDbContext context,
            ExternalAuthService externalAuthService,
            IWebHostEnvironment environment
        )
        {
            _context = context;
            _ExternalAuthService = externalAuthService;
            Environment = environment;
        }

        [HttpPost("Get_All_Interventions_Filter")]
        public async Task<ActionResult<PagedResultDto<Intervention>>> Get_All_Interventions_Filter(
            [FromBody] InterventionQuery query
        )
        {
            var ret = new PagedResultDto<Intervention>();

            var retquery = _context
                .Interventions.Include(e => e.Consultation)
                .ThenInclude(e => e.Patient)
                .Include(e => e.Consultation)
                .ThenInclude(e => e.Medecin)
                .AsQueryable();

            if (query.DateDebut != null)
            {
                retquery = retquery.Where(k => k.Date >= query.DateDebut);
            }
            if (query.DateFin != null)
            {
                retquery = retquery.Where(k => k.Date <= query.DateFin);
            }
            if (!String.IsNullOrEmpty(query.Nom))
            {
                retquery = retquery.Where(k =>
                    k.Consultation.Patient.Nom.ToUpper().Contains(query.Nom.ToUpper())
                    || k.Consultation.Patient.Prenom.ToUpper().Contains(query.Nom.ToUpper())
                );
            }
            if (!String.IsNullOrEmpty(query.NomMedecin))
            {
                retquery = retquery.Where(k =>
                    k.Consultation.Medecin.Nom.ToUpper().Contains(query.NomMedecin.ToUpper())
                    || k.Consultation.Medecin.Prenom.ToUpper().Contains(query.NomMedecin.ToUpper())
                );
            }
            if (!String.IsNullOrEmpty(query.Matricule))
            {
                retquery = retquery.Where(k =>
                    k.Consultation.Patient.Matricule.Contains(query.Matricule)
                );
            }
            if (!String.IsNullOrEmpty(query.TypeAnesthesie))
            {
                retquery = retquery.Where(k =>
                    k.TypeAnesthesie.ToUpper().Contains(query.TypeAnesthesie.ToUpper())
                );
            }
            if (!String.IsNullOrEmpty(query.Diagnostique))
            {
                retquery = retquery.Where(k =>
                    k.Description.ToUpper().Contains(query.Diagnostique.ToUpper())
                );
            }
            if (!String.IsNullOrEmpty(query.Asa))
            {
                retquery = retquery.Where(k => k.Asa == query.Asa);
            }
            if (!String.IsNullOrEmpty(query.Sexe))
            {
                retquery = retquery.Where(k => k.Consultation.Patient.Sexe == query.Sexe);
            }
            if (!String.IsNullOrEmpty(query.Groupage))
            {
                retquery = retquery.Where(k => k.Consultation.Patient.Groupage == query.Groupage);
            }
            if (query.Year != null)
            {
                retquery = retquery.Where(k => k.Date.Year == query.Year);
            }
            if (query.Mois != null)
            {
                retquery = retquery.Where(k => k.Date.Month == query.Mois + 1);
            }
            if (query.Urgence != null)
            {
                retquery = retquery.Where(k => k.Urgence == query.Urgence);
            }

            retquery = retquery.OrderByDescending(e => e.Date);

            if (!String.IsNullOrEmpty(query.Sorting))
            {
                var sortBy = query.Sorting.Split(" ");
                if (sortBy.Length == 2)
                {
                    switch (sortBy[0])
                    {
                        case "etat":
                        {
                            retquery = retquery.OrderByDescending(k => k.Status);
                            break;
                        }
                        case "date":
                        {
                            retquery = retquery.OrderByDescending(k => k.Date);
                            break;
                        }
                    }
                }
                else
                {
                    switch (sortBy[0])
                    {
                        case "etat":
                        {
                            retquery = retquery.OrderBy(k => k.Status);
                            break;
                        }
                        case "date":
                        {
                            retquery = retquery.OrderBy(k => k.Date);
                            break;
                        }
                    }
                }
            }

            ret.TotalCount = await retquery.CountAsync();
            var ar = await retquery.Skip(query.SkipCount).Take(query.MaxResultCount).ToArrayAsync();
            ret.Items = ar;
            return ret;
        }

        [HttpGet("Get_Intervention_ById")]
        public async Task<ActionResult<Intervention>> Get_Intervention_ById(Guid id)
        {
            Intervention intervention = await _context
                .Interventions.AsNoTracking()
                .Where(e => e.Id == id)
                .Include(o => o.ProblemesPreOperatoires)
                .Include(o => o.ActeursIntervenants)
                .Include(o => o.PostOperation)
                .Include(o => o.OperationDetails)
                .Include(o => o.ResumeOperation)
                .Include(o => o.AgentsAnesthsesiques)
                .Include(o => o.BilanInOut)
                .FirstOrDefaultAsync();

            var Consultation = _context.Consultations.FirstOrDefault(e =>
                e.Id == intervention.ConsultationId
            );

            var Medecin = _context.Medecins.FirstOrDefault(e => e.Id == Consultation.MedecinId);

            var Patient = _context.Patients.FirstOrDefault(e => e.Id == Consultation.PatientId);
            var AnteMed = _context
                .AntedecentsMedicaux.Where(e => e.PatientId == Patient.Id)
                .ToList();
            var AnteChir = _context
                .AntecedentsChirurgicaux.Where(e => e.PatientId == Patient.Id)
                .ToList();

            var Examins = _context
                .ExaminsCliniques.Where(e => e.ConsultationId == Consultation.Id)
                .ToList();
            var Consign = _context
                .ConsignesAnesthesiques.Where(e => e.ConsultationId == Consultation.Id)
                .ToList();

            Patient.AntecedentsChirurgicaux = AnteChir;
            Patient.AntecedentsMedicaux = AnteMed;

            Consultation.ExaminsCliniques = Examins;
            Consultation.ConsignesAnesthesiques = Consign;
            Consultation.Patient = Patient;
            Consultation.Medecin = Medecin;

            intervention.Consultation = Consultation;

            if (intervention == null)
                return NotFound();
            intervention.Consultation.Patient.AntecedentsMedicaux = intervention
                .Consultation.Patient.AntecedentsMedicaux.OrderBy(e => e.TypeAntecedent)
                .ToList();
            intervention.Consultation.ExaminsCliniques = intervention
                .Consultation.ExaminsCliniques.OrderBy(e => e.TypeExamin)
                .ToList();
            return Ok(intervention);
        }

        [HttpPost("PreOperation")]
        public async Task<ActionResult<Intervention>> Add_PreOperation(
            [FromBody] InterventionEntryDto intervention
        )
        {
            var inter = _context.Interventions.FirstOrDefault(o => o.Id == intervention.Id);

            inter.AutreIntubation = intervention.AutreIntubation;
            inter.Circuit = intervention.Circuit;
            inter.Description = intervention.Description;
            inter.Intubation = intervention.Intubation ?? Intubations.NonDefini;
            inter.MatChauf = intervention.MatChauf ?? false;
            inter.MonitorageAutres = intervention.MonitorageAutres;
            inter.MonitorageVoieArt = intervention.MonitorageVoieArt;
            inter.Position = intervention.Position;
            inter.Respirateur = intervention.Respirateur;
            inter.SGast = intervention.SGast ?? false;
            inter.STemp = intervention.STemp ?? false;
            inter.SVesicale = intervention.SVesicale ?? false;

            inter.ActeursIntervenants = new List<ActeurIntervenant>();
            inter.ProblemesPreOperatoires = intervention.ProblemesPreOperatoires;
            inter.BilanInOut = intervention.BilanInOut;
            foreach (var item in intervention.MedecinsIntervenants)
            {
                inter.ActeursIntervenants.Add(
                    new ActeurIntervenant()
                    {
                        MedecinId = Guid.Parse(item),
                        InterventionId = inter.Id,
                    }
                );
            }

            var der = new DeroulementOperatoire();
            der.InterventionId = inter.Id;
            der.Temps = "00:00";
            _context.DeroulementsOperatoire.Add(der);

            inter.Status = StatusIntervention.Deroulement_Operation;

            _context.Entry(inter).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(intervention);
        }

        public class RequestTime
        {
            public string Time { get; set; }
            public Guid InterventionId { get; set; }
        }

        private string CalculateEndTime(string startTime)
        {
            DateTime startDateTime = new DateTime(
                2000,
                01,
                01,
                Int32.Parse(startTime.Split(":")[0]),
                Int32.Parse(startTime.Split(":")[1]),
                00
            );
            DateTime endDateTime = startDateTime.AddHours(5);

            return (
                    endDateTime.Hour.ToString().Length == 1
                        ? "0" + endDateTime.Hour.ToString()
                        : endDateTime.Hour.ToString()
                )
                + ":"
                + (
                    endDateTime.Minute.ToString().Length == 1
                        ? "0" + endDateTime.Minute.ToString()
                        : endDateTime.Minute.ToString()
                );
        }

        private string IncrementEndTime(Intervention inter)
        {
            DateTime startDateTime = new DateTime(
                2000,
                01,
                01,
                Int32.Parse(inter.EndTime.Split(":")[0]),
                Int32.Parse(inter.EndTime.Split(":")[1]),
                00
            );
            DateTime endDateTime = startDateTime.AddHours(1);

            return (
                    endDateTime.Hour.ToString().Length == 1
                        ? "0" + endDateTime.Hour.ToString()
                        : endDateTime.Hour.ToString()
                )
                + ":"
                + (
                    endDateTime.Minute.ToString().Length == 1
                        ? "0" + endDateTime.Minute.ToString()
                        : endDateTime.Minute.ToString()
                );
        }

        [HttpGet("IncrementEndTime/{id}")]
        public async Task<ActionResult> IncrementEndTime(Guid id)
        {
            var inter = _context.Interventions.FirstOrDefault(e => e.Id == id);
            if (inter == null)
                return NotFound();

            inter.EndTime = IncrementEndTime(inter);

            _context.Entry(inter).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("DefineStartTime")]
        public async Task<ActionResult> DefineStartTime([FromBody] RequestTime item)
        {
            var inter = _context.Interventions.FirstOrDefault(e => e.Id == item.InterventionId);
            if (inter == null)
                return NotFound();

            inter.StartTime = item.Time;
            inter.EndTime = CalculateEndTime(inter.StartTime);

            _context.Entry(inter).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("PostOperation")]
        public async Task<ActionResult<PostOperationCreateDto>> Add_PostOperation(
            [FromBody] PostOperationCreateDto item
        )
        {
            PostOperation post = ObjectMapper.Map<PostOperation>(item);
            var inter = _context.Interventions.FirstOrDefault(e => e.Id == post.InterventionId);
            var postOper = _context
                .PostsOperation.Where(e => e.InterventionId == item.InterventionId)
                .ToList();
            inter.Status = StatusIntervention.Perscriptions_PostOperatoires;
            if (postOper != null)
                _context.PostsOperation.RemoveRange(postOper);
            _context.PostsOperation.Add(post);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("Resume")]
        public async Task<ActionResult<ResumeOperationCreateDto>> Add_ResumeOperation(
            [FromBody] ResumeOperationCreateDto item
        )
        {
            var inter = _context.Interventions.FirstOrDefault(e => e.Id == item.InterventionId);
            var resume = _context
                .ResumeOperation.Where(e => e.InterventionId == item.InterventionId)
                .ToList();
            inter.Status = StatusIntervention.Resume_Anesthesique;
            if (resume != null)
                _context.ResumeOperation.RemoveRange(resume);
            ResumeOperation post = ObjectMapper.Map<ResumeOperation>(item);
            _context.ResumeOperation.Add(post);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("create_Deroulement")]
        public async Task<ActionResult<DeroulementOperatoire>> create_Deroulement(
            [FromBody] DeroulementOperatoireCreateDto item
        )
        {
            var el = _context
                .DeroulementsOperatoire.Where(e =>
                    e.InterventionId == item.InterventionId && e.Temps == item.Temps
                )
                .ToList();
            if (el != null)
                _context.DeroulementsOperatoire.RemoveRange(el);
            var ag = _context
                .AgentsAnesthesiques.Where(e =>
                    e.InterventionId == item.InterventionId && e.temps == item.Temps
                )
                .ToList();
            if (ag != null)
                _context.AgentsAnesthesiques.RemoveRange(ag);
            _context.AgentsAnesthesiques.AddRange(item.AgentsAnesthesiques);
            DeroulementOperatoire post = ObjectMapper.Map<DeroulementOperatoire>(item);
            _context.DeroulementsOperatoire.Add(post);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("get_Deroulements_ById")]
        public async Task<ActionResult<List<DeroulementOperatoire>>> get_Deroulements_ById(Guid id)
        {
            var der = _context.DeroulementsOperatoire.Where(e => e.InterventionId == id).ToList();
            return Ok(der);
        }

        [HttpGet("Recover_Intervention")]
        public async Task<ActionResult<Medecin>> Recover(Guid Id)
        {
            /**
               updating
            **/
            var ev = await _context
                .Interventions.IgnoreQueryFilters()
                .Where(x => x.Id == Id && x.IsDeleted == true)
                .FirstOrDefaultAsync();
            ev.IsDeleted = false;
            var con = await _context
                .Consultations.IgnoreQueryFilters()
                .Where(x => x.Id == ev.ConsultationId && x.IsDeleted == true)
                .FirstOrDefaultAsync();
            con.IsDeleted = false;
            // var a = await _context.Personnes.Where(x => x.Id == Id).FirstOrDefaultAsync();
            // _context.Personnes.Remove(a);
            await _context.SaveChangesAsync();
            return Ok("Medecin a été reccuperé avec succes");
        }

        [HttpDelete("Delete_Intervention_ById")]
        public async Task<ActionResult<Patient>> Delete_Intervention_ById(Guid idIntervention)
        {
            Intervention intervention = _context
                .Interventions.Where(e => e.Id == idIntervention)
                .FirstOrDefault();
            if (intervention == null)
                return NotFound();
            Consultation consultation = _context
                .Consultations.Where(e => e.Id == intervention.ConsultationId)
                .FirstOrDefault();
            _context.Remove(intervention);
            _context.Remove(consultation);
            await _context.SaveChangesAsync();
            return Ok("Deleted");
        }

        [HttpPost("DownloadInterventionsList")]
        public async Task<FileStreamResult> DownloadEleveList([FromBody] InterventionQuery query)
        {
            var ret = new PagedResultDto<Intervention>();

            var retquery = _context
                .Interventions.Include(e => e.Consultation)
                .ThenInclude(e => e.Patient)
                .Include(e => e.Consultation)
                .ThenInclude(e => e.Medecin)
                .AsQueryable();

            if (query.DateDebut != null)
            {
                retquery = retquery.Where(k => k.Date >= query.DateDebut);
            }
            if (query.DateFin != null)
            {
                retquery = retquery.Where(k => k.Date <= query.DateFin);
            }
            if (!String.IsNullOrEmpty(query.Nom))
            {
                retquery = retquery.Where(k =>
                    k.Consultation.Patient.Nom.ToUpper().Contains(query.Nom.ToUpper())
                    || k.Consultation.Patient.Prenom.ToUpper().Contains(query.Nom.ToUpper())
                );
            }
            if (!String.IsNullOrEmpty(query.NomMedecin))
            {
                retquery = retquery.Where(k =>
                    k.Consultation.Medecin.Nom.ToUpper().Contains(query.NomMedecin.ToUpper())
                    || k.Consultation.Medecin.Prenom.ToUpper().Contains(query.NomMedecin.ToUpper())
                );
            }
            if (!String.IsNullOrEmpty(query.Matricule))
            {
                retquery = retquery.Where(k =>
                    k.Consultation.Patient.Matricule.Contains(query.Matricule)
                );
            }
            if (!String.IsNullOrEmpty(query.TypeAnesthesie))
            {
                retquery = retquery.Where(k =>
                    k.TypeAnesthesie.ToUpper().Contains(query.TypeAnesthesie.ToUpper())
                );
            }
            if (!String.IsNullOrEmpty(query.Diagnostique))
            {
                retquery = retquery.Where(k =>
                    k.Description.ToUpper().Contains(query.Diagnostique.ToUpper())
                );
            }
            if (!String.IsNullOrEmpty(query.Asa))
            {
                retquery = retquery.Where(k => k.Asa == query.Asa);
            }
            if (!String.IsNullOrEmpty(query.Sexe))
            {
                retquery = retquery.Where(k => k.Consultation.Patient.Sexe == query.Sexe);
            }
            if (!String.IsNullOrEmpty(query.Groupage))
            {
                retquery = retquery.Where(k => k.Consultation.Patient.Groupage == query.Groupage);
            }
            if (query.Year != null)
            {
                retquery = retquery.Where(k => k.Date.Year == query.Year);
            }
            if (query.Mois != null)
            {
                retquery = retquery.Where(k => k.Date.Month == query.Mois + 1);
            }
            if (query.Urgence != null)
            {
                retquery = retquery.Where(k => k.Urgence == query.Urgence);
            }

            retquery = retquery.OrderBy(e => e.Date);
            var ar = await retquery.Select(o => o.Id).ToArrayAsync();

            var Interventions = await _context
                .Interventions.Include(e => e.Consultation)
                .ThenInclude(e => e.Patient)
                .Include(e => e.Consultation)
                .ThenInclude(e => e.Medecin)
                .Where(o => ar.Contains(o.Id))
                .OrderBy(o => o.Date)
                .Select(o => new InterventionToExcel()
                {
                    Date = o.Date.ToShortDateString(),
                    Patient = o.Consultation.Patient.Nom + " " + o.Consultation.Patient.Prenom,
                    Matricule = o.Consultation.Patient.Matricule,
                    Sexe = o.Consultation.Patient.Sexe,
                    Groupage = o.Consultation.Patient.Groupage,
                    Medecin =
                        o.Consultation.Medecin.GradeScientifique
                        + " "
                        + o.Consultation.Medecin.Nom
                        + " "
                        + o.Consultation.Medecin.Prenom,
                    TypeAnesthesie = o.Consultation.TypeAnesthesie,
                    Asa = o.Consultation.Asa,
                    Diagnostique = o.Description,
                })
                .ToListAsync();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Interevention");
                int row = 1;
                int column = 2;
                foreach (var property in typeof(InterventionToExcel).GetProperties())
                {
                    worksheet.Cells[row, 1].Value = "N°";
                    worksheet.Cells[row, column].Value = property.Name;
                    column++;
                }
                row = 2;

                foreach (var item in Interventions)
                {
                    column = 2;
                    foreach (var property in typeof(InterventionToExcel).GetProperties())
                    {
                        worksheet.Cells[row, 1].Value = row - 1;
                        worksheet.Cells[row, column].Value = property.GetValue(item);
                        column++;
                    }
                    row++;
                }
                worksheet.Cells.AutoFitColumns();
                using (var stream = new MemoryStream())
                {
                    package.SaveAs(stream);
                    stream.Position = 0;
                    var memoryStream = new MemoryStream();
                    stream.CopyTo(memoryStream);
                    memoryStream.Position = 0;
                    return new FileStreamResult(
                        memoryStream,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                    )
                    {
                        FileDownloadName = "Interevention.xlsx",
                    };
                }
            }
        }
    }
}
