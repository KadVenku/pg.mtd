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
    internal sealed class MtdImageTableRecord : IBinaryFile
    {
        public static readonly int SIZE = 81;

        private const int BNAME_MAX_LENGTH = 64;
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

        private IEnumerable<byte> GetBName()
        {
            byte[] bytes = new byte[BNAME_MAX_LENGTH];
            for (int i = 0; i < BNAME_MAX_LENGTH; i++)
            {
                bytes[i] = 0;
            }
            byte[] unpaddedName = Encoding.ASCII.GetBytes(_name);
            if (unpaddedName.Length > BNAME_MAX_LENGTH)
            {
                throw new InvalidIconNameException($"An MTD-element's name may only be {BNAME_MAX_LENGTH} bytes long. The element \'{_name}\' is {unpaddedName.Length} bytes long and exceeds the limit by {unpaddedName.Length - BNAME_MAX_LENGTH}.");
            }
            for (int i = 0; i < unpaddedName.Length && i < BNAME_MAX_LENGTH; i++)
            {
                bytes[i] = unpaddedName[i];
            }
            return bytes;
        }
    }
}
