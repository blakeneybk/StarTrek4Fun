using Microsoft.AspNetCore.Mvc;
using OSA.Backend.CharacterApi.Models;
using OSA.Backend.CharacterApi.Repositories;

namespace OSA.Backend.CharacterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly IRepository<StarTrekCharacter> repository;

        public CharacterController(IRepository<StarTrekCharacter> repository)
        {
            this.repository = repository;
        }

        // GET: api/character
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StarTrekCharacter>>> GetAllCharacters()
        {
            var characters = await repository.GetAllAsync();
            return Ok(characters);
        }

        // GET: api/character/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<StarTrekCharacter>> GetCharacter(int id)
        {
            var character = await repository.GetAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            return Ok(character);
        }

        // POST: api/character
        [HttpPost]
        public async Task<ActionResult<StarTrekCharacter>> AddCharacter([FromBody] StarTrekCharacter character)
        {
            var addedCharacter = await repository.AddAsync(character);
            return CreatedAtAction(nameof(GetCharacter), new { id = addedCharacter.Id }, addedCharacter);
        }

        // PUT: api/character/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCharacter(int id, [FromBody] StarTrekCharacter character)
        {
            var result = await repository.UpdateAsync(id, character);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/character/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
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