using Lekker.Kort.Controllers;
using Lekker.Kort.Interface;
using Lekker.Kort.Interface.DTO;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lekker.Kort.UTest.RedirectionControllerTests
{
    public class when_getting_a_redirection
    {
        [Test]
        public async Task with_a_valid_url()
        {
            var repo = new Mock<IModifiedUrlRepository>();
            var response = new OriginalUrlResponseDto() { OriginalUrl = $"http://{Guid.NewGuid()}" };
            repo.Setup(r => r.ResolveUrl(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var controller = new RedirectionController(repo.Object);

            var result = await controller
                                    .RedirectoToOriginalUrl(Guid.NewGuid().ToString())
                                    .ConfigureAwait(false) as RedirectResult;

            Assert.NotNull(result);
            Assert.IsTrue(result.Url == response.OriginalUrl);
        }

        [Test]
        public async Task with_an_invalid_url()
        {
            var repo = new Mock<IModifiedUrlRepository>();

            repo.Setup(r => r.ResolveUrl(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new InvalidOperationException());

            var controller = new RedirectionController(repo.Object);

            var result = await controller
                                  .RedirectoToOriginalUrl(Guid.NewGuid().ToString())
                                  .ConfigureAwait(false) as RedirectResult;

            Assert.NotNull(result);
            Assert.IsTrue(result.Url == "/error");
        }

        [Test]
        public async Task with_a_blank_url()
        {
            var repo = new Mock<IModifiedUrlRepository>();
            var controller = new RedirectionController(repo.Object);

            var result = await controller
                                  .RedirectoToOriginalUrl("")
                                  .ConfigureAwait(false) as BadRequestObjectResult;

            Assert.NotNull(result);
        }
    }
}