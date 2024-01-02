using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace OutputCachingExample.Controllers
{
    [ApiController]
    [Route("reports")]
    public class ReportController : ControllerBase
    {
        [HttpGet]
        [OutputCache(PolicyName = "reports")]
        public async Task<IActionResult> Get(int year, int month, CancellationToken ct)
        {
            await Task.Delay(5000, ct);

            var response = new
            {
                year,
                month,
            };

            return Ok(response);
        }
    }
}
