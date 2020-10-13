using Lekker.Kort.Interface;
using Lekker.Kort.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;

namespace Lekker.Kort.UTest.LekkerIdServiceTest
{
    public class when_constructing_lekker_idservice
    {
        [Test]
        public void with_a_valid_repo_and_logger()
        {
            var idService = new Mock<IIndexService>().Object;
            var logger = new Mock<ILogger<LekkerIdService>>().Object;

            var service = new LekkerIdService(logger, idService);

            Assert.NotNull(service);
        }

        [Test]
        public void with_a_valid_repo_and_no_logger()
        {
            var idService = new Mock<IIndexService>().Object;
            Assert.Throws<ArgumentNullException>(() => new LekkerIdService(null, idService));
        }

        [Test]
        public void with_a_no_repo_and_logger()
        {
            var logger = new Mock<ILogger<LekkerIdService>>().Object;
            Assert.Throws<ArgumentNullException>(() => new LekkerIdService(logger, null));
        }
    }
}