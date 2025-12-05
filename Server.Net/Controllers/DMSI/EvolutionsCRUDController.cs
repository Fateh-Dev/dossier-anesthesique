using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Net.Data;
using Server.Net.DTOs.DMSI;
using Server.Net.Models.DMSI;

namespace Server.Net.Controllers.DMSI;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
[ApiExplorerSettings(GroupName = "Suivi_Dossiers_Reanimation")]
public class EvolutionsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public EvolutionsController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // ✅ GET: api/Evolutions (Récupérer toutes les évolutions)
    [HttpGet("getAll")]
    public async Task<ActionResult<IEnumerable<DMSI_Evolutions>>> getAll()
    {
        return await _context
            .DMSI_Evolutions.Include(e => e.Dossier)
            .Include(e => e.Medecin_1)
            .Include(e => e.Medecin_2)
            .ToListAsync();
    }

    // ✅ GET: api/Evolutions/{id} (Récupérer une évolution par ID)
    [HttpGet("GetEvolutionById/{id}")]
    public async Task<ActionResult<DMSI_Evolutions>> GetEvolutionById(Guid id)
    {
        var evolution = await _context
            .DMSI_Evolutions.Include(e => e.Dossier)
            .Include(e => e.Medecin_1)
            .Include(e => e.Medecin_2)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (evolution == null)
        {
            return NotFound();
        }

        return evolution;
    }

    // ✅ POST: api/Evolutions (Créer une nouvelle évolution)
    [HttpPost("createEvaluation")]
    public async Task<ActionResult<DMSI_Evolutions>> PostEvolution(
        [FromBody] DMSI_EvolutionsCreateOrUpdateDto evolution
    )
    {
        var ev = _mapper.Map<DMSI_Evolutions>(evolution);
        evolution.Id = Guid.NewGuid(); // Générer un nouvel ID
        _context.DMSI_Evolutions.Add(ev);
        await _context.SaveChangesAsync();

        return Ok(ev);
    }

    // ✅ DELETE: api/Evolutions/{id} (Supprimer une évolution)
    [HttpDelete("deleteEvaluation{id}")]
    public async Task<ActionResult<string>> DeleteEvolution(Guid id)
    {
        var evolution = await _context.DMSI_Evolutions.FindAsync(id);
        if (evolution == null)
        {
            return NotFound();
        }

        _context.DMSI_Evolutions.Remove(evolution);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // 🔎 Vérifie si une évolution existe dans la base de données
    private bool EvolutionExists(Guid id)
    {
        return _context.DMSI_Evolutions.Any(e => e.Id == id);
    }
}
