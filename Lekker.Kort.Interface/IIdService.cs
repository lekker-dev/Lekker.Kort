using System.Threading;
using System.Threading.Tasks;

namespace Lekker.Kort.Interface
{
    public interface IIdService
    {
        Task<string> GetUniqueId(CancellationToken cancellationToken);
    }
}