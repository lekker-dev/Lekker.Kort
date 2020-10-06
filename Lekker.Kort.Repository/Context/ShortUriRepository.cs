using Lekker.Kort.Interface;
using Lekker.Kort.Interface.DTO;
using System.Threading;
using System.Threading.Tasks;

namespace Lekker.Kort.Repository.Context
{
    public class ShortUriRepository : IShortUriRepository
    {
        protected ShortUriContext _kortContext;

        private readonly IShortUriContextFactory _contextFactory;

        public ShortUriRepository(IShortUriContextFactory contextFactory)
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
                _kortContext = (ShortUriContext)_contextFactory.CreateDbContext();
        }

        public async Task<ShortUrlResponseDto> AddShortenedUrl(string uri, CancellationToken cancellationToken)
        {
            var url = await _kortContext.AddShortUrlAsync(uri, cancellationToken).ConfigureAwait(false);
            return new ShortUrlResponseDto()
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
    }
}