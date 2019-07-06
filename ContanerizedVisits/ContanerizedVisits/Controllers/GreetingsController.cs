using Microsoft.AspNetCore.Mvc;

namespace ContanerizedVisits.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {

        [HttpGet]
        public string Greetings()
        {
            return "Greetings developer! I´m a contanerized API :)";
        }
    }
}