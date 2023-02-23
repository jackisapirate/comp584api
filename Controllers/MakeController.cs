using Microsoft.AspNetCore.Mvc;

namespace comp584api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MakeController : ControllerBase
    {
        private static readonly string[] Makes = new[]
        {
        "Toyota", "BMW", "Chevrolet", "Honda", "Nissan", "Jeep", "BYD"
        };

        private readonly ILogger<MakeController> _logger;

        public MakeController(ILogger<MakeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetMakes")]
        public IEnumerable<Make> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Make
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                name = Makes[Random.Shared.Next(Makes.Length)]
            })
            .ToArray();
        }
    }
}