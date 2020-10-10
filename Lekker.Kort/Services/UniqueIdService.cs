using Lekker.Kort.Interface;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Lekker.Kort.Services
{
    public class UniqueIdService : IIdService
    {
        private readonly ILogger _logger;
        private readonly IIndexService _indexService;

        public UniqueIdService(ILogger<UniqueIdService> logger, IIndexService indexService)
        {
            _logger = logger;
            _indexService = indexService;
        }

        public async Task<string> GetUniqueId(CancellationToken cancellationToken)
        {
            var index = await _indexService.GetNextIndex(cancellationToken).ConfigureAwait(false);

            var id = index.ToString();
            _logger.LogDebug($"Issued Id: {id}");
            return id;
        }
    }
}