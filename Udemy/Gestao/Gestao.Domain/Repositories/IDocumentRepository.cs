using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;

namespace Gestao.Domain.Repositories
{
    public interface IDocumentRepository
        : IRepository<Document>
    {
        Task<PaginatedList<Document>> GetAllAsync(int financialTransactionId, int pageIndex, int pageSize);
        Task<PaginatedList<Document>> GetAllAsync(int financialTransactionId, int pageIndex, int pageSize, string? searchDescription = null);
    }
}
