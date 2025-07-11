using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using YoVPM.Yggdrasil.Core.Data;

namespace YoVPM.Yggdrasil.Api.Controlles
{
    [Route("test")]
    [ApiVersion("1.0")]
    [ApiController]
    public class TestController(YggdrasilDbContext dbContext) : ControllerBase
    {
        [HttpPost("create-database")]
        public async Task<IActionResult> CreateDatabase()
        {
            await dbContext.Database.EnsureCreatedAsync();

            return NoContent();
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("Pong");
        }
    }

    [Route("test")]
    [ApiVersion("2.0")]
    [ApiController]
    public class Test2Controller(YggdrasilDbContext dbContext) : ControllerBase
    {
        [HttpPost("create-database")]
        public async Task<IActionResult> CreateDatabase()
        {
            await dbContext.Database.EnsureCreatedAsync();

            return NoContent();
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("Pong 2");
        }

        [HttpGet("ping-v2only")]
        public IActionResult PingV2Only()
        {
            return Ok("Pong 2 Only");
        }
    }
}
