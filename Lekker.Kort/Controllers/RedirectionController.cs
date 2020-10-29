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
        public async Task<ActionResult> RedirectoToOriginalUrl([Required, FromRoute] string modifiedUrl, [FromQuery] string uid, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(modifiedUrl))
            {
                return BadRequest("Invalid URL");
            }

            try
            {
                if (string.IsNullOrEmpty(uid))
                {
                    uid = "Unknown";
                }
                var originalUrl = await GetRepository()
                                        .ResolveUrl(modifiedUrl, uid, cancellationToken)
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