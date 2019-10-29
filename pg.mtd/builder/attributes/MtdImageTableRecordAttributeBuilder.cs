using System;
using System.Runtime.CompilerServices;
using System.Text;
using pg.mtd.exceptions;
using pg.mtd.typedef;
using pg.util.interfaces;

[assembly: InternalsVisibleTo("pg.mtd.test")]

namespace pg.mtd.builder.attributes
{
    internal sealed class MtdImageTableRecordAttributeBuilder : IBinaryAttributeBuilder<MtdImageTableRecordAttribute>
    {
        private const int _C_ICON_NAME_OFFSET = 0;
        private const int _C_ICON_NAME_SIZE = 64;
        private const int _C_POSITION_X_OFFSET = 64;
        private const int _C_POSITION_Y_OFFSET = 68;
        private const int _C_EXTENSION_X_OFFSET = 72;
        private const int _C_EXTENSION_Y_OFFSET = 76;
        private const int _C_ALPHA_OFFSET = 80;

        public MtdImageTableRecordAttribute Build(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException($"Expected byte array \'{nameof(bytes)}\', got \'null\' instead.");
            }

            if (bytes.Length != new MtdImageTableRecord().Size())
            {
                throw new InvalidByteArrayException(
                    $"The byte stream provided does not match the size of a valid \'{nameof(MtdImageTableRecord)}\'. Expected {new MtdImageTableRecord().Size()} bytes, but received {bytes.Length}.");
            }

            string paddedName = Encoding.ASCII.GetString(bytes, _C_ICON_NAME_OFFSET, _C_ICON_NAME_SIZE);
            string name = Unpad(paddedName);
            uint posX = BitConverter.ToUInt32(bytes, _C_POSITION_X_OFFSET);
            uint posY = BitConverter.ToUInt32(bytes, _C_POSITION_Y_OFFSET);
            uint exX = BitConverter.ToUInt32(bytes, _C_EXTENSION_X_OFFSET);
            uint exY = BitConverter.ToUInt32(bytes, _C_EXTENSION_Y_OFFSET);
            bool alpha = BitConverter.ToBoolean(bytes, _C_ALPHA_OFFSET);
            return new MtdImageTableRecordAttribute()
            {
                Name = name,
                XPosition = posX,
                YPosition = posY,
                XExtend = exX,
                YExtend = exY,
                Alpha = alpha
            };
        }

        private static string Unpad(string paddedName)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c in paddedName)
            {
                if (c != '\0')
                {
                    builder.Append(c);
                }
            }

            return builder.ToString();
        }
    }
}
