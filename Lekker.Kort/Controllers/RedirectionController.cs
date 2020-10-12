using Lekker.Kort.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
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

            try
            {
                var originalUrl = await GetShortenedUrlRepository()
                                        .GetOriginalUrl(shortUrl, cancellationToken)
                                        .ConfigureAwait(false);

                return Redirect(originalUrl.OriginalUrl);
            }
            catch (InvalidOperationException)
            {
                return Redirect("/error");
            }
        }
    }
}