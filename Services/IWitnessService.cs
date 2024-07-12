using LisaApi.Models;

public interface IWitnessService
{
    Task<List<Witness>> GetWitnesssAsync();
    Task<Witness> GetWitnessAsync(int id);
    Task<Witness> CreateWitnessAsync(Witness Witness);
    Task UpdateWitnessAsync(int id, Witness updatedWitness);
    Task DeleteWitnessAsync(int id);
}