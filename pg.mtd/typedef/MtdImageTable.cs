using System.Collections.Generic;
using System.Runtime.CompilerServices;
using pg.mtd.builder;
using pg.mtd.builder.attributes;
using pg.util.interfaces;

[assembly: InternalsVisibleTo("pg.mtd.test")]

namespace pg.mtd.typedef
{
    internal sealed class MtdImageTable : IBinaryFile, ISizeable
    {
        private readonly List<MtdImageTableRecord> _mtdImageTableRecords = new List<MtdImageTableRecord>();

        internal MtdImageTable(MtdImageTableAttribute attribute)
        {
            MtdImageTableRecordBuilder builder = new MtdImageTableRecordBuilder();
            foreach (MtdImageTableRecordAttribute mtdImageTableRecordAttribute in attribute.Images)
            {
                MtdImageTableRecord record = builder.Build(mtdImageTableRecordAttribute);
                _mtdImageTableRecords.Add(record);
            }
        }

        public byte[] GetBytes()
        {
            List<byte> bytes = new List<byte>();
            foreach (MtdImageTableRecord mtdImageTableRecord in _mtdImageTableRecords)
            {
                bytes.AddRange(mtdImageTableRecord.GetBytes());
            }

            return bytes.ToArray();
        }

        public uint Size()
        {
            throw new System.NotImplementedException();
        }
    }
}
