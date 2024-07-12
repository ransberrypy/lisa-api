using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LisaApi.Models;
using LisaApi.Data;


[ApiController]
[Route("api/leases")]
// [Authorize]
public class LeaseController : ControllerBase
{
    private readonly AppDbContext _context;

    public LeaseController(AppDbContext context)
    {
        _context = context;
    }

    // Controller actions will go here
    [HttpGet]
    public ActionResult<IEnumerable<Lease>> GetLeases()
    {
        var leases = _context.Leases.ToList();
        return Ok(leases);
    }

    [HttpGet("{id}")]
    public ActionResult<Lease> GetLease(int id)
    {
        var lease = _context.Leases.FirstOrDefault(l => l.LeaseId == id);   
        if(lease == null){
            return NotFound();
        }
        return Ok(lease);
    }

    [HttpPost]
    public IActionResult CreateLease(Lease lease)
    {
        _context.Leases.Add(lease);
        _context.SaveChanges();
        return CreatedAtAction(nameof(CreateLease), new {id = lease.LeaseId},lease);
    }

    [HttpPut("{id}")]
    public ActionResult<Lease> UpdateLease(int id, Lease lease)
    {
        var existingLease = _context.Leases.FirstOrDefault(l => l.LeaseId==id);
        if(existingLease == null){
            return NotFound();
        }
        existingLease.UpdatedAt = DateTime.Now;
        existingLease.PaymentStatus = lease.PaymentStatus;
        existingLease.AgreementFormFileData = lease.AgreementFormFileData;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteLease(int id)
    {
        var lease = _context.Leases.FirstOrDefault(p => p.LeaseId == id);
        if (lease == null)
        {
            return NotFound();
        }

        _context.Leases.Remove(lease);
        _context.SaveChanges();
        return NoContent();
    }
}