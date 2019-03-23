using System;
using pg.util.interfaces;

namespace pg.mtd.builder.attributes
{
    internal class MtdHeaderAttributeBuilder : IBinaryAttributeBuilder<MtdHeaderAttribute>
    {
        public MtdHeaderAttribute Build(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException($"Expected byte array \'{nameof(bytes)}\', got \'null\' instead.");
            }
            return new MtdHeaderAttribute {RecordCount = BitConverter.ToUInt32(bytes, 0)};
        }
    }
}