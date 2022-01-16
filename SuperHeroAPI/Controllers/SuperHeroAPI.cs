using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroAPI : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
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
                lastName = "Parker",
                place = "New York City",
                comic = "Marvel"
                }
        };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = heroes.Find(h => h.id == id);

            if (hero == null)
                return BadRequest("Hero not found.");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var hero = heroes.Find(h => h.id == request.id);

            if (hero == null)
                return BadRequest("Hero not found.");

            hero.name = request.name;
            hero.firstName = request.firstName;
            hero.lastName = request.lastName;   
            hero.place = request.place; 
            hero.comic = request.comic; 

            return Ok(heroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = heroes.Find(h => h.id == id);

            if (hero == null)
                return BadRequest("Hero not found.");

            heroes.Remove(hero);
            return Ok(heroes);
        }


    }
}
