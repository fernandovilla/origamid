
using System.Net;

namespace Gestao.App.Libraries.Services
{
    public class CepServices : ICepServices
    {
        //https://viacep.com.br/

        private readonly string _url = @"https://viacep.com.br/ws/{0}/json/";

        public async Task<AddressCEP?> SearchByPostalCodeAsync(string postalCode)
        {            
            var code = postalCode.Replace(".", string.Empty).Replace("-", string.Empty);

            if (!string.IsNullOrEmpty(code))
            {
                var url = $"https://viacep.com.br/ws/{code}/json/";

                using var http = new HttpClient();
                var result = await http.GetFromJsonAsync<AddressCEP>(url);

                return result;
            }

            return null;
        }
    }

    public class AddressCEP
    {
        public string CEP { get; set; } = string.Empty;
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public string IBGE { get; set; }
        public string GIA { get; set; }
        public string DDD { get; set; }
        public string SIAFI { get; set; }
    }
}
