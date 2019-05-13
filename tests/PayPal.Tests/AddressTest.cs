using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class AddressTest
    {
        public static readonly string AddressJson =
            "{\"line1\":\"2211\"," +
            "\"line2\":\"N 1st St\"," +
            "\"city\":\"San Jose\"," +
            "\"phone\":\"5032141716\"," +
            "\"postal_code\":\"95131\"," +
            "\"state\":\"California\"," +
            "\"country_code\":\"US\"}";

        public static Address GetAddress()
        {
            return JsonFormatter.ConvertFromJson<Address>(AddressJson);
        }

        [TestCase(Category = "Unit")]
        public void AddressObjectTest()
        {
            var add = GetAddress();
            Assert.AreEqual("2211", add.line1);
            Assert.AreEqual("N 1st St", add.line2);
            Assert.AreEqual("San Jose", add.city);
            Assert.AreEqual("California", add.state);
            Assert.AreEqual("95131", add.postal_code);
            Assert.AreEqual("US", add.country_code);
            Assert.AreEqual("5032141716", add.phone);
        }

        [TestCase(Category = "Unit")]
        public void AddressConvertToJsonTest()
        {
            Assert.IsFalse(GetAddress().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void AddressToStringTest()
        {
            Assert.IsFalse(GetAddress().ToString().Length == 0);
        }
    }
}
