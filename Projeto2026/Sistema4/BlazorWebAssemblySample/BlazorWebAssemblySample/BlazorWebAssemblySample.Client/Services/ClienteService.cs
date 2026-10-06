using BlazorWebAssemblySample.Models;
using System.Net.Http.Json;

namespace BlazorWebAssemblySample.Client.Services
{
    public class ClienteService(HttpClient httpClient) :  IClienteService
    {
        public async Task<IReadOnlyCollection<Cliente>> ListarClientes()
        {
            var result = await httpClient.GetFromJsonAsync<IReadOnlyCollection<Cliente>>("api/clientes");

            return result;
        }

    }
}
