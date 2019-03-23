using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pg.mtd.builder;
using pg.mtd.builder.attributes;
using pg.mtd.typedef;
using pg.util.exceptions;

namespace pg.mtd.test.builder
{
    [TestClass]
    public class MtdImageTableRecordBuilderUnitTest
    {
        private const int MTD_IMAGE_TABLE_RECORD_SIZE = sizeof(byte) * 64 + sizeof(uint) * 4 + sizeof(bool);

        [DataRow("ValidName1", 1u, 1u, 1u, 1u, true)]
        [DataRow("ValidName1", 1u, 1u, 1u, 1u, false)]
        [DataRow("ValidName2", 2u, 2u, 2u, 2u, true)]
        [DataRow("ValidName2", 2u, 2u, 2u, 2u, false)]
        [DataRow("ValidName3", 3u, 3u, 3u, 3u, true)]
        [DataRow("ValidName3", 3u, 3u, 3u, 3u, false)]
        [DataRow("ValidName4", 4u, 4u, 4u, 4u, true)]
        [DataRow("ValidName4", 4u, 4u, 4u, 4u, false)]
        [DataRow("ValidName5", 5u, 5u, 5u, 5u, true)]
        [DataRow("ValidName5", 5u, 5u, 5u, 5u, false)]
        [DataRow("ValidName6", 6u, 6u, 6u, 6u, true)]
        [DataRow("ValidName6", 6u, 6u, 6u, 6u, false)]
        [DataTestMethod]
        public void MtdImageTableRecordBuilderBuildMtdImageTableRecordTest(string name, uint posX, uint posY, uint exX, uint exY, bool alpha)
        {
            MtdImageTableRecordBuilder builder = new MtdImageTableRecordBuilder();
            MtdImageTableRecordAttribute attribute = new MtdImageTableRecordAttribute { Name = name, XPosition = posX, YPosition = posY, XExtend = exX, YExtend = exY, Alpha = alpha };
            MtdImageTableRecord record = builder.Build(attribute);
            byte[] bytes = record.GetBytes();
            List<byte> inputAsBytes = new List<byte>();
            byte[] n = Encoding.ASCII.GetBytes(name);
            byte[] nPadded = new byte[64];
            for (int i = 0; i < nPadded.Length; i++)
            {
                nPadded[i] = 0;
            }

            for (int i = 0; i < n.Length && i < nPadded.Length; i++)
            {
                nPadded[i] = n[i];
            }

            inputAsBytes.AddRange(nPadded);
            inputAsBytes.AddRange(BitConverter.GetBytes(posX));
            inputAsBytes.AddRange(BitConverter.GetBytes(posY));
            inputAsBytes.AddRange(BitConverter.GetBytes(exX));
            inputAsBytes.AddRange(BitConverter.GetBytes(exY));
            inputAsBytes.AddRange(BitConverter.GetBytes(alpha));
            Assert.IsNotNull(bytes);
            Assert.AreEqual(MTD_IMAGE_TABLE_RECORD_SIZE, bytes.Length);
            byte[] inAsByteArray = inputAsBytes.ToArray();
            for (int i = 0; i < bytes.Length; i++)
            {
                Assert.AreEqual(bytes[i], inAsByteArray[i]);
            }
        }

        [TestMethod]
        public void MtdImageTableRecordBuilderBuildMtdImageTableRecordAttributeNullTest()
        {
            MtdImageTableRecordBuilder builder = new MtdImageTableRecordBuilder();
            MtdImageTableRecordAttribute attribute = null;
            Assert.ThrowsException<AttributeNullException>(() => builder.Build(attribute));
        }
    }
}
