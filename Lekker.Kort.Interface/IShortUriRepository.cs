using Lekker.Kort.Interface.DTO;
using System.Threading;
using System.Threading.Tasks;

namespace Lekker.Kort.Interface
{
    public interface IShortUriRepository
    {
        Task<ShortUrlResponseDto> AddShortenedUrl(string uri, CancellationToken cancellationToken);

        Task<OriginalUrlResponseDto> GetOriginalUrl(string shortUrl, CancellationToken cancellationToken);

        void ReleaseContext();

        void SetContext();
    }
}