using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using TestWebAPI.Models;
using TestWebAPI.Repository;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly IRepository<Hero> _repository;

        public HeroController(IRepository<Hero> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<Hero>> GetAsync([FromQuery] string? id, [FromQuery] string? name)
        {
            if (id is not null)
            {
                var hero = await _repository.GetAsync(Guid.Parse(id));
                return Ok(hero);
            }

            if (name is not null)
            {
                var hero = await _repository.GetAllAsync();
                var heroFiltered = hero.Where(h => h.Name.ToLower().Contains(name.ToLower()));
                return Ok(heroFiltered);
            }

            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        // POST: api/Hero
        [HttpPost]
        public async Task<ActionResult<Hero>> Post([FromBody] Hero hero)
        {
            if (hero.Name is null)
                return NotFound();

            var newHero = new Hero(Guid.NewGuid(),hero.Name);
            await _repository.CreateAsync(newHero);
            
            var actionName = nameof(GetAsync);
            // return Ok(CreatedAtAction(actionName, new {id = newHero.Id}, newHero));
            return Ok(newHero);
        }

        // PUT: api/Hero/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody] Hero hero)
        {
            var existingHero = await _repository.GetAsync(hero.Id);
            if (existingHero is null) return NotFound();

            existingHero.Name = hero.Name;
            await _repository.UpdateAsync(existingHero);

            return NoContent();
        }

        // DELETE: api/Hero/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var existingHero = _repository.GetAsync(Guid.Parse(id));
            if (existingHero is null) return NotFound();

            await _repository.RemoveAsync(Guid.Parse(id));
            return NoContent();
        }
    }
}
