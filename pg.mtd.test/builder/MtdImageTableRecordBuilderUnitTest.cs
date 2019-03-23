using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pg.mtd.builder;
using pg.mtd.builder.attributes;
using pg.mtd.exceptions;
using pg.mtd.typedef;
using pg.util.exceptions;

namespace pg.mtd.test.builder
{
    [TestClass]
    public class MtdImageTableRecordBuilderUnitTest
    {
        private const int MTD_IMAGE_TABLE_RECORD_SIZE = sizeof(byte) * 64 + sizeof(uint) * 4 + sizeof(bool);
        private const string MTD_RECORD = "testdata\\mtd_single_record.mtd";

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
            byte[] inAsByteArray = inputAsBytes.ToArray();

            MtdImageTableRecordBuilder builder = new MtdImageTableRecordBuilder();
            MtdImageTableRecordAttribute attribute = new MtdImageTableRecordAttribute { Name = name, XPosition = posX, YPosition = posY, XExtend = exX, YExtend = exY, Alpha = alpha };
            MtdImageTableRecord record = builder.Build(attribute);
            MtdImageTableRecord recordFromBytes = builder.Build(inAsByteArray);
            byte[] bytesFromAttributes = record.GetBytes();
            byte[] bytesFromBytes = recordFromBytes.GetBytes();
            Assert.IsNotNull(bytesFromAttributes);
            Assert.IsNotNull(bytesFromBytes);
            Assert.AreEqual(MTD_IMAGE_TABLE_RECORD_SIZE, bytesFromAttributes.Length);
            Assert.AreEqual(MTD_IMAGE_TABLE_RECORD_SIZE, bytesFromBytes.Length);
            for (int i = 0; i < bytesFromAttributes.Length; i++)
            {
                Assert.AreEqual(bytesFromAttributes[i], inAsByteArray[i]);
            }
            for (int i = 0; i < bytesFromBytes.Length; i++)
            {
                Assert.AreEqual(bytesFromBytes[i], inAsByteArray[i]);
            }
        }

        [TestMethod]
        public void MtdImageTableRecordBuilderBuildMtdImageTableRecordAttributeNullTest()
        {
            MtdImageTableRecordBuilder builder = new MtdImageTableRecordBuilder();
            MtdImageTableRecordAttribute attribute = null;
            Assert.ThrowsException<AttributeNullException>(() => builder.Build(attribute));
        }

        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(7)]
        [DataRow(8)]
        [DataRow(9)]
        [DataRow(10)]
        [DataRow(11)]
        [DataRow(12)]
        [DataRow(13)]
        [DataRow(14)]
        [DataRow(15)]
        [DataRow(16)]
        [DataRow(17)]
        [DataRow(18)]
        [DataRow(19)]
        [DataRow(20)]
        [DataRow(21)]
        [DataRow(22)]
        [DataRow(23)]
        [DataRow(24)]
        [DataRow(25)]
        [DataRow(26)]
        [DataRow(27)]
        [DataRow(28)]
        [DataRow(29)]
        [DataRow(30)]
        [DataRow(31)]
        [DataRow(32)]
        [DataRow(33)]
        [DataRow(34)]
        [DataRow(35)]
        [DataRow(36)]
        [DataRow(37)]
        [DataRow(38)]
        [DataRow(39)]
        [DataRow(40)]
        [DataRow(41)]
        [DataRow(42)]
        [DataRow(43)]
        [DataRow(44)]
        [DataRow(45)]
        [DataRow(46)]
        [DataRow(47)]
        [DataRow(48)]
        [DataRow(49)]
        [DataRow(50)]
        [DataRow(51)]
        [DataRow(52)]
        [DataRow(53)]
        [DataRow(54)]
        [DataRow(55)]
        [DataRow(56)]
        [DataRow(57)]
        [DataRow(58)]
        [DataRow(59)]
        [DataRow(60)]
        [DataRow(61)]
        [DataRow(62)]
        [DataRow(63)]
        [DataRow(64)]
        [DataRow(65)]
        [DataRow(66)]
        [DataRow(67)]
        [DataRow(68)]
        [DataRow(69)]
        [DataRow(70)]
        [DataRow(71)]
        [DataRow(72)]
        [DataRow(73)]
        [DataRow(74)]
        [DataRow(75)]
        [DataRow(76)]
        [DataRow(77)]
        [DataRow(78)]
        [DataRow(79)]
        [DataRow(80)]
        [DataRow(82)]
        [DataRow(83)]
        [DataRow(84)]
        [DataRow(85)]
        [DataRow(86)]
        [DataRow(87)]
        [DataRow(88)]
        [DataRow(89)]
        [DataRow(90)]
        [DataRow(91)]
        [DataRow(92)]
        [DataRow(93)]
        [DataRow(94)]
        [DataRow(95)]
        [DataRow(96)]
        [DataRow(97)]
        [DataRow(98)]
        [DataRow(99)]
        [DataRow(100)]
        [DataRow(101)]
        [DataRow(102)]
        [DataRow(103)]
        [DataRow(104)]
        [DataRow(105)]
        [DataRow(106)]
        [DataRow(107)]
        [DataRow(108)]
        [DataRow(109)]
        [DataRow(110)]
        [DataRow(111)]
        [DataRow(112)]
        [DataRow(113)]
        [DataRow(114)]
        [DataRow(115)]
        [DataRow(116)]
        [DataRow(117)]
        [DataRow(118)]
        [DataRow(119)]
        [DataRow(120)]
        [DataRow(121)]
        [DataRow(122)]
        [DataRow(123)]
        [DataTestMethod]
        public void MtdImageTableRecordBuilderBuildMtdImageTableRecordInvalidBytesTest(int arrayLength)
        {
            MtdImageTableRecordBuilder builder = new MtdImageTableRecordBuilder();
            Assert.ThrowsException<InvalidByteArrayException>(() => builder.Build(new byte[arrayLength]));
        }

        [TestMethod]
        public void MtdImageTableRecordBuilderBuildMtdImageTableRecordNullBytesTest()
        {
            MtdImageTableRecordBuilder builder = new MtdImageTableRecordBuilder();
            byte[] bytes = null;
            Assert.ThrowsException<ArgumentNullException>(() => builder.Build(bytes));
        }

        [TestMethod]
        public void MtdImageTableRecordBuilderTest()
        {
            string s = Path.Combine(Directory.GetCurrentDirectory(), MTD_RECORD);
            byte[] array = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), MTD_RECORD));
            MtdImageTableRecordBuilder builder = new MtdImageTableRecordBuilder();
            MtdImageTableRecord e = builder.Build(array);
            Assert.IsNotNull(e);
            Assert.IsNotNull(e.GetBytes());
            Assert.AreEqual(MTD_IMAGE_TABLE_RECORD_SIZE, e.GetBytes().Length);
        }
    }
}
