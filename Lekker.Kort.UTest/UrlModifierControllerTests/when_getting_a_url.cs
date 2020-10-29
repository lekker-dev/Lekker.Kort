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
    public class when_getting_a_url
    {
        [Test]
        public async Task with_an_empty_url()
        {
            var repo = new Mock<IModifiedUrlRepository>().Object;
            var idService = new Mock<IIdService>().Object;

            var controller = new TestModifiedUrlController(repo, idService);

            var result = (await controller.GetOriginalUrl("").ConfigureAwait(false)).Result as BadRequestObjectResult;

            Assert.NotNull(result);
        }

        [Test]
        public async Task with_a_valid_url()
        {
            var repo = new Mock<IModifiedUrlRepository>();
            var response = new OriginalUrlResponseDto() { OriginalUrl = Guid.NewGuid().ToString() };
            repo.Setup(rep => rep.ResolveUrl(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var controller = new TestModifiedUrlController(repo.Object, new Mock<IIdService>().Object);

            var result = (await controller.GetOriginalUrl(Guid.NewGuid().ToString()).ConfigureAwait(false)).Result as OkObjectResult;
            Assert.NotNull(result);

            var value = result.Value as OriginalUrlResponse;
            Assert.NotNull(value);

            Assert.AreEqual(response.OriginalUrl, value.OriginalUrl);
        }
    }
}