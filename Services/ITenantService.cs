using LisaApi.Models;

public interface ITenantService
{
    Task<List<Tenant>> GetTenantsAsync();
    Task<Tenant> GetTenantAsync(int id);
    Task<Tenant> CreateTenantAsync(Tenant tenant);
    Task UpdateTenantAsync(int id, Tenant updatedTenant);
    Task DeleteTenantAsync(int id);
}