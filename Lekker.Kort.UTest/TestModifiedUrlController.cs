using Lekker.Kort.Controllers;
using Lekker.Kort.Interface;

namespace Lekker.Kort.UTest
{
    public class TestModifiedUrlController : ModifiedUrlControllerBase
    {
        public TestModifiedUrlController(IModifiedUrlRepository kortRepository, IIdService idService) : base(kortRepository, idService)
        {
        }
    }
}