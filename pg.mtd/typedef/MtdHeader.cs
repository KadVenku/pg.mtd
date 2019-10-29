using System;
using System.Runtime.CompilerServices;
using pg.mtd.builder.attributes;
using pg.util.interfaces;

[assembly: InternalsVisibleTo("pg.mtd.test")]

namespace pg.mtd.typedef
{
    internal sealed class MtdHeader : IBinaryFile, ISizeable
    {
        /*
         * No builder required.
         * Generating the MtdFile needs to automatically generate a header based on the data contained.
         */
        private readonly uint _recordCount;

        internal MtdHeader(MtdHeaderAttribute attribute)
        {
            _recordCount = attribute.RecordCount;
        }

        internal MtdHeader()
        {
            _recordCount = 0;
        }

        public byte[] GetBytes()
        {
            return BitConverter.GetBytes(_recordCount);
        }

        public uint Size()
        {
            return sizeof(uint);
        }
    }
}
