using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Server.Net.Data;
using Server.Net.DTOs.Core;
using Server.Net.Models.Anesthesia;
using Server.Net.Models.Antecedents;
using Server.Net.Models.Entities;
using Server.Net.Models.Enumerations;
using Server.Net.Models.Operations;
using Server.Net.Services;

namespace Server.Net.Controllers.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ExternalAuthService _ExternalAuthService;
        private readonly IMapper _mapper;

        private IWebHostEnvironment Environment { get; set; }

        public PatientController(
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

        [HttpPost("Get_All_Patient_Filter")]
        public async Task<ActionResult<PagedResultDto<Patient>>> GetAllFilter(
            [FromBody] PatientQuery query
        )
        {
            var ret = new PagedResultDto<Patient>();

            var retquery = _context
                .Patients.Include(e => e.Consultations)
                .Include(e => e.AntecedentsChirurgicaux)
                .Include(e => e.AntecedentsMedicaux)
                .AsQueryable();

            if (!String.IsNullOrEmpty(query.Matricule))
            {
                retquery = retquery.Where(k => k.Matricule.Contains(query.Matricule));
            }
            if (!String.IsNullOrEmpty(query.Nom))
            {
                retquery = retquery.Where(k =>
                    k.Nom.ToUpper().Contains(query.Nom.ToUpper())
                    || k.Prenom.ToUpper().Contains(query.Nom.ToUpper())
                );
            }
            if (!String.IsNullOrEmpty(query.Sexe))
            {
                retquery = retquery.Where(k => k.Sexe == query.Sexe);
            }
            if (!String.IsNullOrEmpty(query.Groupage))
            {
                retquery = retquery.Where(k => k.Groupage == query.Groupage);
            }
            if (!String.IsNullOrEmpty(query.Nationnalite))
            {
                retquery = retquery.Where(k => k.Nationnalite == query.Nationnalite);
            }

            retquery = retquery.OrderBy(e => e.Nom);
            ret.TotalCount = await retquery.CountAsync();
            var ar = await retquery.Skip(query.SkipCount).Take(query.MaxResultCount).ToArrayAsync();
            ret.Items = ar;
            return ret;
        }

        [HttpPost("Create_Patient")]
        public async Task<ActionResult<string>> Create_Patient([FromBody] Patient item)
        {
            Patient patient = new Patient();
            patient = item;
            // TODO Check If Exists In DataBase
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return Ok("Success");
        }

        [HttpPut("Update_Patient")]
        public async Task<ActionResult<string>> Update_Patient([FromBody] Patient item)
        {
            Patient patient = _context
                .Patients.Include(e => e.AntecedentsMedicaux)
                .Include(e => e.AntecedentsChirurgicaux)
                .FirstOrDefault(e => e.Id == item.Id);

            // Update Attrinbutes
            patient.Nom = item.Nom;
            patient.Prenom = item.Prenom;
            patient.Matricule = item.Matricule;
            patient.GradeActuel = item.GradeActuel;
            patient.Groupage = item.Groupage;
            patient.Sexe = item.Sexe;
            patient.DateNaissance = item.DateNaissance;
            patient.NumeroTel = item.NumeroTel;

            // TODO Check If Exists In DataBase
            var antCToRemove = _context
                .AntecedentsChirurgicaux.Where(p => p.PatientId == patient.Id)
                .ToList();
            var antMToRemove = _context
                .AntecedentsMedicaux.Where(p => p.PatientId == patient.Id)
                .ToList();

            _context.AntecedentsChirurgicaux.RemoveRange(antCToRemove);
            _context.AntecedentsMedicaux.RemoveRange(antMToRemove);

            foreach (var it in item.AntecedentsChirurgicaux)
            {
                _context.AntecedentsChirurgicaux.Add(
                    new AntecedentChirurgical()
                    {
                        Id = Guid.NewGuid(),
                        PatientId = patient.Id,
                        Description = it.Description,
                    }
                );
            }
            foreach (var it in item.AntecedentsMedicaux.Where(r => r.Description != null))
            {
                _context.AntecedentsMedicaux.Add(
                    new AntecedentMedical()
                    {
                        Id = Guid.NewGuid(),
                        PatientId = patient.Id,
                        Description = it.Description,
                        TypeAntecedent = it.TypeAntecedent,
                        TypeAntecedentLabel = it.TypeAntecedentLabel,
                    }
                );
            }

            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("Success");
        }

        [HttpGet("Get_Patient_ById")]
        public async Task<ActionResult<PatientReturnDto>> Get_Patient_ById(Guid idPatient)
        {
            Patient patient = await _context
                .Patients.Where(e => e.Id == idPatient)
                .Include(o => o.AntecedentsChirurgicaux)
                .Include(o => o.Consultations)
                .ThenInclude(o => o.Medecin)
                .Include(o => o.Consultations)
                .ThenInclude(o => o.ExaminsCliniques)
                .Include(o => o.Consultations)
                .ThenInclude(o => o.ConsignesAnesthesiques)
                .Include(o => o.AntecedentsMedicaux)
                .FirstOrDefaultAsync();
            if (patient == null)
                return NotFound();
            return Ok(_mapper.Map<PatientReturnDto>(patient));
        }

        [HttpGet("Recover_Patient")]
        public async Task<ActionResult<Patient>> Recover(Guid Id)
        {
            /**
               updating
            **/
            var ev = await _context
                .Patients.IgnoreQueryFilters()
                .Where(x => x.Id == Id && x.IsDeleted == true)
                .FirstOrDefaultAsync();
            ev.IsDeleted = false;
            // var a = await _context.Personnes.Where(x => x.Id == Id).FirstOrDefaultAsync();
            // _context.Personnes.Remove(a);
            await _context.SaveChangesAsync();
            return Ok("Personne a été reccuperé avec succes");
        }

        [HttpDelete("Delete_Patient_ById")]
        public async Task<ActionResult<Patient>> Delete_Patient_ById(Guid idPatient)
        {
            Patient patient = await _context
                .Patients.Where(e => e.Id == idPatient)
                .FirstOrDefaultAsync();
            if (patient == null)
                return NotFound();
            _context.Remove(patient);
            await _context.SaveChangesAsync();
            return Ok("Deleted");
        }

        [HttpGet("Get_Medecins")]
        public async Task<ActionResult<List<Medecin>>> Get_Medecins()
        {
            var medecins = _context.Medecins.ToList();
            if (medecins == null)
                return NotFound();
            return Ok(medecins);
        }

        [HttpPost("Create_Consultation")]
        public async Task<ActionResult<Guid>> Create_Consultation([FromBody] Consultation item)
        {
            Consultation consultation = new Consultation();
            consultation = item;
            // consultation.MedecinId = Guid.Parse("8C6B0D76-1C32-4938-92C8-1325942207EE");
            // consultation.PatientId = Guid.Parse("83041749-76EC-42A7-992E-DC12764B8A56");

            Intervention intervention = new Intervention();
            intervention.ConsultationId = consultation.Id;
            // intervention.PatientId = consultation.Id;
            intervention.Date = consultation.DateInterventionPrevu;
            intervention.Status = StatusIntervention.Consultation_Created;
            intervention.Urgence = consultation.Urgence;
            intervention.TypeAnesthesie = consultation.TypeAnesthesie;
            intervention.Asa = consultation.Asa;
            intervention.StartTime = "09:00";
            intervention.EndTime = "14:00";
            // TODO Check If Date Prevu not Null
            _context.Interventions.Add(intervention);
            _context.Consultations.Add(consultation);
            _context.SaveChanges();
            var consts = _context
                .Consultations.Include(x => x.Patient)
                .Where(d => d.Id == consultation.Id)
                .FirstOrDefault();
            return Ok(consultation);
        }

        [HttpPost("Add_ExClinique_To_Consultation")]
        public async Task<ActionResult<Guid>> Add_ExClinique_To_Consultation(
            [FromBody] Consultation item
        )
        {
            Consultation cons = _context.Consultations.FirstOrDefault(e => e.Id == item.Id);
            Intervention inter = _context.Interventions.FirstOrDefault(o =>
                o.ConsultationId == item.Id
            );
            cons.Id = item.Id;
            cons.TraitementActuel = item.TraitementActuel;
            cons.TraitementAPoursuivre = item.TraitementAPoursuivre;
            cons.ConclusionExamin = item.ConclusionExamin;
            inter.Status = StatusIntervention.Examins_Cliniques;

            var Examins = _context
                .ExaminsCliniques.Where(e => e.ConsultationId == item.Id)
                .ToList();
            if (Examins != null)
                _context.ExaminsCliniques.RemoveRange(Examins);

            _context.ExaminsCliniques.AddRange(
                item.ExaminsCliniques.Where(o => o.Description != null)
            );
            _context.Entry(cons).State = EntityState.Modified;
            _context.Entry(inter).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("Add_Consign_To_Consultation")]
        public async Task<ActionResult<Guid>> Add_Consign_To_Consultation(
            [FromBody] Consultation item
        )
        {
            Consultation cons = _context.Consultations.FirstOrDefault(e => e.Id == item.Id);
            Intervention inter = _context.Interventions.FirstOrDefault(o =>
                o.ConsultationId == item.Id
            );
            cons.TypeAnesthesie = item.TypeAnesthesie;
            cons.Asa = item.Asa;
            cons.PrevisionCG = item.PrevisionCG;
            cons.PrevisionPF = item.PrevisionPF;
            cons.PrevisionPlaquette = item.PrevisionPlaquette;

            var Consigns = _context
                .ConsignesAnesthesiques.Where(e => e.ConsultationId == item.Id)
                .ToList();
            if (Consigns != null)
                _context.ConsignesAnesthesiques.RemoveRange(Consigns);

            _context.ConsignesAnesthesiques.AddRange(
                item.ConsignesAnesthesiques.Where(o => o.Description != null)
            );

            inter.Status = StatusIntervention.Consignes_Anesthesiques;
            _context.Entry(inter).State = EntityState.Modified;
            _context.Entry(cons).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("DownloadPatientsList")]
        public async Task<FileStreamResult> DownloadEleveList([FromBody] PatientQuery query)
        {
            var ret = new PagedResultDto<Patient>();
            var retquery = _context.Patients.AsQueryable();

            if (!String.IsNullOrEmpty(query.Matricule))
            {
                retquery = retquery.Where(k => k.Matricule.Contains(query.Matricule));
            }
            if (!String.IsNullOrEmpty(query.Nom))
            {
                retquery = retquery.Where(k =>
                    k.Nom.ToUpper().Contains(query.Nom.ToUpper())
                    || k.Prenom.ToUpper().Contains(query.Nom.ToUpper())
                );
            }
            if (!String.IsNullOrEmpty(query.Sexe))
            {
                retquery = retquery.Where(k => k.Sexe == query.Sexe);
            }
            if (!String.IsNullOrEmpty(query.Groupage))
            {
                retquery = retquery.Where(k => k.Groupage == query.Groupage);
            }
            if (!String.IsNullOrEmpty(query.Nationnalite))
            {
                retquery = retquery.Where(k => k.Nationnalite == query.Nationnalite);
            }

            retquery = retquery.OrderBy(e => e.Nom);
            var ar = await retquery.Select(o => o.Id).ToArrayAsync();
            var Personnes = await _context
                .Patients.Where(o => ar.Contains(o.Id))
                .OrderBy(o => o.Matricule)
                .Select(o => new PatientToExcel()
                {
                    Nom = o.Nom,
                    Prenom = o.Prenom,
                    Matricule = o.Matricule,
                    Sexe = o.Sexe,
                    Groupage = o.Groupage,
                    Nationnalite = o.Nationnalite,
                })
                .ToListAsync();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Patients");
                int row = 1;
                int column = 2;
                foreach (var property in typeof(PatientToExcel).GetProperties())
                {
                    worksheet.Cells[row, column].Value = property.Name;
                    column++;
                }
                row = 2;
                foreach (var item in Personnes)
                {
                    column = 2;
                    foreach (var property in typeof(PatientToExcel).GetProperties())
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
                        FileDownloadName = "Patients.xlsx",
                    };
                }
            }
        }

        // Api Pour load une image de profile pour un eleve et compression
        [HttpPost("uploadAvatar/{*id}")]
        public async Task<ActionResult> UploadAvatar([FromRoute] Guid id, IFormFile file)
        {
            var personne = await _context.Patients.Where(e => e.Id == id).FirstOrDefaultAsync();
            if (personne == null)
            {
                return NotFound();
            }

            Console.WriteLine("***********************************************");
            var imagePath = Path.GetFullPath(
                Path.Join(
                    Environment.WebRootPath,
                    "../App_Data/api/Dossiers_Anesthesiques/Patients/Avatars",
                    personne.Id + ".png"
                )
            );
            Console.WriteLine(imagePath);

            var d = Path.GetDirectoryName(imagePath);
            if (!Directory.Exists(d))
                Directory.CreateDirectory(d);
            IFormFile imageInput = file;

            if (file.Length > 0)
            {
                using (var stream = new StreamWriter(imagePath))
                {
                    var hashAlg = MD5.Create();
                    var cs = new CryptoStream(stream.BaseStream, hashAlg, CryptoStreamMode.Write);
                    await file.CopyToAsync(cs);
                    cs.FlushFinalBlock();
                    var HashCode = Convert.ToBase64String(hashAlg.Hash);
                }
                using (var stream = imageInput.OpenReadStream())
                {
                    var image = Image.FromStream(stream);
                    var thumbnail = image.GetThumbnailImage(100, 100, null, IntPtr.Zero);
                    using (var stream_ = new MemoryStream())
                    {
                        thumbnail.Save(stream_, ImageFormat.Jpeg);
                        byte[] thumbnailBytes = stream_.ToArray();
                        personne.Thumbnail = thumbnailBytes;
                        _context.Entry(personne).State = EntityState.Modified;
                    }
                }
            }
            var ret = await _context.SaveChangesAsync();
            return Ok(ret);
        }
    }
}
