namespace BlazorSharedPageSample.Server.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly List<Expense> _items = new()
        {
            new Expense { Id = Guid.CreateVersion7(), Description = "Team lunch", Amount = 64.5m, Category = Expense.Categories.Food, Color = "#107C10" , Date = new DateTime(2017,7,8) },
            new Expense { Id = Guid.CreateVersion7(), Description = "Taxi to Airport", Amount = 38.97m, Category = Expense.Categories.Travel, Color= "#0078D4" , Date = new DateTime(1981,11,30) },
            new Expense { Id = Guid.CreateVersion7(), Description = "Conference Ticket", Amount = 499.00m, Category = Expense.Categories.Entertainment, Color= "#8764B8", Date = new DateTime(1983,6,2)  }
        };

        public IReadOnlyList<Expense> Items => _items;

        public event Action? Changed;

        public void Add(Expense expense)
        {
            _items.Insert(0, expense);
            Changed?.Invoke();
        }

        public void Update(Expense expense)
        {
            var index = _items.FindIndex(i => i.Id == expense.Id);
            if (index >= 0)
            {
                _items[index] = expense;
                Changed?.Invoke();
            }
            else
            {
                Add(expense);
            }
        }

        public void Remove(Guid id)
        {
            var index = _items.FindIndex(i => i.Id == id);
            if (index >= 0)
            {
                _items.RemoveAt(index);
                Changed?.Invoke();
            }
        }

        public void ImportCsv(Stream stream)
        {
            //throw new NotImplementedException();
        }
    }


}
