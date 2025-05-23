﻿using Agendabolo.Core.LogDeErros;
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
            using (var unit = new UnitOfWorkDbContext())
            {
                unit.ClienteRepository.Delete(id);
                unit.SaveChanges();

                return true;
            }
        }

        public IEnumerable<ClienteDTA> Get()
        {
            using (var unit = new UnitOfWorkDbContext())
                return unit.ClienteRepository.Get().ToList();
        }

        public ClienteDTA GetByID(int id)
        {
            using(var unit = new UnitOfWorkDbContext())
                return unit.ClienteRepository.Get(id);
        }

        public int GetTotal()
        {
            using (var unit = new UnitOfWorkDbContext())
                return unit.ClienteRepository.Count();
        }

        public (bool, ClienteDTA) Save(ClienteDTA cliente)
        {
            var result = false;

            try
            {
                using (var unit = new UnitOfWorkDbContext())
                {
                    var repository = unit.ClienteRepository;

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
