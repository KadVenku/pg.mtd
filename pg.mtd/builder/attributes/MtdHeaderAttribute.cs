using System.Runtime.CompilerServices;
using pg.util.interfaces;

[assembly: InternalsVisibleTo("pg.mtd.test")]

namespace pg.mtd.builder.attributes
{
    public class MtdHeaderAttribute : IBuilderAttribute
    {
        public uint RecordCount { get; set; } = 0;
    }
}
