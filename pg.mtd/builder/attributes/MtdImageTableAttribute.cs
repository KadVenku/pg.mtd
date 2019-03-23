using System.Collections.Generic;
using System.Runtime.CompilerServices;
using pg.util.interfaces;
[assembly: InternalsVisibleTo("pg.mtd.test")]

namespace pg.mtd.builder.attributes
{
    public class MtdImageTableAttribute : IBuilderAttribute
    {
        public List<MtdImageTableRecordAttribute> Images { get; set; } = new List<MtdImageTableRecordAttribute>();
    }
}