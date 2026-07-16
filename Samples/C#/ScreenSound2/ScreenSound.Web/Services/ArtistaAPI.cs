using ScreenSound.Web.Pages;
using ScreenSound.Web.Requests;
using ScreenSound.Web.Response;
using System.Net.Http.Json;
using System.Security.AccessControl;

namespace ScreenSound.Web.Services
{
    public class ArtistaAPI
    {
        private readonly HttpClient _httpClient;

        public ArtistaAPI(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }

        public async Task<ArtistaResponse?> GetArtistasAsync(int id) => await _httpClient.GetFromJsonAsync<ArtistaResponse>($"artistas/{id}");

        public async Task<ICollection<ArtistaResponse>?> GetArtistasAsync() => await _httpClient.GetFromJsonAsync<ICollection<ArtistaResponse>>("artistas");

        public async Task<bool> AddAsync(ArtistaRequest request) => (await _httpClient.PostAsJsonAsync("artistas", request)).IsSuccessStatusCode;

        public async Task<bool> SaveAsync(ArtistaRequestEdit request) => (await _httpClient.PutAsJsonAsync("artistas", request)).IsSuccessStatusCode;

        public async Task DeleteAsync(int id) => await _httpClient.DeleteAsync($"artistas/{id}");

    }
}
