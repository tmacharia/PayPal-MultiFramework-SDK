using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    /// <summary>
    /// Summary description for ShippingInfoTest
    /// </summary>
    
    public class ShippingInfoTest
    {
        public static readonly string ShippingInfoJson =
            "{\"first_name\":\"Sally\"," +
            "\"last_name\":\"Patient\"," +
            "\"business_name\":\"Not applicable\"," +
            "\"address\":" + InvoiceAddressTest.InvoiceAddressJson + "}";

        public static ShippingInfo GetShippingInfo()
        {
            return JsonFormatter.ConvertFromJson<ShippingInfo>(ShippingInfoJson);
        }

        [TestCase(Category = "Unit")]
        public void ShippingInfoObjectTest()
        {
            var testObject = GetShippingInfo();
            Assert.AreEqual("Sally", testObject.first_name);
            Assert.AreEqual("Patient", testObject.last_name);
            Assert.AreEqual("Not applicable", testObject.business_name);
            Assert.IsNotNull(testObject.address);
        }

        [TestCase(Category = "Unit")]
        public void ShippingInfoConvertToJsonTest()
        {
            Assert.IsFalse(GetShippingInfo().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void ShippingInfoToStringTest()
        {
            Assert.IsFalse(GetShippingInfo().ToString().Length == 0);
        }
    }
}
