using Lekker.Kort.Interface;
using Moq;
using NUnit.Framework;
using System;

namespace Lekker.Kort.UTest.UrlModifierControllerTests
{
    public class when_constructing_url_modifier
    {
        [Test]
        public void with_a_valid_repo_and_idservice()
        {
            var repo = new Mock<IModifiedUrlRepository>().Object;
            var idService = new Mock<IIdService>().Object;

            var controller = new TestModifiedUrlController(repo, idService);

            Assert.NotNull(controller);
        }

        [Test]
        public void without_a_repo()
        {
            Assert.Throws<ArgumentNullException>(() => new TestModifiedUrlController(new Mock<IModifiedUrlRepository>().Object, null));
        }

        [Test]
        public void without_an_idservice()
        {
            Assert.Throws<ArgumentNullException>(() => new TestModifiedUrlController(null, new Mock<IIdService>().Object));
        }
    }
}