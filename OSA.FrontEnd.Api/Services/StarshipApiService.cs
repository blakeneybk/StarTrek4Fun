using OSA.Backend.StarshipApi.Client;
using OSA.Backend.StarshipApi.Client.DtoModels;
using OSA.FrontEnd.Api.DtoModels;
using OSA.FrontEnd.Api.Services.Interface;

namespace OSA.FrontEnd.Api.Services
{
    /// <summary>
    /// An implementation of IStarshipService that utilizes the client library client service provided for consuming the StarshipApi
    /// </summary>
    /// <seealso cref="OSA.FrontEnd.Api.Services.Interface.IStarshipService" />
    public class StarshipApiService : IStarshipService
    {
        private readonly IStarshipApiClientService client;

        public StarshipApiService(IStarshipApiClientService client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<StarTrekStarshipDto>?> GetAllStarshipsAsync()
        {
            var apiStarships = await client.GetAllStarshipsAsync();
            return apiStarships?.Select(MapToStarshipDto);
        }

        public async Task<StarTrekStarshipDto?> GetStarshipAsync(int id)
        {
            var apiStarship = await client.GetStarshipAsync(id);
            return apiStarship != null ? MapToStarshipDto(apiStarship) : null;
        }

        public async Task<StarTrekStarshipDto?> AddStarshipAsync(StarTrekStarshipDto starship)
        {
            var apiStarship = MapToStarshipApiDto(starship);
            var addedApiStarship = await client.AddStarshipAsync(apiStarship);
            return addedApiStarship != null ? MapToStarshipDto(addedApiStarship) : null;
        }

        public async Task<bool> UpdateStarshipAsync(int id, StarTrekStarshipDto starship)
        {
            var apiStarship = MapToStarshipApiDto(starship);
            return await client.UpdateStarshipAsync(id, apiStarship);
        }

        public async Task<bool> DeleteStarshipAsync(int id)
        {
            return await client.DeleteStarshipAsync(id);
        }

        // Mapping from back-end API DTO to front-end DTO
        private StarTrekStarshipDto MapToStarshipDto(StarTrekStarshipApiDto apiDto)
        {
            return new StarTrekStarshipDto
            {
                Id = apiDto.Id,
                Name = apiDto.Name,
                Class = apiDto.Class,
                Registry = apiDto.Registry,
                Captain = apiDto.Captain
            };
        }

        // Mapping from front-end DTO to back-end API DTO
        private StarTrekStarshipApiDto MapToStarshipApiDto(StarTrekStarshipDto dto)
        {
            return new StarTrekStarshipApiDto
            {
                Id = dto.Id,
                Name = dto.Name,
                Class = dto.Class,
                Registry = dto.Registry,
                Captain = dto.Captain
            };
        }
    }
}