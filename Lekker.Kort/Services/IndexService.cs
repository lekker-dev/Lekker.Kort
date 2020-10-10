using Lekker.Kort.Interface;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Lekker.Kort.Services
{
    public class IndexService : IIndexService
    {
        private readonly ILogger _logger;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        private readonly IModifiedUrlRepository _shortUrlRepository;
        private int _index = -1;

        public IndexService(ILogger<IndexService> logger, IModifiedUrlRepository shortUrlRepository)
        {
            _logger = logger;
            _shortUrlRepository = shortUrlRepository;
        }

        public async Task<int> GetNextIndex(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (IndexIsNotInitialized())
            {
                await SetIndexToLastValueInDatabase(cancellationToken).ConfigureAwait(false);
            }

            // wait for the semaphore to allow us access and then take our turn to increment the index
            // this is for thread safety if a large amount of requests hit the service at the same time
            await _semaphore.WaitAsync().ConfigureAwait(false);

            var index = IncrementAndReturnIndex();

            _semaphore.Release();

            return index;
        }

        public int IncrementAndReturnIndex()
        {
            _index++;
            _logger.LogDebug($"New index: {_index}");
            return _index;
        }

        private bool IndexIsNotInitialized()
        {
            return _index < 0;
        }

        private async Task SetIndexToLastValueInDatabase(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Initialize Index from Database");
            _shortUrlRepository.SetContext();

            _index = await _shortUrlRepository
                                  .GetLastIndex(cancellationToken)
                                  .ConfigureAwait(false);
        }
    }
}