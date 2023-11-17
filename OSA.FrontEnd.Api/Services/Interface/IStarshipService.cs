using OSA.FrontEnd.Api.DtoModels;

namespace OSA.FrontEnd.Api.Services.Interface;

public interface IStarshipService
{
    Task<IEnumerable<StarTrekStarshipDto>?> GetAllStarshipsAsync();
    Task<StarTrekStarshipDto?> GetStarshipAsync(int id);
    Task<StarTrekStarshipDto?> AddStarshipAsync(StarTrekStarshipDto starship);
    Task<bool> UpdateStarshipAsync(int id, StarTrekStarshipDto starship);
    Task<bool> DeleteStarshipAsync(int id);
}