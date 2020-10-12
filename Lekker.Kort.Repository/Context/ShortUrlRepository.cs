using Lekker.Kort.Interface;
using Lekker.Kort.Interface.DTO;
using System.Threading;
using System.Threading.Tasks;

namespace Lekker.Kort.Repository.Context
{
    public class ShortUrlRepository : IModifiedUrlRepository
    {
        protected ShortUrlContext _kortContext;

        private readonly IModifiedUrlContextFactory _contextFactory;

        public ShortUrlRepository(IModifiedUrlContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void ReleaseContext()
        {
            if (_kortContext != null)
            {
                _kortContext.Dispose();
                _kortContext = null;
            }
        }

        public void SetContext()
        {
            if (_kortContext == null)
                _kortContext = (ShortUrlContext)_contextFactory.CreateDbContext();
        }

        public async Task<ModifiedUrlResponse> AddShortenedUrl(string id, string uri, CancellationToken cancellationToken)
        {
            var url = await _kortContext.AddShortUrlAsync(id, uri, cancellationToken).ConfigureAwait(false);
            return new ModifiedUrlResponse()
            {
                ShortUrl = url.Key
            };
        }

        public async Task<OriginalUrlResponseDto> GetOriginalUrl(string shortUrl, CancellationToken cancellationToken)
        {
            var url = await _kortContext
                                .GetOriginalUrl(shortUrl, cancellationToken)
                                .ConfigureAwait(false);

            return new OriginalUrlResponseDto()
            {
                OriginalUrl = url.Url
            };
        }

        public async Task<int> GetLastIndex(CancellationToken cancellationToken)
        {
            return await _kortContext.GetLastIndex(cancellationToken)
                                     .ConfigureAwait(false);
        }
    }
}