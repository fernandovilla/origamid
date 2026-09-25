namespace BlazorSharedPageSample.Server.Services
{
    public class ExpenseService
    {
        private readonly List<Expense> _items =
        {
            new Expense { Id = Guid.CreateVersion7(), Description = "Team lunch", Amount = 64.5m, Category.Food  }
        };
    }
}
