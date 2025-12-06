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

        // ======================= CREATE ENDPOINTS =======================

        [HttpPost("specialites")]
        public async Task<ActionResult> CreateSpecialite([FromBody] RefEntity item)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(item?.Label))
                    return BadRequest("Label is required");
                
                var max = _context.Specialites.Any() ? _context.Specialites.Max(e => e.Order) : 0;
                var entity = new Specialite(item.Label, item.Label, max + 1);
                entity.Description = item.Label; // Required by DB
                _context.Specialites.Add(entity);
                await _context.SaveChangesAsync();
                return Ok(
                    new
                    {
                        entity.Id,
                        entity.Label,
                        entity.Abreviation,
                        entity.Order,
                    }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpPost("typesAnesthesies")]
        public async Task<ActionResult> CreateTypeAnesthesie([FromBody] RefEntity item)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(item?.Label))
                    return BadRequest("Label is required");
                var max = _context.TypesAnesthesies.Any() ? _context.TypesAnesthesies.Max(e => e.Order) : 0;
                var entity = new TypeAnesthesie(item.Label, item.Label, max + 1);
                entity.Description = item.Label; // Required by DB
                _context.TypesAnesthesies.Add(entity);
                await _context.SaveChangesAsync();
                return Ok(new { entity.Id, entity.Label, entity.Abreviation, entity.Order });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpPost("gradesScientifiques")]
        public async Task<ActionResult> CreateGradeScientifique([FromBody] RefEntity item)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(item?.Label))
                    return BadRequest("Label is required");
                var max = _context.GradesScientifiques.Any() ? _context.GradesScientifiques.Max(e => e.Order) : 0;
                var entity = new GradeScientifique(item.Label, item.Label, max + 1);
                entity.Description = item.Label; // Required by DB
                _context.GradesScientifiques.Add(entity);
                await _context.SaveChangesAsync();
                return Ok(new { entity.Id, entity.Label, entity.Abreviation, entity.Order });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpPost("respirateurs")]
        public async Task<ActionResult> CreateRespirateur([FromBody] RefEntity item)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(item?.Label))
                    return BadRequest("Label is required");
                var max = _context.Respirateurs.Any() ? _context.Respirateurs.Max(e => e.Order) : 0;
                var entity = new Respirateur(item.Label, item.Label, max + 1);
                entity.Description = item.Label; // Required by DB
                _context.Respirateurs.Add(entity);
                await _context.SaveChangesAsync();
                return Ok(new { entity.Id, entity.Label, entity.Abreviation, entity.Order });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpPost("armes")]
        public async Task<ActionResult> CreateArme([FromBody] RefEntity item)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(item?.Label))
                    return BadRequest("Label is required");
                var max = _context.Armes.Any() ? _context.Armes.Max(e => e.Order) : 0;
                var entity = new Arme(item.Label, item.Label, max + 1);
                entity.Description = item.Label; // Required by DB
                _context.Armes.Add(entity);
                await _context.SaveChangesAsync();
                return Ok(new { entity.Id, entity.Label, entity.Abreviation, entity.Order });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpPost("agents")]
        public async Task<ActionResult> CreateAgent([FromBody] RefEntity item)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(item?.Label))
                    return BadRequest("Label is required");
                var max = _context.Agents.Any() ? _context.Agents.Max(e => e.Order) : 0;
                var entity = new Agent(item.Label, item.Label, max + 1);
                entity.Description = item.Label; // Required by DB
                _context.Agents.Add(entity);
                await _context.SaveChangesAsync();
                return Ok(new { entity.Id, entity.Label, entity.Abreviation, entity.Order });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpPost("grades")]
        public async Task<ActionResult> CreateGrade([FromBody] RefEntity item)
        {
            var max = _context.Grades.Any() ? _context.Grades.Max(e => e.Order) : 0;
            var entity = new Grade(item.Label, item.Label, max + 1);
            _context.Grades.Add(entity);
            await _context.SaveChangesAsync();
            return Ok(
                new
                {
                    entity.Id,
                    entity.Label,
                    entity.Abreviation,
                    entity.Order,
                }
            );
        }

        // ======================= GET ALL ENDPOINTS =======================

        [HttpGet("specialites")]
        public async Task<ActionResult<List<object>>> GetSpecialites()
        {
            var items = await _context
                .Specialites.OrderBy(o => o.Order)
                .Select(e => new
                {
                    e.Id,
                    e.Label,
                    e.Abreviation,
                    e.Order,
                })
                .ToListAsync();
            return Ok(items);
        }

        [HttpGet("typesAnesthesies")]
        public async Task<ActionResult<List<object>>> GetTypesAnesthesies()
        {
            var items = await _context
                .TypesAnesthesies.OrderBy(o => o.Order)
                .Select(e => new
                {
                    e.Id,
                    e.Label,
                    e.Abreviation,
                    e.Order,
                })
                .ToListAsync();
            return Ok(items);
        }

        [HttpGet("gradesScientifiques")]
        public async Task<ActionResult<List<object>>> GetGradesScientifiques()
        {
            var items = await _context
                .GradesScientifiques.OrderBy(o => o.Order)
                .Select(e => new
                {
                    e.Id,
                    e.Label,
                    e.Abreviation,
                    e.Order,
                })
                .ToListAsync();
            return Ok(items);
        }

        [HttpGet("respirateurs")]
        public async Task<ActionResult<List<object>>> GetRespirateurs()
        {
            var items = await _context
                .Respirateurs.OrderBy(o => o.Order)
                .Select(e => new
                {
                    e.Id,
                    e.Label,
                    e.Abreviation,
                    e.Order,
                })
                .ToListAsync();
            return Ok(items);
        }

        [HttpGet("armes")]
        public async Task<ActionResult<List<object>>> GetArmes()
        {
            var items = await _context
                .Armes.OrderBy(o => o.Order)
                .Select(e => new
                {
                    e.Id,
                    e.Label,
                    e.Abreviation,
                    e.Order,
                })
                .ToListAsync();
            return Ok(items);
        }

        [HttpGet("agents")]
        public async Task<ActionResult<List<object>>> GetAgents()
        {
            var items = await _context
                .Agents.OrderBy(o => o.Order)
                .Select(e => new
                {
                    e.Id,
                    e.Label,
                    e.Abreviation,
                    e.Order,
                })
                .ToListAsync();
            return Ok(items);
        }

        [HttpGet("grades")]
        public async Task<ActionResult<List<object>>> GetGrades()
        {
            var items = await _context
                .Grades.OrderBy(o => o.Order)
                .Select(e => new
                {
                    e.Id,
                    e.Label,
                    e.Abreviation,
                    e.Order,
                })
                .ToListAsync();
            return Ok(items);
        }

        // ======================= UPDATE ENDPOINTS =======================

        [HttpPut("specialites/{id}")]
        public async Task<ActionResult> UpdateSpecialite(Guid id, [FromBody] RefEntity item)
        {
            try
            {
                var entity = await _context.Specialites.FindAsync(id);
                if (entity == null) return NotFound();
                entity.Label = item.Label;
                entity.Abreviation = item.Label;
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpPut("typesAnesthesies/{id}")]
        public async Task<ActionResult> UpdateTypeAnesthesie(Guid id, [FromBody] RefEntity item)
        {
            try
            {
                var entity = await _context.TypesAnesthesies.FindAsync(id);
                if (entity == null) return NotFound();
                entity.Label = item.Label;
                entity.Abreviation = item.Label;
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpPut("gradesScientifiques/{id}")]
        public async Task<ActionResult> UpdateGradeScientifique(Guid id, [FromBody] RefEntity item)
        {
            try
            {
                var entity = await _context.GradesScientifiques.FindAsync(id);
                if (entity == null) return NotFound();
                entity.Label = item.Label;
                entity.Abreviation = item.Label;
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpPut("respirateurs/{id}")]
        public async Task<ActionResult> UpdateRespirateur(Guid id, [FromBody] RefEntity item)
        {
            try
            {
                var entity = await _context.Respirateurs.FindAsync(id);
                if (entity == null) return NotFound();
                entity.Label = item.Label;
                entity.Abreviation = item.Label;
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpPut("armes/{id}")]
        public async Task<ActionResult> UpdateArme(Guid id, [FromBody] RefEntity item)
        {
            try
            {
                var entity = await _context.Armes.FindAsync(id);
                if (entity == null) return NotFound();
                entity.Label = item.Label;
                entity.Abreviation = item.Label;
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpPut("agents/{id}")]
        public async Task<ActionResult> UpdateAgent(Guid id, [FromBody] RefEntity item)
        {
            try
            {
                var entity = await _context.Agents.FindAsync(id);
                if (entity == null) return NotFound();
                entity.Label = item.Label;
                entity.Abreviation = item.Label;
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpPut("grades/{id}")]
        public async Task<ActionResult> UpdateGrade(Guid id, [FromBody] RefEntity item)
        {
            try
            {
                var entity = await _context.Grades.FindAsync(id);
                if (entity == null) return NotFound();
                entity.Label = item.Label;
                entity.Abreviation = item.Label;
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, inner = ex.InnerException?.Message });
            }
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
            try
            {
                var currentItem = _context.Specialites.FirstOrDefault(o => o.Id == Id);
                if (currentItem == null) return NotFound();
                var queue = _context.Specialites.Any() ? _context.Specialites.Max(o => o.Order) : 0;
                await this.reOrderSpecialite(currentItem.Order, queue);
                _context.Remove(currentItem);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpDelete("DeleteTypeAnesthesie")]
        public async Task<ActionResult> DeleteTypeAnesthesie(Guid Id)
        {
            try
            {
                var currentItem = _context.TypesAnesthesies.FirstOrDefault(o => o.Id == Id);
                if (currentItem == null) return NotFound();
                var queue = _context.TypesAnesthesies.Any() ? _context.TypesAnesthesies.Max(o => o.Order) : 0;
                await this.reOrderTypeAnesthesie(currentItem.Order, queue);
                _context.Remove(currentItem);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpDelete("DeleteGradeScientifique")]
        public async Task<ActionResult> DeleteGradeScientifique(Guid Id)
        {
            try
            {
                var currentItem = _context.GradesScientifiques.FirstOrDefault(o => o.Id == Id);
                if (currentItem == null) return NotFound();
                var queue = _context.GradesScientifiques.Any() ? _context.GradesScientifiques.Max(o => o.Order) : 0;
                await this.reOrderGradeScientifique(currentItem.Order, queue);
                _context.Remove(currentItem);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpDelete("DeleteRespirateur")]
        public async Task<ActionResult> DeleteRespirateur(Guid Id)
        {
            try
            {
                var currentItem = _context.Respirateurs.FirstOrDefault(o => o.Id == Id);
                if (currentItem == null) return NotFound();
                var queue = _context.Respirateurs.Any() ? _context.Respirateurs.Max(o => o.Order) : 0;
                await this.reOrderRespirateur(currentItem.Order, queue);
                _context.Remove(currentItem);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpDelete("DeleteArme")]
        public async Task<ActionResult> DeleteArme(Guid Id)
        {
            try
            {
                var currentItem = _context.Armes.FirstOrDefault(o => o.Id == Id);
                if (currentItem == null) return NotFound();
                var queue = _context.Armes.Any() ? _context.Armes.Max(o => o.Order) : 0;
                await this.reOrderArmes(currentItem.Order, queue);
                _context.Remove(currentItem);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpDelete("DeleteAgents")]
        public async Task<ActionResult> DeleteAgents(Guid Id)
        {
            try
            {
                var currentItem = _context.Agents.FirstOrDefault(o => o.Id == Id);
                if (currentItem == null) return NotFound();
                var queue = _context.Agents.Any() ? _context.Agents.Max(o => o.Order) : 0;
                await this.reOrderAgents(currentItem.Order, queue);
                _context.Remove(currentItem);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpDelete("DeleteGrade")]
        public async Task<ActionResult> DeleteGrade(Guid Id)
        {
            try
            {
                var currentItem = _context.Grades.FirstOrDefault(o => o.Id == Id);
                if (currentItem == null) return NotFound();
                var queue = _context.Grades.Any() ? _context.Grades.Max(o => o.Order) : 0;
                await this.reOrderGrade(currentItem.Order, queue);
                _context.Remove(currentItem);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpGet("debug/tables")]
        public IActionResult GetTables()
        {
            try
            {
                var tables = new List<string>();
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;";
                    _context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            tables.Add(result.GetString(0));
                        }
                    }
                }
                return Ok(tables);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
