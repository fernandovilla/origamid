using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ranek_webapi.Models.Produtos
{
    public class ProdutoRepository
    {
        public IEnumerable<Produto> Selecionar()
        {
            string fileJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "produtos.json");

            if (!File.Exists(fileJson))
                throw new FileNotFoundException("Arquivo não encontrado - produtos.json");

            var produtos = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Produto>>(File.ReadAllText(fileJson));


            return produtos;
        }
    }
}
