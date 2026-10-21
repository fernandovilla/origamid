using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gestao.App.Data.Converters
{
    public class UtcDatetimeConverter : ValueConverter<DateTime, DateTime>
    {
        public UtcDatetimeConverter() : base(
            d => d.Kind == DateTimeKind.Utc ? d : DateTime.SpecifyKind(d, DateTimeKind.Utc),
            d => DateTime.SpecifyKind(d,DateTimeKind.Utc))
        { }
    }

    public class NullableUtcDateTimeConverter: ValueConverter<DateTime?, DateTime?>
    {
        public NullableUtcDateTimeConverter(): 
            base(
                d => d.HasValue ? (d.Value.Kind == DateTimeKind.Utc ? d : DateTime.SpecifyKind(d.Value, DateTimeKind.Utc)) : d,
                i => i.HasValue ? DateTime.SpecifyKind(i.Value, DateTimeKind.Utc) : i
            )
        { }
    }
}
