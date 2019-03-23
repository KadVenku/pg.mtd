using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using pg.mtd.builder;
using pg.mtd.builder.attributes;
using pg.util.interfaces;
[assembly: InternalsVisibleTo("pg.mtd.test")]

namespace pg.mtd.typedef
{
    public sealed class MtdFile : IBinaryFile
    {
        private readonly MtdHeader _mtdHeader;
        private readonly MtdImageTable _mtdImageTable;

        public MtdFile(MtdFileAttribute attribute)
        {
            MtdImageTableBuilder mtdImageTableBuilder = new MtdImageTableBuilder();
            _mtdImageTable = mtdImageTableBuilder.Build(attribute.ImageTableAttribute);
            MtdHeaderBuilder mtdHeaderBuilder = new MtdHeaderBuilder();
            if (attribute.HeaderAttribute != null)
            {
                _mtdHeader = mtdHeaderBuilder.Build(attribute.HeaderAttribute);
            }
            else
            {
                mtdHeaderBuilder.Build(new MtdHeaderAttribute() {RecordCount = Convert.ToUInt32(attribute.ImageTableAttribute.Images.Count)});
            }
        }
        
        public byte[] GetBytes()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(_mtdHeader.GetBytes());
            bytes.AddRange(_mtdImageTable.GetBytes());
            return bytes.ToArray();
        }
    }
}
