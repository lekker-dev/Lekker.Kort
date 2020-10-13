using Lekker.Kort.Interface;
using Lekker.Kort.Interface.DTO;
using Lekker.Kort.Models.Request;
using Lekker.Kort.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lekker.Kort.UTest.UrlModifierControllerTests
{
    public class when_posting_a_url
    {
        [Test]
        public async Task with_an_empty_url()
        {
            var repo = new Mock<IModifiedUrlRepository>().Object;
            var idService = new Mock<IIdService>().Object;

            var controller = new TestModifiedUrlController(repo, idService);

            var req = new ShortenUrlRequest() { Url = "" };
            var result = (await controller.AddShortUrlAsync(req).ConfigureAwait(false)).Result as BadRequestObjectResult;

            Assert.NotNull(result);
        }

        [Test]
        public async Task with_a_valid_url()
        {
            var idService = new Mock<IIdService>();
            var uniqueId = Guid.NewGuid().ToString();
            idService.Setup(id => id.GetUniqueId(It.IsAny<CancellationToken>()))
                     .ReturnsAsync(uniqueId);

            var repo = new Mock<IModifiedUrlRepository>();
            var response = new ModifiedUrlResponse() { ShortUrl = uniqueId };
            repo.Setup(rep => rep.AddShortenedUrl(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var controller = new TestModifiedUrlController(repo.Object, idService.Object);

            var req = new ShortenUrlRequest() { Url = $"http://{Guid.NewGuid()}" };

            var result = (await controller.AddShortUrlAsync(req).ConfigureAwait(false)).Result as OkObjectResult;
            Assert.NotNull(result);

            var value = result.Value as ShortUrlResponse;
            Assert.NotNull(value);

            Assert.AreEqual(uniqueId, value.ShortUrl);
        }
    }
}