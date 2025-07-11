using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using YoVPM.Yggdrasil.Core.Data;

namespace YoVPM.Yggdrasil.Api.Controllers
{
    [Route("database-test")]
    [ApiVersion("1.0")]
    [ApiController]
    public class DbTestController(YggdrasilDbContext dbContext) : ControllerBase
    {
        [HttpPost("create-database")]
        public async Task<IActionResult> CreateDatabase()
        {
            await dbContext.Database.EnsureCreatedAsync();

            return NoContent();
        }
    }
}
