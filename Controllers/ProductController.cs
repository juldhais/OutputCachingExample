using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace OutputCachingExample.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [OutputCache(PolicyName = "MasterData")]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            await Task.Delay(5000, ct);

            string[] response = ["Product 1", "Product 2", "Product 3"];

            return Ok(response);
        }
    }
}
