using Agendabolo.Data;

namespace Agendabolo.Core.Fornecedores
{
    public class FornecedorRepository : GenericRepository.GenericRepositoryDbContext<FornecedorDTA, int>, IFornecedorRepository
    {
        public FornecedorRepository(IDatabaseContext database)
            : base(database)
        { }               
    }
}
