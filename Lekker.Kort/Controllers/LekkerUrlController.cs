using Lekker.Kort.Interface;
using Lekker.Kort.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lekker.Kort.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LekkerUrlController : ModifiedUrlControllerBase
    {
        public LekkerUrlController(IModifiedUrlRepository kortRepository, LekkerIdService lekkerIdService) : base(kortRepository, lekkerIdService)
        {
        }
    }
}