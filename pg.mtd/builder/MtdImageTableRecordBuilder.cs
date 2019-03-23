using System;
using System.Runtime.CompilerServices;
using pg.mtd.builder.attributes;
using pg.mtd.exceptions;
using pg.mtd.typedef;
using pg.util.exceptions;
using pg.util.interfaces;
[assembly: InternalsVisibleTo("pg.mtd.test")]

namespace pg.mtd.builder
{
    internal sealed class MtdImageTableRecordBuilder : IBinaryFileBuilder<MtdImageTableRecord, MtdImageTableRecordAttribute>
    {
        private const int STRUCT_SIZE = 81;

        public MtdImageTableRecord Build(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException($"Expected byte array \'{nameof(bytes)}\', got \'null\' instead.");
            }
            if (bytes.Length != STRUCT_SIZE)
            {
                throw new InvalidByteArrayException($"The byte stream provided does not match the size of a valid \'{nameof(MtdImageTableRecord)}\'. Expected {STRUCT_SIZE} bytes, but received {bytes.Length}.");
            }
            MtdImageTableRecordAttributeBuilder attributeBuilder = new MtdImageTableRecordAttributeBuilder();
            return Build(attributeBuilder.Build(bytes));
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
