using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class InvoiceAddressTest
    {
        public static readonly string InvoiceAddressJson =
            "{\"line1\":\"2211\"," +
            "\"line2\":\"N 1st St\"," +
            "\"city\":\"San Jose\"," +
            "\"phone\":" + PhoneTest.PhoneJson + "," +
            "\"postal_code\":\"95131\"," +
            "\"state\":\"California\"," +
            "\"country_code\":\"US\"}";

        public static InvoiceAddress GetInvoiceAddress()
        {
            return JsonFormatter.ConvertFromJson<InvoiceAddress>(InvoiceAddressJson);
        }

        [TestCase(Category = "Unit")]
        public void AddressObjectTest()
        {
            var add = GetInvoiceAddress();
            Assert.AreEqual("2211", add.line1);
            Assert.AreEqual("N 1st St", add.line2);
            Assert.AreEqual("San Jose", add.city);
            Assert.AreEqual("California", add.state);
            Assert.AreEqual("95131", add.postal_code);
            Assert.AreEqual("US", add.country_code);
            Assert.IsNotNull(add.phone);
        }

        [TestCase(Category = "Unit")]
        public void AddressConvertToJsonTest()
        {
            Assert.IsFalse(GetInvoiceAddress().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void AddressToStringTest()
        {
            Assert.IsFalse(GetInvoiceAddress().ToString().Length == 0);
        }
    }
}
