namespace BlazorSharedPageSample.Server.Services
{
    public interface IExpenseService
    {
        event Action? Changed;
        IReadOnlyList<Expense> Items { get; }
        void Add(Expense expense);
        void Update(Expense expense);
        void Remove(Guid id);
        void ImportCsv(Stream stream);
    }
}
