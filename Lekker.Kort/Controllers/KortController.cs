using Lekker.Kort.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Lekker.Kort.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KortController : KortControllerBase
    {
        public KortController(IKortRepository kortRepository) : base(kortRepository)
        {
        }

        [HttpGet]
        public string Get()
        {
            var repo = GetKortRepo();
            return "Awe!";
        }
    }
}