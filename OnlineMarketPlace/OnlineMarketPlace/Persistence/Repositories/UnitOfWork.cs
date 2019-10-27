using OnlineMarketPlace.Domain.Interfaces;
using OnlineMarketPlace.Persistence.Contexts;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineMarketPlaceContext _context;

        public UnitOfWork(OnlineMarketPlaceContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
