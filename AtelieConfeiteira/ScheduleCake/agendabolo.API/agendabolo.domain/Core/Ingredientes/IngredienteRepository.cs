using Agendabolo.Data;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Agendabolo.Core.Ingredientes
{
    public class IngredienteRepository : GenericRepository.GenericRepositoryDbContext<IngredienteDTA, int>, IIngredienteRepository
    {
        public IngredienteRepository(ApplicationDbContext context)
            : base(context)
        { }

        public override IngredienteDTA Get(int id)
        {
            var ingrediente = base.Get(id);

            if (ingrediente != null)
                ingrediente.Embalagens = SelectEmbalagens(id);

            return ingrediente;
        }

        public IEnumerable<IngredienteDTA> GetWithEmbalagens()
        {            
            foreach(var i in base.Get())
            {
                i.Embalagens = SelectEmbalagens(i.Id);
                yield return i;
            }
        }

        public override void Insert(IngredienteDTA ingrediente)
        {
            var ingredienteId = (int)_context.Connection.Insert<IngredienteDTA>(ingrediente, _context.Transaction);

            foreach (var embalagem in ingrediente.Embalagens)
            {
                embalagem.IdIngrediente = ingredienteId;
                InsertEmbalagem(embalagem);
            }            
        }
        
        public override void Update(IngredienteDTA ingrediente)
        {
            _context.Connection.Update<IngredienteDTA>(ingrediente, _context.Transaction);

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




            //if (ingrediente == null)
            //    throw new ArgumentNullException(nameof(ingrediente), "Ingrediente inválido");

            //var embalagensEditadas = ingrediente.Embalagens
            //    .Select(i => (IngredienteEmbalagemDTA)i)
            //    .ToList();

            //var embalagensAtuais = _context.IngredientesEmbalagens
            //    .Where(i => i.IdIngrediente == ingrediente.Id)
            //    .Select(i => (IngredienteEmbalagemDTA)i)
            //    .ToList();

            //_context.Entry(ingrediente).State = EntityState.Modified;


            //if (embalagensAtuais != null)
            //    embalagensAtuais.ForEach(i => _context.Entry(i).State = EntityState.Detached);

            //// Embalagens incluídas 
            //var embalagensAdded = embalagensEditadas.Where(i => i.Id == 0);
            //if (embalagensAdded != null)
            //    embalagensAdded.ToList().ForEach(i => _context.Entry(i).State = EntityState.Added);

            //// Embalagens excluídas
            //var embalagensRemoved = embalagensAtuais.Except(embalagensEditadas, new IngredienteEmbalagemDTA());
            //if (embalagensRemoved != null)
            //    embalagensRemoved.ToList().ForEach(i => _context.IngredientesEmbalagens.Remove(i));

            //// Embalagens editadas
            //var embalagensUpdated = embalagensEditadas.Where(i => i.Id > 0).Intersect(embalagensAtuais, new IngredienteEmbalagemDTA());
            //if (embalagensUpdated != null)
            //    embalagensUpdated.ToList().ForEach(i => _context.Entry(i).State = EntityState.Modified);

        }


        private IEnumerable<IngredienteEmbalagemDTA> SelectEmbalagens(int ingredienteId)
        {
            var sql = $"SELECT * FROM EmbalagensIngredientes WHERE IdIngrediente = {ingredienteId};";
            return _context.Connection.Query<IngredienteEmbalagemDTA>(sql);
        }

        private void InsertEmbalagem(IngredienteEmbalagemDTA embalagem)
        {
            string sql =
                "INSERT INTO embalagensingredientes (idingrediente, descricao, ean, idunidademedida, quantidade, tipoembalagem, preco) VALUES (" +
                "@idingrediente, @descricao, @ean, @idunidademedida, @quantidade, @tipoembalagem, @preco);";
            _context.Connection.Execute(sql, embalagem, _context.Transaction);
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
            _context.Connection.Execute(sql, embalagem, _context.Transaction);
        }

        private void DeleteEmbalagem(IngredienteEmbalagemDTA embalagem)
        {
            _context.Connection.Delete<IngredienteEmbalagemDTA>(embalagem, _context.Transaction);
        }
    }

}