using Agendabolo.Core.Entradas;
using Agendabolo.Core.Formas;
using Agendabolo.Data;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Historicos
{
    public class HistoricoEntradaRepository : GenericRepository.GenericRepositoryDbContext<HistoricoEntradaDTA, int>, IHistoricoEntradaRepository
    {        
        public HistoricoEntradaRepository(IDatabaseContext database)
            : base(database)
        { }

        public override void Insert(HistoricoEntradaDTA historicoEntrada)
        {            
            string sql = 
                "INSERT INTO Historico (dataoperacao, tipooperacao) VALUES (@dataoperacao, @tipooperacao); " +
                "SELECT LAST_INSERT_ID();";
            var idHistorico = _database.Connection.Execute(sql, historicoEntrada.Historico, _database.Transaction);

            
            sql = "INSERT INTO HistoricoEntradas (idhistorico, idfornecedor, numeronf, dataemissao, dataentrada, frete, distribuiufreteitens) VALUES " +
                "(@idhistorico, @idfornecedor, @numeronf, @dataemissao, @dataentrada, @frete, @distribuiufreteitens);" +
                "SELECT LAST_INSERT_ID();";
            historicoEntrada.IdHistorico = idHistorico;
            var idHistoricoEntrada = _database.Connection.Execute(sql, historicoEntrada, _database.Transaction);


            sql = "INSERT INTO HistoricoEntradasItens (identrada, idingrediente, quantidade, estoqueantes, precocustoquiloantes, precocustoquilobruto, precocustoquiloliquido, valordesconto, valorfrete) VALUES " +
                $"(null, @idingrediente, @quantidade, @estoqueantes, @precocustoquiloantes, @precocustoquilobruto, @precocustoquiloliquido, @valordesconto, @valorfrete);";
            foreach (var item in historicoEntrada.Itens) {

                item.IdEntrada = idHistoricoEntrada;                
                _database.Connection.Execute(sql, item, _database.Transaction);

                //lotes...
            }

        }

        public int Count()
        {
            return _database.Connection.GetAll<HistoricoEntradaDTA>(_database.Transaction).Count();
        }
    }
}
