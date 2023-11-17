using Microsoft.AspNetCore.Mvc;
using OSA.Backend.StarshipApi.Models;
using OSA.Backend.StarshipApi.Repositories;

namespace OSA.Backend.StarshipApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StarshipController : ControllerBase
    {
        private readonly IRepository<StarTrekStarship> repository;

        public StarshipController(IRepository<StarTrekStarship> repository)
        {
            this.repository = repository;
        }

        // GET: api/starship
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StarTrekStarship>>> GetAllStarships()
        {
            var starships = await repository.GetAllAsync();
            return Ok(starships);
        }

        // GET: api/starship/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<StarTrekStarship>> GetStarship(int id)
        {
            var starship = await repository.GetAsync(id);
            if (starship == null)
            {
                return NotFound();
            }
            return Ok(starship);
        }

        // POST: api/starship
        [HttpPost]
        public async Task<ActionResult<StarTrekStarship>> AddStarship([FromBody] StarTrekStarship starship)
        {
            var newStarship = await repository.AddAsync(starship);
            return CreatedAtAction(nameof(GetStarship), new { id = newStarship.Id }, newStarship);
        }

        // PUT: api/starship/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStarship(int id, [FromBody] StarTrekStarship starship)
        {
            var result = await repository.UpdateAsync(id, starship);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/starship/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStarship(int id)
        {
            var result = await repository.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}