using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using TestWebAPI.Models;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        // GET: api/Hero
        [HttpGet]
        public ActionResult<IEnumerable<Hero>> Get([FromQuery]string? name)
        {
            var heroes = MockHeroes.GetHeroes();
            if (name is not null)
            {
                heroes = heroes.Where(h => h.name.ToLower().Contains(name.ToLower()));
            }
            return heroes.ToList();
        }

        // GET: api/Hero/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Hero> Get(int id)
        {
            var hero = MockHeroes.GetHeroes().FirstOrDefault(h => h.id == id);
            if (hero is not null)
                return Ok(hero);
            
            return NotFound();
        }

        // POST: api/Hero
        [HttpPost]
        public ActionResult Post([FromBody] Hero hero)
        {
            if (hero.name is null)
                return NotFound();

            var newHero = MockHeroes.AddHero(hero);
            return Ok(newHero);
        }

        // PUT: api/Hero/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Hero hero)
        {
            var updateHero = MockHeroes.GetHeroes().FirstOrDefault(h => h.id == id);
            if (updateHero is null)
                return NotFound();

            var result = MockHeroes.UpdateHero(hero);

            return Ok(result);
        }

        // DELETE: api/Hero/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            MockHeroes.DeleteHero(id);

            return Ok();
        }
    }
}
