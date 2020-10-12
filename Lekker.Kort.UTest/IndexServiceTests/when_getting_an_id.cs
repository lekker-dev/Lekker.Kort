using Lekker.Kort.Interface;
using Lekker.Kort.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lekker.Kort.UTest.IndexServiceTests
{
    public class when_getting_an_id
    {
        [Test]
        public async Task when_getting_and_waiting()
        {
            var repo = new Mock<IModifiedUrlRepository>();
            repo.Setup(r => r.GetLastIndex(It.IsAny<CancellationToken>()))
                .ReturnsAsync(7);

            var service = new IndexService(new Mock<ILogger<IndexService>>().Object, repo.Object);

            var index = await service.GetNextIndex(default).ConfigureAwait(false);
            Assert.AreEqual(8, index);

            index = await service.GetNextIndex(default).ConfigureAwait(false);
            Assert.AreEqual(9, index);

            index = await service.GetNextIndex(default).ConfigureAwait(false);
            Assert.AreEqual(10, index);
        }

        [Test]
        public async Task when_getting_x10000()
        {
            var repo = new Mock<IModifiedUrlRepository>();
            repo.Setup(r => r.GetLastIndex(It.IsAny<CancellationToken>()))
                .ReturnsAsync(10);

            var service = new IndexService(new Mock<ILogger<IndexService>>().Object, repo.Object);

            const int threads = 10000;
            var tasks = new List<Task>();
            for (int i = 0; i < threads; i++)
            {
                tasks.Add(service.GetNextIndex(default));
            }

            Task.WaitAll(tasks.ToArray());

            var index = await service.GetNextIndex(default).ConfigureAwait(false);
            Assert.AreEqual(threads + 11, index);
        }
    }
}