using TheMäklersAPI.Data.Models;

namespace TheMäklersAPI.Data.Interfaces
{
    public interface IAgency //Author Felix
    {
        Task<IEnumerable<Agency>> GetAgencyAsync();
        Task<Agency> GetAgencyByIdAsync(int id);
        Task<Agency> GetAgencyByNameAsync(string name);
        Task AddAgencyAsync(Agency agency);
        Task UpdateAgencyAsync(Agency agency);
        Task DeleteAgencyAsync(int id);
    }
}
