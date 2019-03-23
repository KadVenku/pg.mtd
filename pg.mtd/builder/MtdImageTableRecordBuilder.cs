using System.Runtime.CompilerServices;
using pg.mtd.builder.attributes;
using pg.mtd.typedef;
using pg.util.exceptions;
using pg.util.interfaces;
[assembly: InternalsVisibleTo("pg.mtd.test")]

namespace pg.mtd.builder
{
    internal sealed class MtdImageTableRecordBuilder : IBinaryFileBuilder<MtdImageTableRecord, MtdImageTableRecordAttribute>
    {
        public MtdImageTableRecord Build(byte[] bytes)
        {
            throw new System.NotImplementedException();
        }

        public MtdImageTableRecord Build(MtdImageTableRecordAttribute attribute)
        {
            if (attribute == null)
            {
                throw new AttributeNullException($"Building an instance of \'{nameof(MtdImageTableRecord)}\' requires a non-null argument of type \'{nameof(MtdImageTableRecordAttribute)}\'.");
            }
            return new MtdImageTableRecord(attribute);
        }
    }
}
