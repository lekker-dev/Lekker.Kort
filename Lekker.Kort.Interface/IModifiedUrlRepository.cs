using Lekker.Kort.Interface.DTO;
using System.Threading;
using System.Threading.Tasks;

namespace Lekker.Kort.Interface
{
    public interface IModifiedUrlRepository
    {
        Task<ModifiedUrlResponse> AddShortenedUrl(string id, string uri, CancellationToken cancellationToken);

        Task<int> GetLastIndex(CancellationToken cancellationToken);

        Task<OriginalUrlResponseDto> ResolveUrl(string shortUrl, string userId, CancellationToken cancellationToken);

        Task<UrlDetailResponseDto> GetUrlInfo(string shortUrl, CancellationToken cancellationToken);

    }
}