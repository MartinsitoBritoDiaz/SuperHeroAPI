using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroAPI : ControllerBase
    {
        //List of super heroes 
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

        private readonly DataContext _context;

        public SuperHeroAPI(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var dbhero = await _context.SuperHeroes.FindAsync(id);

            if (dbhero == null)
                return BadRequest("Hero not found.");

            return Ok(dbhero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var dbhero = await _context.SuperHeroes.FindAsync(request.id);

            if (dbhero == null)
                return BadRequest("Hero not found.");

            dbhero.name = request.name;
            dbhero.firstName = request.firstName;
            dbhero.lastName = request.lastName;   
            dbhero.place = request.place; 
            dbhero.comic = request.comic; 

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var dbhero = await _context.SuperHeroes.FindAsync(id);

            if (dbhero == null)
                return BadRequest("Hero not found.");

            _context.SuperHeroes.Remove(dbhero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }


    }
}
