using Lekker.Kort.Interface;
using System.Threading;
using System.Threading.Tasks;

namespace Lekker.Kort.UTest
{
    public class TestIdService : IIndexService
    {
        private int _incId = 5;

        public Task<int> GetNextIndex(CancellationToken cancellationToken)
        {
            _incId++;
            return Task.FromResult(_incId);
        }
    }
}