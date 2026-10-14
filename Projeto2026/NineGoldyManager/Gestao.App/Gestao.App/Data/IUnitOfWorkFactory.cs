namespace Gestao.App.Data
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
