using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBolo.Domain.Model.Repositories
{
    public interface ISearch<TResult, TValue>
    {
        IEnumerable<TResult> Search(TValue value);
    }
}
