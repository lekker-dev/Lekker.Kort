using System.Threading;
using System.Threading.Tasks;

namespace Lekker.Kort.Interface
{
    public interface IIndexService
    {
        Task<int> GetNextIndex(CancellationToken cancellationToken);
    }
}