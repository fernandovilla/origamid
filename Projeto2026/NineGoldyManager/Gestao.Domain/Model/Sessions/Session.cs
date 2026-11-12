using FluentValidation;
using Gestao.Domain.Interfaces;
using Gestao.Domain.Model.Customers;

namespace Gestao.Domain.Model.Sessions
{
    public class Session : IStatusManager
    {
        public Guid Id { get; set; }
        
        public DateTimeOffset? SessionDate { get; set; } = DateTimeOffset.Now;
        public string? Observation { get; set; }
        public string? Signature { get; set; } //conteudo da imagem
        public Guid? CustumerId { get; set; }
        public Customer? Customer { get; set; }
        

        public StatusEnum Status { get; set; } = StatusEnum.Normal;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }

     public class SessionValidator : AbstractValidator<Session>
    {
        public SessionValidator()
        {
            RuleFor(i => i.Observation)
                .NotEmpty().WithMessage("Nenhuma observação informada para a sessão")
                .Length(2, 500).WithMessage("Informar ao menos 2 e no máximo 500 caracteres");

            RuleFor(i => i.Signature)
                .NotEmpty().WithMessage("Sessão não assinada ou assinatura não confirmada");
        }
    }
}