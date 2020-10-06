using Lekker.Kort.Interface.DTO;
using Lekker.Kort.Models.Response;

namespace Lekker.Kort.Models
{
    public static class ResponseExtensions
    {
        public static ShortUrlResponse ToShortUrlResponse(this ShortUrlResponseDto dto)
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
    }
}