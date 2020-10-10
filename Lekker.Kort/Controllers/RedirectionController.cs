using Lekker.Kort.Interface;
using Lekker.Kort.Models;
using Lekker.Kort.Models.Request;
using Lekker.Kort.Models.Response;
using Lekker.Kort.Repository.Context;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Lekker.Kort.Controllers
{
    [ApiController]
    [Route("r")]
    public class RedirectionController : KortControllerBase
    {
        public RedirectionController(IShortUrlRepository kortRepository) : base(kortRepository)
        {
        }


        [HttpGet("{shortUrl}")]
        public async Task<ActionResult> GetOriginalUrl([Required, FromRoute] string shortUrl, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(shortUrl))
            {
                return BadRequest("Invalid URL");
            }

            var originalUrl = await GetShortenedUrlRepository()
                                        .GetOriginalUrl(shortUrl, cancellationToken)
                                        .ConfigureAwait(false);

            return Redirect(originalUrl.ToOriginalUrlResponse().OriginalUrl);
        }
    }
}