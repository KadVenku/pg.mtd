using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using pg.mtd.builder.attributes;
using pg.mtd.exceptions;
using pg.util.interfaces;

[assembly: InternalsVisibleTo("pg.mtd.test")]

namespace pg.mtd.typedef
{
    internal sealed class MtdImageTableRecord : IBinaryFile, ISizeable
    {
        private const int _C_BNAME_MAX_LENGTH = 64;
        private readonly string _name;
        private readonly uint _xPosition;
        private readonly uint _yPosition;
        private readonly uint _xExtend;
        private readonly uint _yExtend;
        private readonly bool _alpha;

        public byte[] GetBytes()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(GetBName());
            bytes.AddRange(BitConverter.GetBytes(_xPosition));
            bytes.AddRange(BitConverter.GetBytes(_yPosition));
            bytes.AddRange(BitConverter.GetBytes(_xExtend));
            bytes.AddRange(BitConverter.GetBytes(_yExtend));
            bytes.AddRange(BitConverter.GetBytes(_alpha));
            return bytes.ToArray();
        }

        internal MtdImageTableRecord(MtdImageTableRecordAttribute attribute)
        {
            _name = attribute.Name;
            _xPosition = attribute.XPosition;
            _yPosition = attribute.YPosition;
            _xExtend = attribute.XExtend;
            _yExtend = attribute.YExtend;
            _alpha = attribute.Alpha;
        }

        internal MtdImageTableRecord()
        {
            _name = string.Empty;
            _xPosition = 0;
            _yPosition = 0;
            _xExtend = 0;
            _yExtend = 0;
            _alpha = false;
        }

        private IEnumerable<byte> GetBName()
        {
            byte[] bytes = new byte[_C_BNAME_MAX_LENGTH];
            for (int i = 0; i < _C_BNAME_MAX_LENGTH; i++)
            {
                bytes[i] = 0;
            }

            byte[] unpaddedName = Encoding.ASCII.GetBytes(_name);
            if (unpaddedName.Length > _C_BNAME_MAX_LENGTH)
            {
                throw new InvalidIconNameException(
                    $"An MTD-element's name may only be {_C_BNAME_MAX_LENGTH} bytes long. The element \'{_name}\' is {unpaddedName.Length} bytes long and exceeds the limit by {unpaddedName.Length - _C_BNAME_MAX_LENGTH}.");
            }

            for (int i = 0; i < unpaddedName.Length && i < _C_BNAME_MAX_LENGTH; i++)
            {
                bytes[i] = unpaddedName[i];
            }

            return bytes;
        }

        public uint Size()
        {
            return 81u;
        }
    }
}
