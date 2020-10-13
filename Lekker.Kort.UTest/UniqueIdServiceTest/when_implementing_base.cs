using Lekker.Kort.Controllers;
using Lekker.Kort.Interface;
using Lekker.Kort.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Lekker.Kort.UTest.UniqueIdServiceTest
{
    public class when_implementing_base
    {
        [Test]
        public void with_lekker_controller()
        {
            var repo = new Mock<IModifiedUrlRepository>().Object;
            var indexService = new Mock<IIndexService>().Object;
            var logger = new Mock<ILogger<LekkerIdService>>().Object;
            var lekkerService = new LekkerIdService(logger, indexService);

            var controller = new LekkerUrlController(repo, lekkerService);
            Assert.NotNull(controller);
        }

        [Test]
        public void with_shorturl_controller()
        {
            var repo = new Mock<IModifiedUrlRepository>().Object;
            var indexService = new Mock<IIndexService>().Object;
            var logger = new Mock<ILogger<UniqueIdService>>().Object;
            var lekkerService = new UniqueIdService(logger, indexService);

            var controller = new ShortUrlController(repo, lekkerService);
            Assert.NotNull(controller);
        }
    }
}