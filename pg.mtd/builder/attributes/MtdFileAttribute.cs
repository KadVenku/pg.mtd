using System.Runtime.CompilerServices;
using pg.util.interfaces;

[assembly: InternalsVisibleTo("pg.mtd.test")]

namespace pg.mtd.builder.attributes
{
    public class MtdFileAttribute : IBuilderAttribute
    {
        public MtdHeaderAttribute HeaderAttribute { get; set; } = new MtdHeaderAttribute();
        public MtdImageTableAttribute ImageTableAttribute { get; set; } = new MtdImageTableAttribute();
    }
}
