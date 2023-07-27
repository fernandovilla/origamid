using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core
{
    public interface IParsableEntity<TRequest, TDTA>
    {
        static abstract TDTA ToDTA(TRequest entity);
        static abstract TRequest Parse(TDTA entity);
    }
}
