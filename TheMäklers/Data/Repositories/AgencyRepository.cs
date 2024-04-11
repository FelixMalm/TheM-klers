using Microsoft.EntityFrameworkCore;
using TheMäklersAPI.Data.Interfaces;
using TheMäklersAPI.Data.Models;

namespace TheMäklersAPI.Data.Repositories
{
    public class AgencyRepository : IAgency
    {
        private readonly MäklersContext _context;

        public AgencyRepository(MäklersContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Agency>> GetAgencyAsync()
        {
            return await _context.Agency.ToListAsync();
        }

        public async Task<Agency> GetAgencyByIdAsync(int id)
        {
            return await _context.Agency.FindAsync(id);
        }
        public async Task AddAgencyAsync(Agency agency)
        {
            _context.Agency.Add(agency);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAgencyAsync(int id)
        {
            _context.Entry(id).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAgencyAsync(int id)
        {
            var agencyToDelete = await _context.Agency.FindAsync(id);
            _context.Agency.Remove(agencyToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Agency> GetAgencyByNameAsync(string name)
        {
            var agency = await _context.Agency.FirstOrDefaultAsync(a => a.Name == name);
            return agency;
        }
    }
}
