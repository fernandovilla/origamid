using Coravel.Invocable;
using Gestao.App.Client.Libraries.Extensions;
using Gestao.Domain.Model;
using Gestao.Domain.Repositories;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata.Internal;
using Microsoft.Identity.Client.AppConfig;

namespace Gestao.App.Libraries.Queues
{
    public class FinancialTransactionRepeatInvocable
        : IInvocable, IInvocableWithPayload<FinancialTransaction>
    {
        private IFinancialTransactionRepository _repository;

        public FinancialTransactionRepeatInvocable(IFinancialTransactionRepository repository)
        {
            _repository = repository;
        }

        public FinancialTransaction Payload { get; set; }

        public async Task Invoke()
        {
            //Cadastrar ou Atualizar transações financeiras
            //  Criar grupo de parcelamento
            //  Cadastro -> Incluir novas transações, parceladas ou não
            //  Edição -> Altera ou remove transações e parcelas. Há cenários com inclusão ou redução de parcelas

            var startPoint = 1;
            var countRepeatGroup = await _repository.GetCountTransactionRepeatGroup(Payload.Id);
            var repeatTimes = Payload.RepeatTimes.HasValue ? Payload.RepeatTimes.Value : 0;

            //Assina o RepeatGroup da primeira
            await AssingRepeatGroupTransaction();


            if (countRepeatGroup == 0)
            {
                //Adicionando uma novas transações, registro inicial, cadastramento
                await RegistrarNovaTransacaoAsync(startPoint);
            }
            else if (countRepeatGroup < repeatTimes)
            {
                //Aumentando o número de parcelas
                await RegistrarNovaTransacaoAsync(countRepeatGroup);

            }
            else if (countRepeatGroup > repeatTimes && repeatTimes > 0)
            {
                //Reduzinho número de parcelas,ex; 10parc -> 7parc => Excluir Parcelas: 8, 9 e 10
                await ReducaoParcela(countRepeatGroup);

            }
            else if (countRepeatGroup > 0 && repeatTimes == 0)
            {
                //Removendo todas as parcelas,ex: 10parc -> 0parc => Excluir todas as parcelas
                await ExclusaoParcelas(countRepeatGroup);
            }
        }

        private async Task AssingRepeatGroupTransaction()
        {
            if (Payload.Repeat != RecurrentEnum.None)
            {
                Payload.RepeatGroup = Payload.Id;
                await _repository.UpdateAsync(Payload);
            }
        }

        private async Task ExclusaoParcelas(int countRepeatGroup)
        {
            if (Payload.Repeat == RecurrentEnum.None && countRepeatGroup > 1)
            {
                var transactions = await _repository.GetTransactionRepeatGroup(Payload.Id);
                for (var i = 1; i < countRepeatGroup; i++)
                {
                    await _repository.DeleteAsync(transactions[i].Id);
                }
            }
        }

        private async Task ReducaoParcela(int countRepeatGroup)
        {
            if (Payload.Repeat != RecurrentEnum.None && countRepeatGroup > Payload.RepeatTimes)
            {
                var transactions = await _repository.GetTransactionRepeatGroup(Payload.Id);
                for (var i = countRepeatGroup; i > Payload.RepeatTimes; i--)
                {
                    await _repository.DeleteAsync(transactions[i-1].Id);
                }
            }
        }

        private async Task RegistrarNovaTransacaoAsync(int startPoint)
        {
            if (Payload.Repeat != RecurrentEnum.None)
            {
                var repeatTimes = Payload.RepeatTimes - 1;  //a primeira já foi gravada

                for (int i = startPoint; i <= repeatTimes; i++)
                {
                    var financial = new FinancialTransaction();
                    financial.FinancialTransactionType = Payload.FinancialTransactionType;
                    financial.Description = Payload.Description;
                    financial.ReferenceDate = IncrementDate(Payload.Repeat, i, Payload.ReferenceDate);    //recalcular a data de referencia
                    financial.DueDate = IncrementDate(Payload.Repeat, i, Payload.DueDate);                //recalcular a data de vencimento
                    financial.Amount = Payload.Amount;
                    financial.RepeatGroup = Payload.Id;
                    financial.Repeat = RecurrentEnum.None;      //Necessário recalcular
                    financial.RepeatTimes = null;
                    financial.Observation = Payload.Observation;
                    financial.CreatedAt = Payload.CreatedAt;
                    financial.CompanyId = Payload.CompanyId;
                    financial.CategoryId = Payload.CategoryId;
                    financial.AccountId = Payload.AccountId;

                    await _repository.AddAsync(financial);
                }
            }
        }

        private DateTimeOffset? IncrementDate(RecurrentEnum repeat, int count, DateTimeOffset? startDate)
        {
            if (!startDate.HasValue)
                return null;

            if (repeat == RecurrentEnum.None || count <= 0)
                return startDate;

            switch (repeat)
            {
                case RecurrentEnum.Weekly:
                    return startDate.Value.AddDays(7 * count);
                case RecurrentEnum.Monthly:
                    return startDate.Value.AddMonths(count);
                case RecurrentEnum.Yearly:
                    return startDate.Value.AddYears(count);
                default:
                    return startDate;
            }
        }
    }
}
