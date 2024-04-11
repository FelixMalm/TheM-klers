using TheMäklersAPI.Data.Models;
using TheMäklersAPI.Data.Interfaces;
using Microsoft.EntityFrameworkCore;



namespace TheMäklersAPI.Data.Repositories
{
    public class HousingRepository : IHousing
    {
        private readonly MäklersContext _context;

        public HousingRepository(MäklersContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Housing>> GetHousingsAsync()
        {
            return await _context.Housing.ToListAsync();
        }

        public async Task<Housing> GetHousingByIdAsync(int id)
        {
            return await _context.Housing.FindAsync(id);
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
