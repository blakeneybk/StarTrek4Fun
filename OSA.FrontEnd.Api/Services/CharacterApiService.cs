using OSA.Backend.CharacterApi.Client;
using OSA.Backend.CharacterApi.Client.DtoModels;
using OSA.FrontEnd.Api.DtoModels;
using OSA.FrontEnd.Api.Services.Interface;

namespace OSA.FrontEnd.Api.Services
{
    /// <summary>
    /// An implementation of ICharacterService that utilizes the client library client service provided for consuming the CharacterApi
    /// </summary>
    /// <seealso cref="OSA.FrontEnd.Api.Services.Interface.ICharacterService" />
    public class CharacterApiService : ICharacterService
    {
        private readonly ICharacterApiClientService client;

        public CharacterApiService(ICharacterApiClientService client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<StarTrekCharacterDto>?> GetAllCharactersAsync()
        {
            var apiDtos = await client.GetAllCharactersAsync();
            return apiDtos?.Select(MapToCharacterDto);
        }

        public async Task<StarTrekCharacterDto?> GetCharacterAsync(int id)
        {
            var apiDto = await client.GetCharacterAsync(id);
            return apiDto != null ? MapToCharacterDto(apiDto) : null;
        }

        public async Task<StarTrekCharacterDto?> AddCharacterAsync(StarTrekCharacterDto character)
        {
            var apiDto = MapToCharacterApiDto(character);
            var addedApiDto = await client.AddCharacterAsync(apiDto);
            return addedApiDto != null ? MapToCharacterDto(addedApiDto) : null;
        }

        public async Task<bool> UpdateCharacterAsync(int id, StarTrekCharacterDto character)
        {
            var apiDto = MapToCharacterApiDto(character);
            return await client.UpdateCharacterAsync(id, apiDto);
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            return await client.DeleteCharacterAsync(id);
        }

        // Mapping from back-end API DTO to front-end DTO
        private StarTrekCharacterDto MapToCharacterDto(StarTrekCharacterApiDto apiDto)
        {
            return new StarTrekCharacterDto
            {
                Id = apiDto.Id,
                Name = apiDto.Name,
                Rank = apiDto.Rank,
                Species = apiDto.Species,
                Assignment = apiDto.Assignment
            };
        }

        // Mapping from front-end DTO to back-end API DTO
        private StarTrekCharacterApiDto MapToCharacterApiDto(StarTrekCharacterDto dto)
        {
            return new StarTrekCharacterApiDto
            {
                Id = dto.Id,
                Name = dto.Name,
                Rank = dto.Rank,
                Species = dto.Species,
                Assignment = dto.Assignment
            };
        }
    }
}