using Lekker.Kort.Interface;
using Lekker.Kort.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;

namespace Lekker.Kort.UTest.UniqueIdServiceTest
{
    public class when_constructing_unique_idservice
    {
        [Test]
        public void with_a_valid_repo_and_logger()
        {
            var idService = new Mock<IIndexService>().Object;
            var logger = new Mock<ILogger<UniqueIdService>>().Object;

            var service = new UniqueIdService(logger, idService);

            Assert.NotNull(service);
        }

        [Test]
        public void with_a_valid_repo_and_no_logger()
        {
            var idService = new Mock<IIndexService>().Object;
            Assert.Throws<ArgumentNullException>(() => new UniqueIdService(null, idService));
        }

        [Test]
        public void with_a_no_repo_and_logger()
        {
            var logger = new Mock<ILogger<UniqueIdService>>().Object;
            Assert.Throws<ArgumentNullException>(() => new UniqueIdService(logger, null));
        }
    }
}