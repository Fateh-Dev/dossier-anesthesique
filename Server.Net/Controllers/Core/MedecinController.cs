using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Server.Net.Data;
using Server.Net.DTOs.Core;
using Server.Net.Models.Entities;
using Server.Net.Services;

namespace Server.Net.Controllers.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedecinController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ExternalAuthService _ExternalAuthService;

        private IWebHostEnvironment Environment { get; set; }

        public MedecinController(
            ApplicationDbContext context,
            ExternalAuthService externalAuthService,
            IWebHostEnvironment environment
        )
        {
            _context = context;
            _ExternalAuthService = externalAuthService;
            Environment = environment;
        }

        [HttpPost("Get_All_Medecins_Filter")]
        public async Task<ActionResult<PagedResultDto<Medecin>>> Get_All_Medecins_Filter(
            [FromBody] MedecinQuery query
        )
        {
            var ret = new PagedResultDto<Medecin>();

            var retquery = _context.Medecins.Where(o => o.IsDeleted == false).AsQueryable();

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
            if (!String.IsNullOrEmpty(query.Specialite))
            {
                retquery = retquery.Where(k => k.Specialite == query.Specialite);
            }

            if (!String.IsNullOrEmpty(query.GradeScientifique))
            {
                retquery = retquery.Where(k => k.GradeScientifique == query.GradeScientifique);
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

        [HttpGet("Get_Medecin_ById")]
        public async Task<ActionResult<Medecin>> Get_Intervention_ById(Guid id)
        {
            Medecin medecin = await _context.Medecins.Where(e => e.Id == id).FirstOrDefaultAsync();
            if (medecin == null)
                return NotFound();
            // var interventionsIds = _context.ActeursIntervenants.Where(e => e.MedecinId == id).Select(o => o.InterventionId).ToList();
            // if (interventionsIds != null)
            //     medecin.InterventionsParticipe = _context.Interventions.Where(e => interventionsIds.Contains(e.Id)).ToList(); ;
            return Ok(medecin);
        }

        [HttpGet("Recover_Medecin")]
        public async Task<ActionResult<Medecin>> Recover(Guid Id)
        {
            /**
               updating
            **/
            var ev = await _context
                .Medecins.IgnoreQueryFilters()
                .Where(x => x.Id == Id && x.IsDeleted == true)
                .FirstOrDefaultAsync();
            ev.IsDeleted = false;
            // var a = await _context.Personnes.Where(x => x.Id == Id).FirstOrDefaultAsync();
            // _context.Personnes.Remove(a);
            await _context.SaveChangesAsync();
            return Ok("Medecin a été reccuperé avec succes");
        }

        [HttpDelete("Delete_Medecin_ById")]
        public async Task<ActionResult<Medecin>> Delete_Medecin_ById(Guid idMedecin)
        {
            Medecin el = await _context
                .Medecins.Where(e => e.Id == idMedecin)
                .FirstOrDefaultAsync();
            if (el == null)
                return NotFound();
            _context.Remove(el);
            await _context.SaveChangesAsync();
            return Ok("Deleted");
        }

        [HttpPost("Create_Medecin")]
        public async Task<ActionResult<string>> Create_Medecin([FromBody] Medecin item)
        {
            if (item == null) return BadRequest("Invalid data");

            Medecin medecin = item;
            if (medecin.Id == Guid.Empty)
            {
                medecin.Id = Guid.NewGuid();
            }
            
            // Fix logic dependent on properties
            if (!string.IsNullOrEmpty(medecin.Matricule) && medecin.Matricule.Length >= 8) {
               try { medecin.fixSexeFromMatricule(); } catch {}
            }

            // Check duplicate matricule
            var exists = await _context.Medecins.AnyAsync(m => m.Matricule == medecin.Matricule && !m.IsDeleted);
            if (exists) {
                return BadRequest($"Un médecin avec le matricule {medecin.Matricule} existe déjà.");
            }

            _context.Medecins.Add(medecin);
            await _context.SaveChangesAsync();

            return Ok("Success");
        }

        [HttpPut("Update_Medecin")]
        public async Task<ActionResult<string>> Update_Medecin([FromBody] Medecin item)
        {
            if (item == null || item.Id == Guid.Empty) return BadRequest("Invalid ID");

            var existing = await _context.Medecins.FirstOrDefaultAsync(m => m.Id == item.Id);
            if (existing == null) return NotFound("Médecin non trouvé");

            // Update allowed fields
            existing.Nom = item.Nom;
            existing.Prenom = item.Prenom;
            existing.Matricule = item.Matricule;
            existing.Specialite = item.Specialite;
            existing.GradeScientifique = item.GradeScientifique;
            existing.NumeroTel = item.NumeroTel;
            existing.Sexe = item.Sexe;
            existing.Nationnalite = item.Nationnalite; // update if exists in frontend
            existing.GradeActuel = item.GradeActuel;

            // Preserve image if not provided
            if (item.Image != null && item.Image.Length > 0) existing.Image = item.Image;
            if (item.Thumbnail != null && item.Thumbnail.Length > 0) existing.Thumbnail = item.Thumbnail;
            
            _context.Entry(existing).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("Success");
        }

        [HttpPost("DownloadMedecinsList")]
        public async Task<FileStreamResult> DownloadMedecinsList([FromBody] MedecinQuery query)
        {
            var ret = new PagedResultDto<Medecin>();
            var retquery = _context.Medecins.AsQueryable();

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
            if (!String.IsNullOrEmpty(query.Specialite))
            {
                retquery = retquery.Where(k => k.Specialite == query.Specialite);
            }

            if (!String.IsNullOrEmpty(query.GradeScientifique))
            {
                retquery = retquery.Where(k => k.GradeScientifique == query.GradeScientifique);
            }

            if (!String.IsNullOrEmpty(query.Nationnalite))
            {
                retquery = retquery.Where(k => k.Nationnalite == query.Nationnalite);
            }

            retquery = retquery.OrderBy(e => e.Nom);
            var ar = await retquery.Select(o => o.Id).ToArrayAsync();
            var Personnes = await _context
                .Medecins.Where(o => ar.Contains(o.Id))
                .OrderBy(o => o.Matricule)
                .Select(o => new MedecinToExcel()
                {
                    Nom = o.Nom,
                    Prenom = o.Prenom,
                    Matricule = o.Matricule,
                    Sexe = o.Sexe,
                    // Nationnalite = o.Nationnalite,
                    GradeScientifique = o.GradeScientifique,
                    Specialite = o.Specialite,
                })
                .ToListAsync();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Medecins");
                int row = 1;
                int column = 2;
                foreach (var property in typeof(MedecinToExcel).GetProperties())
                {
                    worksheet.Cells[row, column].Value = property.Name;
                    column++;
                }
                row = 2;
                foreach (var item in Personnes)
                {
                    column = 2;
                    foreach (var property in typeof(MedecinToExcel).GetProperties())
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
                        FileDownloadName = "Medecins.xlsx",
                    };
                }
            }
        }

        // Api Pour load une image de profile pour un eleve et compression
        [HttpPost("uploadAvatar/{*id}")]
        public async Task<ActionResult> UploadAvatar([FromRoute] Guid id, IFormFile file)
        {
            var personne = await _context.Medecins.Where(e => e.Id == id).FirstOrDefaultAsync();
            if (personne == null)
            {
                return NotFound();
            }

            Console.WriteLine("***********************************************");
            var imagePath = Path.GetFullPath(
                Path.Join(
                    Environment.WebRootPath,
                    "../App_Data/api/Dossiers_Anesthesiques/Medecins/Avatars",
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
