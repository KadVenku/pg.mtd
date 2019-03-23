using System;
using System.Runtime.CompilerServices;
using pg.util.interfaces;
[assembly: InternalsVisibleTo("pg.mtd.test")]

namespace pg.mtd.typedef
{
    internal sealed class MtdHeader : IBinaryFile
    {
        public static readonly int SIZE = sizeof(uint);
        /*
         * No builder requred.
         * Generating the MtdFile needs to automatically generate a headr based on the data contained.
         */
        private uint _recordCount;
        public byte[] GetBytes()
        {
            return BitConverter.GetBytes(_recordCount);
        }
    }
}
