using System.Collections.Generic;
using System.Runtime.CompilerServices;
using pg.mtd.builder.attributes;
using pg.mtd.exceptions;
using pg.mtd.typedef;
using pg.util.exceptions;
using pg.util.interfaces;

[assembly: InternalsVisibleTo("pg.mtd.test")]

namespace pg.mtd.builder
{
    internal sealed class MtdImageTableBuilder : IBinaryFileBuilder<MtdImageTable, MtdImageTableAttribute>
    {
        public MtdImageTable Build(byte[] bytes)
        {
            if (bytes.Length % 81 != 0)
            {
                throw new InvalidByteArrayException($"The provided byte array does not contain a valid number of entries. Expected length: {(bytes.Length/81 + 1) * 81} bytes; actual lenght {bytes.Length} bytes.");
            }
            MtdImageTableAttribute attribute = new MtdImageTableAttribute();
            MtdImageTableRecordAttributeBuilder attributeBuilder = new MtdImageTableRecordAttributeBuilder();
            int currentByteIndex = 0;
            for (int recordIndex = 0; recordIndex < bytes.Length / 81; recordIndex++)
            {
                byte[] b = new List<byte>(bytes).GetRange(currentByteIndex, 81).ToArray();
                MtdImageTableRecordAttribute a = attributeBuilder.Build(b);
                attribute.Images.Add(a);
                currentByteIndex += 81;
            }
            return Build(attribute);
        }

        public MtdImageTable Build(MtdImageTableAttribute attribute)
        {
            if (attribute == null)
            {
                throw new AttributeNullException(nameof(attribute));
            }
            return new MtdImageTable(attribute);
        }
    }
}
