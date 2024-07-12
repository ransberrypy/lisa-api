using Microsoft.AspNetCore.Mvc;
using LisaApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace LisaApi.Controllers;

[Route("api/tenants")]
[ApiController]
// [Authorize]
public class TenantController : ControllerBase
{
    private readonly ITenantService _tenantService;

    public TenantController(ITenantService tenantService)
    {
        _tenantService = tenantService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTenants()
    {
        var tenants = await _tenantService.GetTenantsAsync();
        return Ok(tenants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTenant(int id)
    {
        var tenant = await _tenantService.GetTenantAsync(id);
        if (tenant == null)
        {
            return NotFound();
        }
        return Ok(tenant);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTenant(Tenant tenant)
    {
        var createdTenant = await _tenantService.CreateTenantAsync(tenant);
        return CreatedAtAction(nameof(GetTenant), new { id = createdTenant.TenantId }, createdTenant);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTenant(int id, Tenant updatedTenant)
    {
        if (id != updatedTenant.TenantId)
        {
            return BadRequest();
        }

        var existingTenant = await _tenantService.GetTenantAsync(id);
        if (existingTenant == null)
        {
            return NotFound();
        }

        await _tenantService.UpdateTenantAsync(id, updatedTenant);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTenant(int id)
    {
        var tenant = await _tenantService.GetTenantAsync(id);
        if (tenant == null)
        {
            return NotFound();
        }

        await _tenantService.DeleteTenantAsync(id);
        return NoContent();
    }
}

