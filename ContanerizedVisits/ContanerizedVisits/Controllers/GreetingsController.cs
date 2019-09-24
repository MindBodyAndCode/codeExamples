using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;

namespace ContanerizedVisits.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {
        private readonly IDistributedCache _distributedCache;
        private string visitsKey = "visitsCount";

        public GreetingsController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));

            var numVisitsString = _distributedCache.GetString(visitsKey);

            if (string.IsNullOrWhiteSpace(numVisitsString))
            {
                _distributedCache.SetString(visitsKey, "0");
            }
            else
            if (int.TryParse(numVisitsString, out var numVisits))
            {
                numVisits++;
                _distributedCache.SetString(visitsKey, numVisits.ToString());
            }
        }

        [HttpGet]
        public async Task<string> Greetings()
        {
            var visitsCount = await _distributedCache.GetStringAsync(visitsKey);

            return $"Greetings developer! I´m a contanerized API :)  Visits: {visitsCount}";
        }

        [HttpGet("who-are-u")]
        public async Task<string> Identify()
        {
            var visitsCount = await _distributedCache.GetStringAsync(visitsKey);

            return $"My name is {System.Environment.GetEnvironmentVariable("HOSTNAME")} Visits: {visitsCount}";
        }

        [HttpGet("boom")]
        public void Exception()
        {
            System.Environment.Exit(-1);
        }

    }
}