using TheMäklersAPI.Data.Models;

namespace TheMäklersAPI.Data.Repositories
{
    public class HousingRepository : IHousingRepository
    {
        private readonly ApplicationDbContext _context;

        public HousingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Housing>> GetHousingsAsync()
        {
            return await _context.Housings.ToListAsync();
        }

        public async Task<Housing> GetHousingByIdAsync(int id)
        {
            return await _context.Housings.FindAsync(id);
        }

        public async Task AddHousingAsync(Housing housing)
        {
            _context.Housings.Add(housing);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHousingAsync(Housing housing)
        {
            _context.Entry(housing).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHousingAsync(Housing housing)
        {
            _context.Housings.Remove(housing);
            await _context.SaveChangesAsync();
        }
    }
}
