using OSA.Backend.CharacterApi.Client.DtoModels;

namespace OSA.Backend.CharacterApi.Client
{
    public interface ICharacterApiClientService
    {
        Task<IEnumerable<StarTrekCharacterApiDto>?> GetAllCharactersAsync();
        Task<StarTrekCharacterApiDto?> GetCharacterAsync(int id);
        Task<StarTrekCharacterApiDto?> AddCharacterAsync(StarTrekCharacterApiDto character);
        Task<bool> UpdateCharacterAsync(int id, StarTrekCharacterApiDto character);
        Task<bool> DeleteCharacterAsync(int id);
    }
}