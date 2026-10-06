using BlazorWebAssemblySample.Models;

namespace BlazorWebAssemblySample.Client.Services
{
    public interface IClienteService
    {
        Task<IReadOnlyCollection<Cliente>> ListarClientes();
    }
}
