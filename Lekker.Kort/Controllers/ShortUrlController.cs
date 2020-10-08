using Lekker.Kort.Interface;
using Lekker.Kort.Models;
using Lekker.Kort.Models.Request;
using Lekker.Kort.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Lekker.Kort.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShortUrlController : KortControllerBase
    {
        public ShortUrlController(IShortUriRepository kortRepository) : base(kortRepository)
        {
        }

        [HttpPost]
        public async Task<ActionResult<ShortUrlResponse>> AddShortUrlAsync([Required] ShortenUrlRequest url, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(url.Url))
            {
                return BadRequest("Invalid URL");
            }

            var shortUrl = await GetShortenedUrlRepository()
                                    .AddShortenedUrl(System.Uri.UnescapeDataString(url.Url), cancellationToken)
                                    .ConfigureAwait(false);

            return Ok(shortUrl.ToShortUrlResponse());
        }

        [HttpGet]
        public async Task<ActionResult<OriginalUrlResponse>> GetOriginalUrl([Required] OriginalUrlRequest url, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(url.ShortUrl))
            {
                return BadRequest("Invalid URL");
            }

            var originalUrl = await GetShortenedUrlRepository()
                                        .GetOriginalUrl(url.ShortUrl, cancellationToken)
                                        .ConfigureAwait(false);

            return Ok(originalUrl.ToOriginalUrlResponse());
        }
    }
}