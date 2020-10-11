﻿using Lekker.Kort.Interface;
using Lekker.Kort.Models;
using Lekker.Kort.Models.Request;
using Lekker.Kort.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Lekker.Kort.Controllers
{
    public abstract class ModifiedUrlControllerBase : KortControllerBase
    {
        private readonly IIdService _idService;

        protected ModifiedUrlControllerBase(IModifiedUrlRepository kortRepository, IIdService idService) : base(kortRepository)
        {
            _idService = idService;
        }

        [HttpPost]
        public async Task<ActionResult<ShortUrlResponse>> AddShortUrlAsync([Required] ShortenUrlRequest url, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(url.Url))
            {
                return BadRequest("Invalid URL");
            }

            var uniqueKey = await _idService.GetUniqueId(cancellationToken)
                                            .ConfigureAwait(false);

            var shortUrl = await GetShortenedUrlRepository()
                                    .AddShortenedUrl(uniqueKey, Uri.UnescapeDataString(url.Url), cancellationToken)
                                    .ConfigureAwait(false);

            return Ok(shortUrl.ToShortUrlResponse());
        }

        [HttpGet("{modifiedUrl}")]
        public async Task<ActionResult<OriginalUrlResponse>> GetOriginalUrl([Required, FromRoute] string modifiedUrl, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(modifiedUrl))
            {
                return BadRequest("Invalid URL");
            }

            var originalUrl = await GetShortenedUrlRepository()
                                        .GetOriginalUrl(modifiedUrl, cancellationToken)
                                        .ConfigureAwait(false);

            return Ok(originalUrl.ToOriginalUrlResponse());
        }
    }
}