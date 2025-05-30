using Agendabolo.Core.LogDeErros;
using Agendabolo.Core.Produtos;
using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Clientes
{
    public class ClienteService : IServiceBase<ClienteDTA, int>
    {
        public bool Delete(int id)
        {
            using (var unit = new UnitOfWork())
            {
                unit.GetClienteRepository.Delete(id);
                unit.SaveChanges();

                return true;
            }
        }

        public IEnumerable<ClienteDTA> Get()
        {
            using (var unit = new UnitOfWork())
                return unit.GetClienteRepository.Get().ToList();
        }

        public ClienteDTA Get(int id)
        {
            using(var unit = new UnitOfWork())
                return unit.GetClienteRepository.Get(id);
        }

        public int GetTotal()
        {
            using (var unit = new UnitOfWork())
                return unit.GetClienteRepository.Count();
        }

        public (bool, ClienteDTA) Save(ClienteDTA cliente)
        {
            var result = false;

            try
            {
                using (var unit = new UnitOfWork())
                {
                    var repository = unit.GetClienteRepository;

                    if (cliente.Id == 0)
                        repository.Insert(cliente);
                    else
                        repository.Update(cliente);

                    unit.SaveChanges();
                }

                result = true;
            }
            catch (Exception ex)
            {
                LogDeErros.LogDeErro.Default.Write(ex);
            }

            return (result, cliente);
        }
    }
}
