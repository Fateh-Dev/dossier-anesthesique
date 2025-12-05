using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Net.Data;
using Server.Net.Models.Enumerations;
using Server.Net.Models.Reference;

namespace Server.Net.Controllers.Reference
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "Suivi_Dossiers_Anesthesiques")]
    public class ReferenceTablesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private IWebHostEnvironment Environment { get; set; }

        public ReferenceTablesController(
            ApplicationDbContext context,
            IWebHostEnvironment environment
        )
        {
            _context = context;
            Environment = environment;
        }

        [HttpPost("addReferences")]
        public async Task<ActionResult<string>> Create_Entity([FromBody] RefEntity item)
        {
            var max = 0;
            switch (item.Description)
            {
                case "Spécialités":
                {
                    if (_context.Specialites.Any())
                        max = _context.Specialites.Max(e => e.Order);
                    Specialite el = new Specialite(item.Label, item.Label, max + 1);
                    _context.Specialites.Add(el);
                    break;
                }
                case "Type d'anesthesie":
                {
                    if (_context.TypesAnesthesies.Any())
                        max = _context.TypesAnesthesies.Max(e => e.Order);
                    TypeAnesthesie el = new TypeAnesthesie(item.Label, item.Label, max + 1);
                    _context.TypesAnesthesies.Add(el);
                    break;
                }
                case "Grades Scientifiques":
                {
                    if (_context.GradesScientifiques.Any())
                        max = _context.GradesScientifiques.Max(e => e.Order);
                    GradeScientifique el = new GradeScientifique(item.Label, item.Label, max + 1);
                    _context.GradesScientifiques.Add(el);
                    break;
                }
                case "Respirateurs":
                {
                    if (_context.Respirateurs.Any())
                        max = _context.Respirateurs.Max(e => e.Order);
                    Respirateur el = new Respirateur(item.Label, item.Label, max + 1);
                    _context.Respirateurs.Add(el);
                    break;
                }
                case "Armes":
                {
                    if (_context.Armes.Any())
                        max = _context.Armes.Max(e => e.Order);
                    Arme el = new Arme(item.Label, item.Label, max + 1);
                    _context.Armes.Add(el);
                    break;
                }
                case "Agents Anesthésiques":
                {
                    if (_context.Agents.Any())
                        max = _context.Agents.Max(e => e.Order);
                    Agent el = new Agent(item.Label, item.Label, max + 1);
                    _context.Agents.Add(el);
                    break;
                }
                case "Grades":
                {
                    if (_context.Grades.Any())
                        max = _context.Grades.Max(e => e.Order);
                    Grade el = new Grade(item.Label, item.Label, max + 1);
                    _context.Grades.Add(el);
                    break;
                }
                default:
                    break;
            }

            _context.SaveChanges();
            return Ok("Success");
        }

        [HttpGet("reOrderSpecialite")]
        public async Task<ActionResult> reOrderSpecialite(int oldIndex, int newIndex)
        {
            if (oldIndex != newIndex)
            {
                var currentItem = _context.Specialites.FirstOrDefault(o => o.Order == oldIndex);
                currentItem.Order = newIndex;
                // if old > new Shift to Right
                if (oldIndex > newIndex)
                {
                    var listToShift = _context
                        .Specialites.Where(t => t.Order >= newIndex && t.Order < oldIndex)
                        .ToList();
                    foreach (var item in listToShift)
                    {
                        item.Order += 1;
                    }
                }
                // if old < new Shift to Left
                else
                {
                    var listToShift = _context
                        .Specialites.Where(t => t.Order <= newIndex && t.Order > oldIndex)
                        .ToList();
                    foreach (var item in listToShift)
                    {
                        item.Order -= 1;
                    }
                }
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpGet("reOrderTypeAnesthesie")]
        public async Task<ActionResult> reOrderTypeAnesthesie(int oldIndex, int newIndex)
        {
            if (oldIndex != newIndex)
            {
                var currentItem = _context.TypesAnesthesies.FirstOrDefault(o =>
                    o.Order == oldIndex
                );
                currentItem.Order = newIndex;
                // if old > new Shift to Right
                if (oldIndex > newIndex)
                {
                    var listToShift = _context
                        .TypesAnesthesies.Where(t => t.Order >= newIndex && t.Order < oldIndex)
                        .ToList();
                    foreach (var item in listToShift)
                    {
                        item.Order += 1;
                    }
                }
                // if old < new Shift to Left
                else
                {
                    var listToShift = _context
                        .TypesAnesthesies.Where(t => t.Order <= newIndex && t.Order > oldIndex)
                        .ToList();
                    foreach (var item in listToShift)
                    {
                        item.Order -= 1;
                    }
                }
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpGet("reOrderGradeScientifique")]
        public async Task<ActionResult> reOrderGradeScientifique(int oldIndex, int newIndex)
        {
            if (oldIndex != newIndex)
            {
                var currentItem = _context.GradesScientifiques.FirstOrDefault(o =>
                    o.Order == oldIndex
                );
                currentItem.Order = newIndex;
                // if old > new Shift to Right
                if (oldIndex > newIndex)
                {
                    var listToShift = _context
                        .GradesScientifiques.Where(t => t.Order >= newIndex && t.Order < oldIndex)
                        .ToList();
                    foreach (var item in listToShift)
                    {
                        item.Order += 1;
                    }
                }
                // if old < new Shift to Left
                else
                {
                    var listToShift = _context
                        .GradesScientifiques.Where(t => t.Order <= newIndex && t.Order > oldIndex)
                        .ToList();
                    foreach (var item in listToShift)
                    {
                        item.Order -= 1;
                    }
                }
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpGet("reOrderRespirateur")]
        public async Task<ActionResult> reOrderRespirateur(int oldIndex, int newIndex)
        {
            if (oldIndex != newIndex)
            {
                var currentItem = _context.Respirateurs.FirstOrDefault(o => o.Order == oldIndex);
                currentItem.Order = newIndex;
                // if old > new Shift to Right
                if (oldIndex > newIndex)
                {
                    var listToShift = _context
                        .Respirateurs.Where(t => t.Order >= newIndex && t.Order < oldIndex)
                        .ToList();
                    foreach (var item in listToShift)
                    {
                        item.Order += 1;
                    }
                }
                // if old < new Shift to Left
                else
                {
                    var listToShift = _context
                        .Respirateurs.Where(t => t.Order <= newIndex && t.Order > oldIndex)
                        .ToList();
                    foreach (var item in listToShift)
                    {
                        item.Order -= 1;
                    }
                }
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpGet("reOrderArmes")]
        public async Task<ActionResult> reOrderArmes(int oldIndex, int newIndex)
        {
            if (oldIndex != newIndex)
            {
                var currentItem = _context.Armes.FirstOrDefault(o => o.Order == oldIndex);
                currentItem.Order = newIndex;
                // if old > new Shift to Right
                if (oldIndex > newIndex)
                {
                    var listToShift = _context
                        .Armes.Where(t => t.Order >= newIndex && t.Order < oldIndex)
                        .ToList();
                    foreach (var item in listToShift)
                    {
                        item.Order += 1;
                    }
                }
                // if old < new Shift to Left
                else
                {
                    var listToShift = _context
                        .Armes.Where(t => t.Order <= newIndex && t.Order > oldIndex)
                        .ToList();
                    foreach (var item in listToShift)
                    {
                        item.Order -= 1;
                    }
                }
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpGet("reOrderAgents")]
        public async Task<ActionResult> reOrderAgents(int oldIndex, int newIndex)
        {
            if (oldIndex != newIndex)
            {
                var currentItem = _context.Agents.FirstOrDefault(o => o.Order == oldIndex);
                currentItem.Order = newIndex;
                // if old > new Shift to Right
                if (oldIndex > newIndex)
                {
                    var listToShift = _context
                        .Agents.Where(t => t.Order >= newIndex && t.Order < oldIndex)
                        .ToList();
                    foreach (var item in listToShift)
                    {
                        item.Order += 1;
                    }
                }
                // if old < new Shift to Left
                else
                {
                    var listToShift = _context
                        .Agents.Where(t => t.Order <= newIndex && t.Order > oldIndex)
                        .ToList();
                    foreach (var item in listToShift)
                    {
                        item.Order -= 1;
                    }
                }
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpGet("reOrderGrade")]
        public async Task<ActionResult> reOrderGrade(int oldIndex, int newIndex)
        {
            if (oldIndex != newIndex)
            {
                var currentItem = _context.Grades.FirstOrDefault(o => o.Order == oldIndex);
                currentItem.Order = newIndex;
                // if old > new Shift to Right
                if (oldIndex > newIndex)
                {
                    var listToShift = _context
                        .Grades.Where(t => t.Order >= newIndex && t.Order < oldIndex)
                        .ToList();
                    foreach (var item in listToShift)
                    {
                        item.Order += 1;
                    }
                }
                // if old < new Shift to Left
                else
                {
                    var listToShift = _context
                        .Grades.Where(t => t.Order <= newIndex && t.Order > oldIndex)
                        .ToList();
                    foreach (var item in listToShift)
                    {
                        item.Order -= 1;
                    }
                }
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        //****************************** Delete Entities *******************************//

        [HttpDelete("DeleteSpecialite")]
        public async Task<ActionResult> DeleteSpecialite(Guid Id)
        {
            var currentItem = _context.Specialites.FirstOrDefault(o => o.Id == Id);
            var queue = _context.Specialites.Max(o => o.Order);
            await this.reOrderSpecialite(currentItem.Order, queue);
            _context.Remove(currentItem);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("DeleteTypeAnesthesie")]
        public async Task<ActionResult> DeleteTypeAnesthesie(Guid Id)
        {
            var currentItem = _context.TypesAnesthesies.FirstOrDefault(o => o.Id == Id);
            var queue = _context.TypesAnesthesies.Max(o => o.Order);
            await this.reOrderTypeAnesthesie(currentItem.Order, queue);
            _context.Remove(currentItem);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("DeleteGradeScientifique")]
        public async Task<ActionResult> DeleteGradeScientifique(Guid Id)
        {
            var currentItem = _context.GradesScientifiques.FirstOrDefault(o => o.Id == Id);
            var queue = _context.GradesScientifiques.Max(o => o.Order);
            await this.reOrderGradeScientifique(currentItem.Order, queue);
            _context.Remove(currentItem);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("DeleteRespirateur")]
        public async Task<ActionResult> DeleteRespirateur(Guid Id)
        {
            var currentItem = _context.Respirateurs.FirstOrDefault(o => o.Id == Id);
            var queue = _context.Respirateurs.Max(o => o.Order);
            await this.reOrderRespirateur(currentItem.Order, queue);
            _context.Remove(currentItem);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("DeleteArme")]
        public async Task<ActionResult> DeleteArme(Guid Id)
        {
            var currentItem = _context.Armes.FirstOrDefault(o => o.Id == Id);
            var queue = _context.Armes.Max(o => o.Order);
            await this.reOrderArmes(currentItem.Order, queue);
            _context.Remove(currentItem);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("DeleteAgents")]
        public async Task<ActionResult> DeleteAgents(Guid Id)
        {
            var currentItem = _context.Agents.FirstOrDefault(o => o.Id == Id);
            var queue = _context.Agents.Max(o => o.Order);
            await this.reOrderAgents(currentItem.Order, queue);
            _context.Remove(currentItem);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("DeleteGrade")]
        public async Task<ActionResult> DeleteGrade(Guid Id)
        {
            var currentItem = _context.Grades.FirstOrDefault(o => o.Id == Id);
            var queue = _context.Grades.Max(o => o.Order);
            await this.reOrderGrade(currentItem.Order, queue);
            _context.Remove(currentItem);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
