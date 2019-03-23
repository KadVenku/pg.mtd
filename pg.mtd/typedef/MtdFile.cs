using System.Collections.Generic;
using System.Runtime.CompilerServices;
using pg.util.interfaces;
[assembly: InternalsVisibleTo("pg.mtd.test")]

namespace pg.mtd.typedef
{
    public sealed class MtdFile : IBinaryFile
    {
        private readonly MtdHeader _mtdHeader;
        private readonly MtdImageTable _mtdImageTable;

        public byte[] GetBytes()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(_mtdHeader.GetBytes());
            bytes.AddRange(_mtdImageTable.GetBytes());
            return bytes.ToArray();
        }
    }
}
