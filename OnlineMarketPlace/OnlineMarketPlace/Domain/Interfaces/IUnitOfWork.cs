using System.Threading.Tasks;

namespace OnlineMarketPlace.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
