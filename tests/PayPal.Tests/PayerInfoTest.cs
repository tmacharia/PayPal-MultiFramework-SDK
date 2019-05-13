using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class PayerInfoTest
    {
        public static PayerInfo GetPayerInfo()
        {
            var info = GetPayerInfoBasic();
            info.email = "Joe.Shopper@email.com";
            info.phone = "5032141716";
            return info;
        }

        public static PayerInfo GetPayerInfoBasic()
        {
            PayerInfo info = new PayerInfo
            {
                first_name = "Joe",
                last_name = "Shopper",
                payer_id = "100"
            };
            return info;
        }

        [TestCase(Category = "Unit")]
        public void PayerInfoObjectTest()
        {
            var info = GetPayerInfo();
            Assert.AreEqual("Joe", info.first_name);
            Assert.AreEqual("Shopper", info.last_name);
            Assert.AreEqual("Joe.Shopper@email.com", info.email);
            Assert.AreEqual("100", info.payer_id);
            Assert.AreEqual("5032141716", info.phone);
        }

        [TestCase(Category = "Unit")]
        public void PayerInfoConvertToJsonTest()
        {
            Assert.IsFalse(GetPayerInfo().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void PayerInfoToStringTest()
        {
            Assert.IsFalse(GetPayerInfo().ToString().Length == 0);
        }
    }
}
