namespace BlazorWebAssemblySample.Models
{
    public class ClienteRepository
    {
        public IReadOnlyCollection<Cliente> List()
        {
            return new List<Cliente>()
            {
                new Cliente {Id = 1, Nome = "José da Silva"},
                new Cliente { Id = 2, Nome = "Maria do Socorro"},
                new Cliente { Id = 3, Nome = "Luis Fernando Villa"}
            };
        }
    }
}
