using ScreenSound.Web.Requests;
using ScreenSound.Web.Response;
using System.Net.Http.Json;

namespace ScreenSound.Web.Services
{
    public class MusicaAPI
    {
        private readonly HttpClient _httpClient;

        public MusicaAPI(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }

        public async Task<MusicaResponse?> GetAsync(int id) => await _httpClient.GetFromJsonAsync<MusicaResponse>($"musicas/{id}");

        public async Task<ICollection<MusicaResponse>?> GetAsync() => await _httpClient.GetFromJsonAsync<ICollection<MusicaResponse>>("musicas");

        public async Task<bool> AddAsync(MusicaRequest request) => (await _httpClient.PostAsJsonAsync("musicas", request)).IsSuccessStatusCode;

        public async Task<bool> SaveAsync(MusicaRequest request) => (await _httpClient.PutAsJsonAsync("musicas", request)).IsSuccessStatusCode;

        public async Task DeleteAsync(int id) => await _httpClient.DeleteAsync($"musicas/{id}");
    }
}
