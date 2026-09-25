using Microsoft.Extensions.Validation;
using System.ComponentModel.DataAnnotations;

namespace BlazorSharedPageSample.Server.Services
{
    public class Expense : ICloneable
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTimeOffset? Date { get; set; }
        public Categories Category { get; set; }
        public string Color { get; set; } = "#0078D4";

        public object Clone()
        {
            return new Expense
            {
                Id = this.Id,
                Description = this.Description,
                Amount = this.Amount,
                Date = this.Date,
                Color = this.Color,
                Category = this.Category
            };
        }

        internal bool IsValid => Validator.TryValidateObject(this, new ValidationContext(this), validationResults: null, validateAllProperties: true);

        public static Categories[] AllCategories = [.. Enum.GetValues<Categories>().Cast<Expense.Categories>()];

        public enum Categories
        {
            General,
            Food,
            Travel,
            Entertainment,
            Others
        }
    }

    
}
