using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostgreEF.Data
{
    public class DateTimeOffsetConverter
        : ValueConverter<DateTimeOffset, DateTimeOffset>
    {
        public DateTimeOffsetConverter()
            : base(d => d.ToUniversalTime(), d => d.ToUniversalTime())
        { }
    }
}
