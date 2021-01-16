using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace Fibonacci.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FibonacciController : ControllerBase
    {

        private readonly ILogger<FibonacciController> _logger;

        // Without Postman Number 0 is used to set up interface, default value, returns "true"
        private int Number = 0;
 

        public FibonacciController(ILogger<FibonacciController> logger)
        {
            _logger = logger;
        }

        // Test function for get values for Postman and for startup
        [HttpGet]
        public bool GetFibonacci(int number)
        {
            Number = number;
            return isFibonacci(Number);
        }

        // Actual interface for application UI, can be used also with Postman - "{\"number\":\"7\"}" - "raw, JSON"
        [HttpPost]
        public bool PostFibonacci([FromBody] dynamic data)
        {
            Object result = data;
            string value = Convert.ToString(result);
            dynamic stuff = JsonConvert.DeserializeObject(value);
            String exactValue = stuff.number;
            int number = Int32.Parse(exactValue);
            return isFibonacci(number);
        }

        // A utility function that returns 
        // true if x is perfect square 
        static bool isPerfectSquare(int x)
        {
            int s = (int)Math.Sqrt(x);
            return (s * s == x);
        }

        // Returns true if n is a  
        // Fibonacci Number, else false 
        static bool isFibonacci(int n)
        {
            // n is Fibonacci if one of 
            // 5*n*n + 4 or 5*n*n - 4 or  
            // both are a perfect square 
            return isPerfectSquare(5 * n * n + 4) ||
                   isPerfectSquare(5 * n * n - 4);
        }
    }
}
