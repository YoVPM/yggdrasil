using Microsoft.AspNetCore.Mvc;
using YoVPM.Yggdrasil.Core.Data;

namespace YoVPM.Yggdrasil.Api.Controlles
{
    [Route("api/test")]
    [ApiController]
    public class TestController(YggdrasilDbContext dbContext) : ControllerBase
    {
        [HttpPost("create-database")]
        public async Task<IActionResult> CreateDatabase()
        {
            await dbContext.Database.EnsureCreatedAsync();

            return NoContent();
        }
    }
}
