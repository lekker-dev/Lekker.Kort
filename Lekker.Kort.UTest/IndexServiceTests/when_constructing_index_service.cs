using Castle.Core.Logging;
using Lekker.Kort.Interface;
using Lekker.Kort.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;

namespace Lekker.Kort.UTest.IndexServiceTests
{
    public class when_constructing_index_service
    {
        [Test]
        public void with_a_valid_repo_and_logger()
        {
            var repo = new Mock<IModifiedUrlRepository>().Object;
            var logger = new Mock<ILogger<IndexService>>().Object;

            var service = new IndexService(logger, repo);

            Assert.NotNull(service);
        }

        [Test]
        public void with_a_valid_repo_and_no_logger()
        {
            var repo = new Mock<IModifiedUrlRepository>().Object;

            Assert.Throws<ArgumentNullException>(() => new IndexService(null, repo));
        }

        [Test]
        public void with_a_no_repo_and_valid_logger()
        {
            var logger = new Mock<ILogger<IndexService>>().Object;

            Assert.Throws<ArgumentNullException>(() => new IndexService(logger, null));
        }
    }
}