using Lekker.Kort.Interface;
using Lekker.Kort.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lekker.Kort.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShortUrlController : ModifiedUrlControllerBase
    {
        public ShortUrlController(IModifiedUrlRepository kortRepository, UniqueIdService uniqueIdService) : base(kortRepository, uniqueIdService)
        {
        }
    }
}