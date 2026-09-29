using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BlazorSharedPageSample.Server.Services
{
    public static class ExpenseServiceExtension
    {
        public static IQueryable<Expense> AsQueryable(this ExpenseService service)
        {
            return service.Items.AsQueryable();
        }

        public static IQueryable<Expense> Filter(this IQueryable<Expense> source, string? searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return source;

            var term = searchTerm.Trim();
            return source.Where(e =>
                e.Description.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                e.Category.ToString().Contains(term, StringComparison.OrdinalIgnoreCase));
        }
    }
}
