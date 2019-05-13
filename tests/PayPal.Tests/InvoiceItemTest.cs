using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PayPal.Api;
using PayPal;

namespace PayPal.Tests
{
    /// <summary>
    /// Summary description for InvoiceItemTest
    /// </summary>
    
    public class InvoiceItemTest
    {
        public static readonly string InvoiceItemJson =
            "{\"name\":\"Sutures\"," +
            "\"quantity\":100," +
            "\"unit_price\":" + CurrencyTest.CurrencyJson + "}";

        public static InvoiceItem GetInvoiceItem()
        {
            return PayPal.Api.JsonFormatter.ConvertFromJson<InvoiceItem>(InvoiceItemJson);
        }

        [TestCase(Category = "Unit")]
        public void InvoiceItemObjectTest()
        {
            var testObject = GetInvoiceItem();
            Assert.AreEqual("Sutures", testObject.name);
            Assert.AreEqual(100, testObject.quantity);
            Assert.IsNotNull(testObject.unit_price);
        }

        [TestCase(Category = "Unit")]
        public void InvoiceItemConvertToJsonTest()
        {
            Assert.IsFalse(GetInvoiceItem().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void InvoiceItemToStringTest()
        {
            Assert.IsFalse(GetInvoiceItem().ToString().Length == 0);
        }
    }
}
