using Lekker.Kort.Interface;
using Lekker.Kort.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lekker.Kort.UTest.UniqueIdServiceTest
{
    public class when_getting_unique_id
    {
        [Test]
        public async Task with_a_fixed_value()
        {
            var item = "5";
            var idService = new Mock<IIndexService>();

            idService.Setup(i => i.GetNextIndex(It.IsAny<CancellationToken>()))
                     .ReturnsAsync(5);

            var logger = new Mock<ILogger<UniqueIdService>>().Object;
            var service = new UniqueIdService(logger, idService.Object);

            var id = await service.GetUniqueId(default).ConfigureAwait(false);
            Assert.AreEqual(item, id);

            // get the same fixed item again and ensure we are deterministic (same char always gives same result)
            id = await service.GetUniqueId(default).ConfigureAwait(false);
            Assert.AreEqual(item, id);
        }

        [Test]
        public async Task with_a_range_of_values_x10000()
        {
            var logger = new Mock<ILogger<UniqueIdService>>().Object;
            var service = new UniqueIdService(logger, new TestIdService());

            var ids = new HashSet<string>();

            for (int i = 0; i < 10000; i++)
            {
                if (!ids.Add(await service.GetUniqueId(default).ConfigureAwait(false)))
                {
                    Assert.Fail("Duplicate ID generated");
                }
            }
        }
    }
}