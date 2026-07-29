namespace Gestao.Domain.Model
{
    public class Company
    {
        public int Id { get; set; }
        public string LegalName { get; set; } = string.Empty;
        public string TradeName { get; set; } = string.Empty;
        public string TaxId { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Neighboarhood { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Complement { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; } //DataHora Local + Fuso-horário
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

    }
}
