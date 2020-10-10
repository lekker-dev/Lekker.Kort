using Lekker.Kort.Interface;
using Lekker.Kort.Models;
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
        public RedirectionController(IModifiedUrlRepository kortRepository) : base(kortRepository)
        {
        }

        [HttpGet("{modifiedUrl}")]
        public async Task<ActionResult> RedirectTo([Required, FromRoute] string modifiedUrl, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(modifiedUrl))
            {
                return BadRequest("Invalid URL");
            }

            var originalUrl = await GetShortenedUrlRepository()
                                        .GetOriginalUrl(modifiedUrl, cancellationToken)
                                        .ConfigureAwait(false);

            return Redirect(originalUrl.OriginalUrl);
        }
    }
}