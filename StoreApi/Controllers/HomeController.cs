using Microsoft.AspNetCore.Mvc;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet("hi")]
        public String Hello()
        {
            return "Hello World";
        }
        
        [HttpGet("students")]
        public string[] Students()
        {
            return new string[]
            {
            "Ahmet",
            "Mehmet",
            "Muhammed",
            "Nisa",
            "Tuna",
            "Abdullah"
            };
        }

    }
}