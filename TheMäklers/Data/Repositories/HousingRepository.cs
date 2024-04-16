using TheMäklersAPI.Data.Models;
using TheMäklersAPI.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TheMäklersAPI.Data.Repositories
{
    public class HousingRepository : IHousing //Author Kim
    {
        private readonly MäklersContext _context;

        public HousingRepository(MäklersContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Housing>> GetHousingsAsync()
        {
            return await _context.Housing
                .Include(h => h.Broker)
                .Include(h => h.Broker.Agency)
                .Include(h => h.Municipality)
                .Include(h => h.Category)
                .ToListAsync();
        }

        public async Task<Housing> GetHousingByIdAsync(int id)
        {
            var housing = await _context.Housing
                .Include(h => h.Broker)
                .Include(h => h.Broker.Agency)
                .Include(h => h.Municipality)
                .Include(h => h.Category)
                .FirstOrDefaultAsync(h => h.Id == id);

            return housing;
        }

        public async Task AddHousingAsync(Housing housing)
        {
            _context.Housing.Add(housing);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHousingAsync(Housing housing)
        {
            _context.Entry(housing).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHousingAsync(Housing housing)
        {
            _context.Housing.Remove(housing);
            await _context.SaveChangesAsync();
        }
    }
}