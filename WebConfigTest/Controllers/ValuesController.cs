using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebConfigTest.ConfigTest;

namespace WebConfigTest.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IOptions<MyConfig> _config;
        private readonly IHostingEnvironment _env;

        public ValuesController(IOptions<MyConfig> config, IHostingEnvironment env)
        {
            _config = config;
            _env = env;
        }

        [HttpGet]
        public string Get()
        {
            var environment = _env.IsDevelopment() ? "Development" : "Test";
            return $"{_config.Value.WhoIsTheBoss} is the boss in the {environment} environment!";
        }
    }
}
