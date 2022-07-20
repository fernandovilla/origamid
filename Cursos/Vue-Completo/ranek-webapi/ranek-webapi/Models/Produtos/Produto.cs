using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ranek_webapi.Models.Produtos
{
    public class Produto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("usuario_id")]
        public string UsuarioId { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("preco")]
        public decimal Preco { get; set; }

        [JsonProperty("vendido")]
        public string Vendido { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("fotos")]
        public IEnumerable<Foto> Fotos { get; set; }
    }
}
