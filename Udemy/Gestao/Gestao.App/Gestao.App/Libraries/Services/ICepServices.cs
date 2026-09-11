namespace Gestao.App.Libraries.Services
{
    public interface ICepServices
    {
        Task<AddressCEP?> SearchByPostalCodeAsync(string postalCode);
    }
}
