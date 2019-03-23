using System.Runtime.CompilerServices;
using pg.util.interfaces;
[assembly: InternalsVisibleTo("pg.mtd.test")]

namespace pg.mtd.builder.attributes
{
    public sealed class MtdImageTableRecordAttribute : IBuilderAttribute
    {
        public string Name { get; set; } = "INVALID";

        public uint XPosition { get; set; } = 0;

        public uint YPosition { get; set; } = 0;

        public uint XExtend { get; set; } = 0;

        public uint YExtend { get; set; } = 0;

        public bool Alpha { get; set; } = true;
    }
}
