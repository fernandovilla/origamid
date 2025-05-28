using Agendabolo.Data;
using System.Collections.Generic;
using System.Linq;

namespace Agendabolo.Core.Ingredientes
{
    public class IngredienteRepository : GenericRepository.GenericRepositoryDbContext<IngredienteDTA, int>, IIngredienteRepository
    {
        public IngredienteRepository(IDatabaseContext database)
            : base(database)
        { }

        public override IngredienteDTA Get(int id)
        {
            var ingrediente = _database.Get<IngredienteDTA>(id);

            if (ingrediente != null)
                ingrediente.Embalagens = SelectEmbalagens(id).ToList();

            return ingrediente;
        }

        public IEnumerable<IngredienteDTA> GetWithEmbalagens()
        {
            var ingreidentes = _database.GetAll<IngredienteDTA>();

            foreach (var i in ingreidentes)
            {
                i.Embalagens = SelectEmbalagens(i.Id).ToList();
                yield return i;
            }
        }

        public override void Insert(IngredienteDTA ingrediente)
        {
            var ingredienteId = (int)_database.Insert<IngredienteDTA>(ingrediente);

            foreach (var embalagem in ingrediente.Embalagens)
            {
                embalagem.IdIngrediente = ingredienteId;
                InsertEmbalagem(embalagem);
            }            
        }
        
        public override void Update(IngredienteDTA ingrediente)
        {
            _database.Update<IngredienteDTA>(ingrediente) ;

            var embalagensAtuais = SelectEmbalagens(ingrediente.Id);

            /* Embalagens excluídas */
            var embalagensExcluidas = embalagensAtuais.Except(ingrediente.Embalagens, new IngredienteEmbalagemDTA());
            foreach (var emb in embalagensExcluidas)
                DeleteEmbalagem(emb);
            
            /* Embalagens atualizadas */
            var embalagensUpdated = ingrediente.Embalagens.Where(i => i.Id > 0);
            foreach (var emb in embalagensUpdated)
                UpdateEmbalagens(emb);
            
            /* Embalagens incluídas*/
            var embalagensAdded = ingrediente.Embalagens.Where(i => i.Id == 0);
            foreach (var emb in embalagensAdded)
            {
                emb.IdIngrediente = ingrediente.Id;
                InsertEmbalagem(emb);
            }
        }


        private IEnumerable<IngredienteEmbalagemDTA> SelectEmbalagens(int ingredienteId)
        {
            var sql = $"SELECT * FROM EmbalagensIngredientes WHERE IdIngrediente = {ingredienteId};";
            return _database.Query<IngredienteEmbalagemDTA>(sql, null);
        }

        private void InsertEmbalagem(IngredienteEmbalagemDTA embalagem)
        {
            string sql =
                "INSERT INTO embalagensingredientes (idingrediente, descricao, ean, idunidademedida, quantidade, tipoembalagem, preco) VALUES (" +
                "@idingrediente, @descricao, @ean, @idunidademedida, @quantidade, @tipoembalagem, @preco);";
            _database.Execute(sql, embalagem);
        }

        private void UpdateEmbalagens(IngredienteEmbalagemDTA embalagem)
        {
            string sql = "UPDATE embalagensingredientes SET " +
                $"descricao = @{nameof(IngredienteEmbalagemDTA.Descricao)}, " +
                $"ean = @{nameof(IngredienteEmbalagemDTA.EAN)}, " +
                $"idunidademedida = @{nameof(IngredienteEmbalagemDTA.IdUnidadeMedida)}, " +
                $"quantidade = @{nameof(IngredienteEmbalagemDTA.Quantidade)}, " +
                $"tipoembalagem = @{nameof(IngredienteEmbalagemDTA.TipoEmbalagem)}, " +
                $"preco = @{nameof(IngredienteEmbalagemDTA.Preco)} " +
                $"WHERE id = @{nameof(IngredienteEmbalagemDTA.Id)};";
            _database.Execute(sql, embalagem);
        }

        private void DeleteEmbalagem(IngredienteEmbalagemDTA embalagem)
        {
            _database.Delete<IngredienteEmbalagemDTA>(embalagem);
        }
    }

}