using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroAPI : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            var heroes = new List<SuperHero>
            {
                new SuperHero{
                    id = 1,
                    name = "Batman",
                    firstName = "Bruce",
                    lastName = "Wayne",
                    place = "Gothan City",
                    comic = "DC"
                },                
                new SuperHero{ 
                    id = 2, 
                    name = "Spiderman", 
                    firstName = "Peter", 
                    lastName = "Parked", 
                    place = "New York City",
                    comic = "Marvel"
                 }
            };

            return Ok(heroes);
        }
    }
}
