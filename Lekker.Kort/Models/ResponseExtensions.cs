using Lekker.Kort.Interface.DTO;
using Lekker.Kort.Models.Response;

namespace Lekker.Kort.Models
{
    public static class ResponseExtensions
    {
        public static ShortUrlResponse ToShortUrlResponse(this ModifiedUrlResponse dto)
        {
            return new ShortUrlResponse()
            {
                ShortUrl = dto.ShortUrl
            };
        }

        public static OriginalUrlResponse ToOriginalUrlResponse(this OriginalUrlResponseDto dto)
        {
            return new OriginalUrlResponse()
            {
                OriginalUrl = dto.OriginalUrl
            };
        }

        public static UrlDetailResponse ToDetailUrlResponse(this UrlDetailResponseDto dto)
        {
            return new UrlDetailResponse()
            {
                OriginalUrl = dto.OriginalUrl,
                Hits = dto.Hits.ToArray(),
                HitCount = dto.Hits.Count
            };
        }
    }
}