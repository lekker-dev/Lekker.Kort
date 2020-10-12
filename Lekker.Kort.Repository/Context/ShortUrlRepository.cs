using Lekker.Kort.Interface;
using Lekker.Kort.Interface.DTO;
using System.Threading;
using System.Threading.Tasks;

namespace Lekker.Kort.Repository.Context
{
    public class ShortUrlRepository : IModifiedUrlRepository
    {
        private readonly IModifiedUrlContextFactory _contextFactory;

        public ShortUrlRepository(IModifiedUrlContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<ModifiedUrlResponse> AddShortenedUrl(string id, string uri, CancellationToken cancellationToken)
        {
            var url = await GetContext()
                                .AddShortUrlAsync(id, uri, cancellationToken).ConfigureAwait(false);

            return new ModifiedUrlResponse()
            {
                ShortUrl = url.Key
            };
        }

        public ShortUrlContext GetContext()
        {
            return (ShortUrlContext)_contextFactory.CreateDbContext();
        }

        public async Task<int> GetLastIndex(CancellationToken cancellationToken)
        {
            return await GetContext()
                            .GetLastIndex(cancellationToken)
                            .ConfigureAwait(false);
        }

        public async Task<OriginalUrlResponseDto> GetOriginalUrl(string shortUrl, CancellationToken cancellationToken)
        {
            var url = await GetContext()
                                .GetOriginalUrl(shortUrl, cancellationToken)
                                .ConfigureAwait(false);

            return new OriginalUrlResponseDto()
            {
                OriginalUrl = url.Url
            };
        }
    }
}