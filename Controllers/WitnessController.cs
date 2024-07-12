using Microsoft.AspNetCore.Mvc;
using LisaApi.Models;
using LisaApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/witnesses")]
// [Authorize]
public class WitnessController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IWitnessService _witnessService;


    public WitnessController(AppDbContext context, IWitnessService witnessService)
    {
        _context = context;
        _witnessService = witnessService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Witness>>> GetWitnesses()
    {
        return await _context.Witnesses.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Witness>> GetWitness(int id)
    {
        var witness = await _context.Witnesses.FindAsync(id);

        if (witness == null)
        {
            return NotFound();
        }

        return witness;
    }

    [HttpPost]
    public async Task<ActionResult<Witness>> CreateWitness(Witness witness)
    {
        _context.Witnesses.Add(witness);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetWitness), new { id = witness.Id }, witness);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWitness(int id, Witness witness)
    {
        if (id != witness.Id)
        {
            return BadRequest();
        }

        var existingwitness = await _witnessService.GetWitnessAsync(id);
        if (existingwitness == null)
        {
            return NotFound();
        }

        await _witnessService.UpdateWitnessAsync(id, witness);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWitness(int id)
    {
        var witness = await _context.Witnesses.FindAsync(id);

        if (witness == null)
        {
            return NotFound();
        }

        _context.Witnesses.Remove(witness);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool WitnessExists(int id)
    {
        return _context.Witnesses.Any(e => e.Id == id);
    }
}