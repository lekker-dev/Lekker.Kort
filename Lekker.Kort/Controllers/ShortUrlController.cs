using Lekker.Kort.Interface;
using Lekker.Kort.Models;
using Lekker.Kort.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Lekker.Kort.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShortUrlController : KortControllerBase
    {
        public ShortUrlController(IShortUriRepository kortRepository) : base(kortRepository)
        {
        }

        [HttpPost("{url}")]
        public async Task<ActionResult<ShortUrlResponse>> AddShortUrlAsync([Required, FromRoute] string url, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return BadRequest("Invalid URL");
            }

            var shortUrl = await GetShortenedUrlRepository()
                                    .AddShortenedUrl(System.Uri.UnescapeDataString(url), cancellationToken)
                                    .ConfigureAwait(false);

            return Ok(shortUrl.ToShortUrlResponse());
        }

        [HttpGet("{shortUrl}")]
        public async Task<ActionResult<OriginalUrlResponse>> GetOriginalUrl([Required, FromRoute] string shortUrl, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(shortUrl))
            {
                return BadRequest("Invalid URL");
            }

            var originalUrl = await GetShortenedUrlRepository()
                                        .GetOriginalUrl(shortUrl, cancellationToken)
                                        .ConfigureAwait(false);

            return Ok(originalUrl.ToOriginalUrlResponse());
        }
    }
}