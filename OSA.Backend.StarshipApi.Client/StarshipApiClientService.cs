using System.Net.Http.Json;
using OSA.Backend.StarshipApi.Client.DtoModels;

namespace OSA.Backend.StarshipApi.Client
{
    /// <summary>
    /// A client service to be used by API consumers to communicate with StarshipApi
    /// </summary>
    /// <seealso cref="OSA.Backend.StarshipApi.Client.IStarshipApiClientService" />
    public class StarshipApiClientService : IStarshipApiClientService
    {
        private readonly HttpClient _httpClient;

        //This is to be accessible to consuimers of the client to give them a default option that they can use or override
        public static readonly Uri DefaultBaseAddress = new Uri("https://localhost:51003/api/");

        public StarshipApiClientService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        //GET api/starship
        public async Task<IEnumerable<StarTrekStarshipApiDto>?> GetAllStarshipsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<StarTrekStarshipApiDto>>("starship");
        }

        //GET api/starship/{id}
        public async Task<StarTrekStarshipApiDto?> GetStarshipAsync(int id)
        {
            var response = await _httpClient.GetAsync($"starship/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<StarTrekStarshipApiDto>();
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

        //POST api/starship with body
        public async Task<StarTrekStarshipApiDto?> AddStarshipAsync(StarTrekStarshipApiDto starship)
        {
            var response = await _httpClient.PostAsJsonAsync("starship", starship);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<StarTrekStarshipApiDto>();
        }

        //PUT api/starship/{id} with body
        public async Task<bool> UpdateStarshipAsync(int id, StarTrekStarshipApiDto starship)
        {
            var response = await _httpClient.PutAsJsonAsync($"starship/{id}", starship);
            return response.IsSuccessStatusCode;
        }

        //DELETE api/starship/{id}
        public async Task<bool> DeleteStarshipAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"starship/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
