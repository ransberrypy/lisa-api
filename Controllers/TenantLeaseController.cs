using Microsoft.AspNetCore.Mvc;
using LisaApi.Models;
using LisaApi.Data;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/tenantleases")]
// [Authorize]
public class TenantLeasesController : ControllerBase
{
    private readonly AppDbContext _context;

    public TenantLeasesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TenantLease>> GetTenantLeases()
    {
        return _context.TenantLeases.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<TenantLease> GetTenantLease(int id)
    {
        var tenantLease = _context.TenantLeases.FirstOrDefault(t => t.TenantLeaseId == id);

        if (tenantLease == null)
        {
            return NotFound();
        }

        return tenantLease;
    }

    [HttpPost]
    public ActionResult<TenantLease> CreateTenantLease(TenantLease tenantLease)
    {
        _context.TenantLeases.Add(tenantLease);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetTenantLease), new { id = tenantLease.TenantLeaseId }, tenantLease);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateTenantLease(int id, TenantLease updatedTenantLease)
    {
        var tenantLease = _context.TenantLeases.FirstOrDefault(t => t.TenantLeaseId == id);

        if (tenantLease == null)
        {
            return NotFound();
        }

        // Update the properties of the tenant lease
        tenantLease.PropertyId = updatedTenantLease.PropertyId;
        tenantLease.TenantId = updatedTenantLease.TenantId;
        tenantLease.AmountPaid = updatedTenantLease.AmountPaid;
        tenantLease.LeaseDuration = updatedTenantLease.LeaseDuration;
        tenantLease.StartDate = updatedTenantLease.StartDate;
        tenantLease.EndDate = updatedTenantLease.EndDate;
        tenantLease.Witnesses = updatedTenantLease.Witnesses;
        tenantLease.UpdatedAt = DateTime.UtcNow;

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteTenantLease(int id)
    {
        var tenantLease = _context.TenantLeases.FirstOrDefault(t => t.TenantLeaseId == id);

        if (tenantLease == null)
        {
            return NotFound();
        }

        _context.TenantLeases.Remove(tenantLease);
        _context.SaveChanges();

        return NoContent();
    }
}