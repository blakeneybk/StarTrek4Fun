using System.Net.Http.Json;
using OSA.Backend.CharacterApi.Client.DtoModels;

namespace OSA.Backend.CharacterApi.Client
{
    /// <summary>
    /// A client service to be used by API consumers to communicate with CharacterApi
    /// </summary>
    /// <seealso cref="OSA.Backend.CharacterApi.Client.ICharacterApiClientService" />
    public class CharacterApiClientService : ICharacterApiClientService
    {
        private readonly HttpClient _httpClient;

        //This is to be accessible to consuimers of the client to give them a default option that they can use or override
        public static readonly Uri DefaultBaseAddress = new Uri("https://localhost:51001/api/");

        public CharacterApiClientService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        //GET api/character
        public async Task<IEnumerable<StarTrekCharacterApiDto>?> GetAllCharactersAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<StarTrekCharacterApiDto>>("character");
        }

        //GET api/character/{id}
        public async Task<StarTrekCharacterApiDto?> GetCharacterAsync(int id)
        {
            var response = await _httpClient.GetAsync($"character/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<StarTrekCharacterApiDto>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                response.EnsureSuccessStatusCode();
                return null;
            }
        }

        //POST api/character with body
        public async Task<StarTrekCharacterApiDto?> AddCharacterAsync(StarTrekCharacterApiDto character)
        {
            var response = await _httpClient.PostAsJsonAsync("character", character);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<StarTrekCharacterApiDto>();
        }

        //PUT api/character/{id} with body
        public async Task<bool> UpdateCharacterAsync(int id, StarTrekCharacterApiDto character)
        {
            var response = await _httpClient.PutAsJsonAsync($"character/{id}", character);
            return response.IsSuccessStatusCode;
        }

        //DELETE api/character/{id}
        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"character/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}