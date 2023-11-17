using Microsoft.AspNetCore.Mvc;
using OSA.FrontEnd.Api.DtoModels;
using OSA.FrontEnd.Api.Services.Interface;

namespace OSA.FrontEnd.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StarTrekController : ControllerBase
    {
        private readonly ICharacterService _characterDataService;
        private readonly IStarshipService _starshipDataService;

        public StarTrekController(ICharacterService characterDataService, IStarshipService starshipDataService)
        {
            _characterDataService = characterDataService;
            _starshipDataService = starshipDataService;
        }

        //I was a little unsure about the intent of the artificial delays, i assumed it meant you wanted to see if i understood async/await and thus have two
        //API call operations happening simultaneously, but remain non blocking if one was a longer running operations so i added this method.
        //Also it wasn't in the assessment spec to add Put and Delete, but I wanted to for fun to have a complete project to mess around with later if I want.

        // GET api/startrek
        [HttpGet]
        public async Task<IActionResult> GetAllData()
        {
            var characters = await _characterDataService.GetAllCharactersAsync(); //long running
            var starships = await _starshipDataService.GetAllStarshipsAsync();

            return Ok(new
            {
                Characters = characters,
                Starships = starships
            });
        }

        // Character Endpoints

        // GET api/startrek/characters
        [HttpGet("characters")]
        public async Task<IActionResult> GetAllCharacters()
        {
            var characters = await _characterDataService.GetAllCharactersAsync();
            return Ok(characters);
        }

        // GET api/startrek/characters/{id}
        [HttpGet("characters/{id}")]
        public async Task<IActionResult> GetCharacter(int id)
        {
            var character = await _characterDataService.GetCharacterAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            return Ok(character);
        }

        // POST api/startrek/characters
        [HttpPost("characters")]
        public async Task<IActionResult> AddCharacter([FromBody] StarTrekCharacterDto characterDto)
        {
            var character = await _characterDataService.AddCharacterAsync(characterDto);
            if (character == null)
            {
                return StatusCode(500, "An error occurred while creating the character.");
            }
            return CreatedAtAction(nameof(GetCharacter), new { id = character.Id }, character);
        }

        // PUT api/startrek/characters/{id}
        [HttpPut("characters/{id}")]
        public async Task<IActionResult> UpdateCharacter(int id, [FromBody] StarTrekCharacterDto characterDto)
        {
            var success = await _characterDataService.UpdateCharacterAsync(id, characterDto);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/startrek/characters/{id}
        [HttpDelete("characters/{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var success = await _characterDataService.DeleteCharacterAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        // Starship Endpoints

        // GET api/startrek/starships
        [HttpGet("starships")]
        public async Task<IActionResult> GetAllStarships()
        {
            var starships = await _starshipDataService.GetAllStarshipsAsync();
            return Ok(starships);
        }

        // GET api/startrek/starships/{id}
        [HttpGet("starships/{id}")]
        public async Task<IActionResult> GetStarship(int id)
        {
            var starship = await _starshipDataService.GetStarshipAsync(id);
            if (starship == null)
            {
                return NotFound();
            }
            return Ok(starship);
        }

        // POST api/startrek/starships
        [HttpPost("starships")]
        public async Task<IActionResult> AddStarship([FromBody] StarTrekStarshipDto starshipDto)
        {
            var starship = await _starshipDataService.AddStarshipAsync(starshipDto);
            if (starship == null)
            {
                return StatusCode(500, "An error occurred while creating the starship.");
            }
            return CreatedAtAction(nameof(GetStarship), new { id = starship.Id }, starship);
        }

        // PUT api/startrek/starships/{id}
        [HttpPut("starships/{id}")]
        public async Task<IActionResult> UpdateStarship(int id, [FromBody] StarTrekStarshipDto starshipDto)
        {
            var success = await _starshipDataService.UpdateStarshipAsync(id, starshipDto);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/startrek/starships/{id}
        [HttpDelete("starships/{id}")]
        public async Task<IActionResult> DeleteStarship(int id)
        {
            var success = await _starshipDataService.DeleteStarshipAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}