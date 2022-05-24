namespace Sistema.Utils
{
    public static partial class BooleanExtensions
    {
        public static string ToSql(this bool condicao)
        {
            return condicao ? "1" : "0";
        }

        public static string ToSql(this bool? condicao)
        {
            if (condicao.HasValue)
            {
                return condicao.Value.ToSql();
            }

            return "Null";
        }
    }
}
