using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core
{
    public interface IParsableEntity<TRequest, TDTA>
    {
        TDTA ToDTA(TRequest entity);
        TRequest Parse(TDTA entity);
    }
}
