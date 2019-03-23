using System.Collections.Generic;
using System.Runtime.CompilerServices;
using pg.util.interfaces;
[assembly: InternalsVisibleTo("pg.mtd.test")]

namespace pg.mtd.typedef
{
    internal sealed class MtdImageTable : IBinaryFile
    {
        private readonly List<MtdImageTableRecord> _mtdImageTableRecords = new List<MtdImageTableRecord>();

        public byte[] GetBytes()
        {
            List<byte> bytes = new List<byte>();
            foreach (MtdImageTableRecord mtdImageTableRecord in _mtdImageTableRecords)
            {
                bytes.AddRange(mtdImageTableRecord.GetBytes());
            }

            return bytes.ToArray();
        }
    }
}
