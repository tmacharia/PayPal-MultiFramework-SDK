using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class PhoneTest
    {
        public static readonly string PhoneJson = "{\"country_code\":\"001\",\"national_number\":\"5032141716\"}";

        public static Phone GetPhone()
        {
            return JsonFormatter.ConvertFromJson<Phone>(PhoneJson);
        }

        [TestCase(Category = "Unit")]
        public void PhoneObjectTest()
        {
            var phone = GetPhone();
            Assert.AreEqual("5032141716", phone.national_number);
            Assert.AreEqual("001", phone.country_code);
        }

        [TestCase(Category = "Unit")]
        public void PhoneConvertToJsonTest()
        {
            Assert.IsFalse(GetPhone().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void PhoneToStringTest()
        {
            Assert.IsFalse(GetPhone().ToString().Length == 0);
        }
    }
}
