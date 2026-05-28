using ASP.NET10_Docker_K8s.Model;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET10_Docker_K8s.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController : ControllerBase
    {
        private static long _counter = 0;
        private static readonly string _content = "Hello, {0}";

        [HttpGet]
        public Greeting Get([FromQuery] string name = "World")
        {
            var id = Interlocked.Increment(ref _counter);
            var content = string.Format(_content, name);
            return new Greeting(id, content);
        }
    }
}
