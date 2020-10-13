using Lekker.Kort.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lekker.Kort.Services
{
    public class LekkerIdService : IIdService
    {
        private readonly IIndexService _indexService;
        private readonly ILogger _logger;

        public LekkerIdService(ILogger<LekkerIdService> logger, IIndexService indexService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _indexService = indexService ?? throw new ArgumentNullException(nameof(indexService));
        }

        public async Task<string> GetUniqueId(CancellationToken cancellationToken)
        {
            var index = await _indexService.GetNextIndex(cancellationToken).ConfigureAwait(false);

            var id = GetLekkerStringForIndex(index.ToString());
            _logger.LogDebug($"Issued Id: {id}");
            return id;
        }

        private static string GetLekkerStringForIndex(string key)
        {
            var id = "";
            for (int i = 0; i < key.Length; i++)
            {
                id += LekkerConstants.GetLekkerItemForChar(key[i]) + "-";
            }

            return id.Trim('-');
        }
    }
}