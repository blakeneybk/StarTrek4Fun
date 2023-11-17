using OSA.FrontEnd.Api.DtoModels;

namespace OSA.FrontEnd.Api.Services.Interface
{
    public interface ICharacterService
    {
        Task<IEnumerable<StarTrekCharacterDto>?> GetAllCharactersAsync();
        Task<StarTrekCharacterDto?> GetCharacterAsync(int id);
        Task<StarTrekCharacterDto?> AddCharacterAsync(StarTrekCharacterDto character);
        Task<bool> UpdateCharacterAsync(int id, StarTrekCharacterDto character);
        Task<bool> DeleteCharacterAsync(int id);
    }
}