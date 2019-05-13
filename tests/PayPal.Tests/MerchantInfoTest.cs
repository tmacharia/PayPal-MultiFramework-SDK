using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    /// <summary>
    /// Summary description for MerchantInfoTest
    /// </summary>
    
    public class MerchantInfoTest
    {
        public static readonly string MerchantInfoJson =
            "{\"email\":\"jziaja.test.merchant-facilitator@gmail.com\"," +
            "\"first_name\":\"Dennis\"," +
            "\"last_name\":\"Doctor\"," +
            "\"business_name\":\"Medical Professionals, LLC\"," +
            "\"phone\":" + PhoneTest.PhoneJson + "," +
            "\"address\":" + InvoiceAddressTest.InvoiceAddressJson + "}";

        public static MerchantInfo GetMerchantInfo()
        {
            return JsonFormatter.ConvertFromJson<MerchantInfo>(MerchantInfoJson);
        }

        [TestCase(Category = "Unit")]
        public void MerchantInfoObjectTest()
        {
            var testObject = GetMerchantInfo();
            Assert.AreEqual("jziaja.test.merchant-facilitator@gmail.com", testObject.email);
            Assert.AreEqual("Dennis", testObject.first_name);
            Assert.AreEqual("Doctor", testObject.last_name);
            Assert.AreEqual("Medical Professionals, LLC", testObject.business_name);
            Assert.IsNotNull(testObject.phone);
            Assert.IsNotNull(testObject.address);
        }

        [TestCase(Category = "Unit")]
        public void MerchantInfoConvertToJsonTest()
        {
            Assert.IsFalse(GetMerchantInfo().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void MerchantInfoToStringTest()
        {
            Assert.IsFalse(GetMerchantInfo().ToString().Length == 0);
        }
    }
}
