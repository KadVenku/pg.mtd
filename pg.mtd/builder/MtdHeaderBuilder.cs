using System;
using pg.mtd.builder.attributes;
using pg.mtd.exceptions;
using pg.mtd.typedef;
using pg.util.interfaces;

namespace pg.mtd.builder
{
    internal sealed class MtdHeaderBuilder : IBinaryFileBuilder<MtdHeader, MtdHeaderAttribute>
    {
        public MtdHeader Build(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException($"Expected byte array \'{nameof(bytes)}\', got \'null\' instead.");
            }

            if (bytes.Length != new MtdHeader().Size())
            {
                throw new InvalidByteArrayException(
                    $"The byte stream provided does not match the size of a valid \'{nameof(MtdHeader)}\'. Expected {new MtdHeader().Size()} bytes, but received {bytes.Length} bytes.");
            }

            MtdHeaderAttributeBuilder mtdHeaderAttributeBuilder = new MtdHeaderAttributeBuilder();
            MtdHeaderAttribute attribute = mtdHeaderAttributeBuilder.Build(bytes);
            return Build(attribute);
        }

        public MtdHeader Build(MtdHeaderAttribute attribute)
        {
            return new MtdHeader(attribute);
        }
    }
}
