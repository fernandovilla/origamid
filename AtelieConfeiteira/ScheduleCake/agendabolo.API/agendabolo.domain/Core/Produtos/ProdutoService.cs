﻿using Agendabolo.Core.Logs;
using Agendabolo.Core.Receitas;
using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Produtos
{
    public class ProdutoService : IServiceBase<ProdutoDTA, ulong>
    {
        public bool Delete(ulong id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProdutoDTA> Get()
        {
            using (var unit = new UnitOfWork())
            {
                return unit.ProdutoRepository.Get();
            }
        }

        public ProdutoDTA GetByID(ulong id)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    return unit.ProdutoRepository.GetByID(id); ;
                }
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
            }

            return null;
        }

        public ProdutoDTA GetByID_Min(ulong id)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    return unit.ProdutoRepository.GetByID_Min(id); ;
                }
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
            }

            return null;
        }

        public int GetTotal()
        {
            using (var unit = new UnitOfWork())
            {
                return unit.ProdutoRepository.Count();
            }
        }

        public (bool, ProdutoDTA) Save(ProdutoDTA produto)
        {
            try
            {
                using(var unit = new UnitOfWork())
                {
                    var repository = unit.ProdutoRepository;

                    if (produto.Id == 0)
                    {
                        repository.Insert(produto);
                    } else
                    {
                        repository.Update(produto);
                    }

                    unit.Save();
                }

                return (true, produto);
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
            }

            return (false, produto);
        }
    }
}