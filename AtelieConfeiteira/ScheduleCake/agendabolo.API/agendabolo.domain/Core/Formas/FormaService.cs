﻿using Agendabolo.Core.LogDeErros;
using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Formas
{
    public class FormaService : IServiceBase<FormaDTA, int>
    {
        public bool Delete(int id)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    unit.GetFormaRepository.Delete(id);
                    unit.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                LogDeErros.LogDeErro.Default.Write(ex);
            }

            return false;
        }

        public IEnumerable<FormaDTA> Get()
        {
            using (var unit = new UnitOfWork())
            {
                return unit.GetFormaRepository.Get().ToList();
            }
        }

        public FormaDTA Get(int id)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    return unit.GetFormaRepository.Get(id);
                }
            }
            catch (Exception ex)
            {
                LogDeErros.LogDeErro.Default.Write(ex);
            }

            return null;
        }

        public int GetTotal()
        {
            using (var unit = new UnitOfWork())
            {
                return unit.GetFormaRepository.Count();
            }
        }

        public (bool, FormaDTA) Save(FormaDTA forma)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    var repository = unit.GetFormaRepository;

                    if (forma.Id == 0)
                        repository.Insert(forma);
                    else
                        repository.Update(forma);

                    unit.SaveChanges();
                }

                return (true, forma);
            }
            catch (Exception ex)
            {
                LogDeErros.LogDeErro.Default.Write(ex);
            }

            return (false, forma);
        }
    }
}
