using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class ShippingAddressTest
    {
        public static string ShippingAddressJson =
            "{\"recipient_name\":\"PayPalUser\"," +
            "\"line1\":\"2211\"," +
            "\"line2\":\"N 1st St\"," + 
            "\"city\":\"San Jose\"," +
            "\"phone\":\"5032141716\"," +
            "\"postal_code\":\"95131\"," +
            "\"state\":\"California\"," +
            "\"country_code\":\"US\"}";

        public static ShippingAddress GetShippingAddress()
        {
            return JsonFormatter.ConvertFromJson<ShippingAddress>(ShippingAddressJson);
        }

        [TestCase(Category = "Unit")]
        public void ShippingAddressObjectTest()
        {
            var shipping = GetShippingAddress();
            Assert.AreEqual("PayPalUser", shipping.recipient_name);
            Assert.AreEqual("2211", shipping.line1);
            Assert.AreEqual("N 1st St", shipping.line2);
            Assert.AreEqual("San Jose", shipping.city);
            Assert.AreEqual("95131", shipping.postal_code);
            Assert.AreEqual("California", shipping.state);
            Assert.AreEqual("US", shipping.country_code);
            Assert.AreEqual("5032141716", shipping.phone);
        }

        [TestCase(Category = "Unit")]
        public void ShippingAddressConvertToJsonTest()
        {
            Assert.IsFalse(GetShippingAddress().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void ShippingAddressToStringTest()
        {
            Assert.IsFalse(GetShippingAddress().ToString().Length == 0);
        }
    }
}
