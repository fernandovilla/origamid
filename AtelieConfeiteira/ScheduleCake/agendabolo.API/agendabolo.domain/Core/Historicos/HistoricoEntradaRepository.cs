using Agendabolo.Core.Entradas;
using Agendabolo.Core.Formas;
using Agendabolo.Data;
using Dapper;
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
        public HistoricoEntradaRepository(ApplicationDbContext context)
            : base(context)
        { }

        public override void Insert(HistoricoEntradaDTA historicoEntrada)
        {            
            string sql = 
                "INSERT INTO Historico (dataoperacao, tipooperacao) VALUES (@dataoperacao, @tipooperacao); " +
                "SELECT LAST_INSERT_ID();";
            var idHistorico = _context.Connection.Execute(sql, historicoEntrada.Historico, _context.Transaction);


            historicoEntrada.IdHistorico = idHistorico;
            sql = "INSERT INTO HistoricoEntradas (idhistorico, idfornecedor, numeronf, dataemissao, dataentrada, frete, distribuiufreteitens) VALUES " +
                "(@idhistorico, @idfornecedor, @numeronf, @dataemissao, @dataentrada, @frete, @distribuiufreteitens);" +
                "SELECT LAST_INSERT_ID();";
            var idHistoricoEntrada = _context.Connection.Execute(sql, historicoEntrada, _context.Transaction);


            sql = "INSERT INTO HistoricoEntradasItens (identrada, idingrediente, quantidade, estoqueantes, precocustoquiloantes, precocustoquilobruto, precocustoquiloliquido, valordesconto, valorfrete) VALUES " +
                "(@identrada, @idingrediente, @quantidade, @estoqueantes, @precocustoquiloantes, @precocustoquilobruto, @precocustoquiloliquido, @valordesconto, @valorfrete);";
            foreach (var item in historicoEntrada.Itens) {
                item.IdEntrada = idHistoricoEntrada;                
                _context.Connection.Execute(sql, item, _context.Transaction);

                //lotes...
            }

        }

        public int Count()
        {
            return _context.Historicos.Where(i => i.TipoOperacao == TipoOperacaoHistoricoEnum.EntradaMercadorias).Count();
        }
    }
}
