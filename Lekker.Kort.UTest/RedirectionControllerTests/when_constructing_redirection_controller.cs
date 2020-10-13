using Lekker.Kort.Controllers;
using Lekker.Kort.Interface;
using Moq;
using NUnit.Framework;
using System;

namespace Lekker.Kort.UTest.RedirectionControllerTests
{
    public class when_constructing_redirection_controller
    {
        [Test]
        public void with_a_valid_repo()
        {
            var repo = new Mock<IModifiedUrlRepository>().Object;

            var controller = new RedirectionController(repo);

            Assert.NotNull(controller);
        }

        [Test]
        public void without_a_repo()
        {
            Assert.Throws<ArgumentNullException>(() => new RedirectionController(null));
        }
    }
}