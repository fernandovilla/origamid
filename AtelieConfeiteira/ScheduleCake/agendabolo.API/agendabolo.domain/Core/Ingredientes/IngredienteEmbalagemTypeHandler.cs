using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Ingredientes
{
    internal class IngredienteEmbalagemTypeHandler : SqlMapper.TypeHandler<IngredienteEmbalagemDTA>
    {
        public override IngredienteEmbalagemDTA Parse(object value)
        {
            return JsonConvert.DeserializeObject<IngredienteEmbalagemDTA>(value.ToString());
        }

        public override void SetValue(IDbDataParameter parameter, IngredienteEmbalagemDTA value)
        {
            parameter.Value = (value == null)
                ? (object)DBNull.Value
                : JsonConvert.SerializeObject(value);

            parameter.DbType = DbType.String;
        }
    }
}
