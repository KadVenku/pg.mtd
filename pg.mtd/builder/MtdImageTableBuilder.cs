using System;
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
            if (bytes == null)
            {
                throw new ArgumentNullException($"Expected byte array \'{nameof(bytes)}\', got \'null\' instead.");
            }

            if (bytes.Length % new MtdImageTableRecord().Size() != 0)
            {
                throw new InvalidByteArrayException(
                    $"The provided byte array does not contain a valid number of entries. Expected length: {(bytes.Length / new MtdImageTableRecord().Size() + 1) * new MtdImageTableRecord().Size()} bytes; actual length {bytes.Length} bytes.");
            }

            MtdImageTableAttributeBuilder builder = new MtdImageTableAttributeBuilder();
            MtdImageTableAttribute attribute = builder.Build(bytes);
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
