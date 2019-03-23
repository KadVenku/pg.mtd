using System;
using System.Runtime.CompilerServices;
using System.Text;
using pg.mtd.builder.attributes;
using pg.mtd.exceptions;
using pg.mtd.typedef;
using pg.util.exceptions;
using pg.util.interfaces;
[assembly: InternalsVisibleTo("pg.mtd.test")]

namespace pg.mtd.builder
{
    internal sealed class MtdImageTableRecordBuilder : IBinaryFileBuilder<MtdImageTableRecord, MtdImageTableRecordAttribute>
    {
        private const int ICON_NAME_OFFSET = 0;
        private const int ICON_NAME_SIZE = 64;
        private const int POSITION_X_OFFSET = 64;
        private const int POSITION_Y_OFFSET = 68;
        private const int EXTENSION_X_OFFSET = 72;
        private const int EXTENSION_Y_OFFSET = 76;
        private const int ALPHA_OFFSET = 80;

        private const int STRUCT_SIZE = 81;

        public MtdImageTableRecord Build(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException($"Expected byte array \'{nameof(bytes)}\', got \'null\' instead.");
            }
            if (bytes.Length != STRUCT_SIZE)
            {
                throw new InvalidByteArrayException($"The byte stream provided does not match the size of a valid \'{nameof(MtdImageTableRecord)}\'. Expected {STRUCT_SIZE} bytes, but received {bytes.Length}.");
            }
            string paddedName = Encoding.ASCII.GetString(bytes, ICON_NAME_OFFSET, ICON_NAME_SIZE);
            string name = Unpad(paddedName);
            uint posX = BitConverter.ToUInt32(bytes, POSITION_X_OFFSET);
            uint posY = BitConverter.ToUInt32(bytes, POSITION_Y_OFFSET);
            uint exX = BitConverter.ToUInt32(bytes, EXTENSION_X_OFFSET);
            uint exY = BitConverter.ToUInt32(bytes, EXTENSION_Y_OFFSET);
            bool alpha = BitConverter.ToBoolean(bytes, ALPHA_OFFSET);

            return Build(new MtdImageTableRecordAttribute(){Name = name, XPosition = posX, YPosition = posY, XExtend = exX, YExtend = exY, Alpha = alpha});
        }

        private static string Unpad(string paddedName)
        {
            string unpaddedName = "";
            foreach (char c in paddedName)
            {
                if (c != '\0')
                {
                    unpaddedName += c;
                }
            }
            return unpaddedName;
        }

        public MtdImageTableRecord Build(MtdImageTableRecordAttribute attribute)
        {
            if (attribute == null)
            {
                throw new AttributeNullException($"Building an instance of \'{nameof(MtdImageTableRecord)}\' requires a non-null argument of type \'{nameof(MtdImageTableRecordAttribute)}\'.");
            }
            return new MtdImageTableRecord(attribute);
        }
    }
}
