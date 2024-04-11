using TheMäklersAPI.Data.Models;
using TheMäklersAPI.Data.Interfaces;
using Microsoft.EntityFrameworkCore;


// Linus Anderstedt
namespace TheMäklersAPI.Data.Repositories
{
	public class BrokerRepository : IBroker
	{
		private readonly MäklersContext _context;

		public BrokerRepository(MäklersContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Broker>> GetBrokersAsync()
		{
			return await _context.Broker.ToListAsync();
		}

        public async Task<Broker> GetBrokerByIdAsync(int id)
        {
            return await _context.Broker.FindAsync(id);
        }

        public async Task AddBrokerAsync(Broker broker)
        {
            _context.Broker.Add(broker);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBrokerAsync(Broker broker)
        {
            _context.Entry(broker).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBrokerAsync(Broker broker)
        {
            _context.Broker.Remove(broker);
            await _context.SaveChangesAsync();
        }
    }
}
