using OSA.Backend.StarshipApi.Client.DtoModels;

namespace OSA.Backend.StarshipApi.Client
{
    public interface IStarshipApiClientService
    {
        Task<IEnumerable<StarTrekStarshipApiDto>?> GetAllStarshipsAsync();
        Task<StarTrekStarshipApiDto?> GetStarshipAsync(int id);
        Task<StarTrekStarshipApiDto?> AddStarshipAsync(StarTrekStarshipApiDto starship);
        Task<bool> UpdateStarshipAsync(int id, StarTrekStarshipApiDto starship);
        Task<bool> DeleteStarshipAsync(int id);
    }
}