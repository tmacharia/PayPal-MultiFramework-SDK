using System.Collections.Generic;
using NUnit.Framework;
using PayPal.Api;
using System;
using System.Net;
using PayPal.Util;

namespace PayPal.Tests
{
    
    public class Crc32Test
    {
        [TestCase(Category = "Unit")]
        public void Crc32ComputeChecksumTest()
        {
            Assert.AreEqual((uint)0x0967b587, Crc32.ComputeChecksum("test_string"));
        }
    }
}