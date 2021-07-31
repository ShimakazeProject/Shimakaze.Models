﻿
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shimakaze.Models.Csf.Serialization;

namespace Shimakaze.Models.Csf.Test
{
    [TestClass]
    public class CsfExtraValueSerializerTest : SerializerTestBase<CsfValueSerializer, CsfValue>
    {
        protected override byte[] TestData => new byte[]
        {
            0x57, 0x52, 0x54, 0x53,
            0x05, 0x00, 0x00, 0x00,
            0xB5, 0xAA, 0x26, 0x70, 0xD1, 0xFF, 0xD1, 0xFF, 0xD1, 0xFF,
            0x13, 0x00, 0x00, 0x00,
            0x77, 0x68, 0x61, 0x74, 0x27, 0x73, 0x20, 0x66, 0x78, 0x78, 0x6B, 0x69, 0x6E, 0x67, 0x20, 0x74, 0x68, 0x69, 0x73
        };

        protected override CsfValue TestObject => new CsfExtraValue("啊这...", "what's fxxking this");

    }
}