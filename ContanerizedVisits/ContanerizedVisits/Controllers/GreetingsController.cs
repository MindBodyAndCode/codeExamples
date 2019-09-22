using Microsoft.AspNetCore.Mvc;
using System;

namespace ContanerizedVisits.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {

        private string _identifier;

        private string[] _names = new string[10] { "Juan", "Marta", "Pedro", "Raul", "Ramón", "Fran", "Antonio", "Javi", "Edu", "Carmine" };

        public GreetingsController()
        {
            int rnd = new Random().Next(0, 9);
            _identifier = _names[rnd];
        }

        [HttpGet]
        public string Greetings()
        {
            return "Greetings developer! I´m a contanerized API :)";
        }

        [HttpGet("who-are-u")]
        public string Identify()
        {
            return "My name is " + _identifier;
        }

        [HttpGet("boom")]
        public void Exception()
        {
            System.Environment.Exit(-1);
        }

    }
}