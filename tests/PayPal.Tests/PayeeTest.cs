using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class PayeeTest
    {
        public static Payee GetPayee()
        {
            Payee pay = new Payee
            {
                merchant_id = "100",
                email = "paypaluser@email.com",
                phone = PhoneTest.GetPhone()
            };
            return pay;
        }

        [TestCase(Category = "Unit")]
        public void PayeeObjectTest()
        {
            var pay = GetPayee();
            Assert.AreEqual(pay.merchant_id, "100");
            Assert.AreEqual(pay.email, "paypaluser@email.com");
            Assert.IsNotNull(pay.phone);
        }

        [TestCase(Category = "Unit")]
        public void PayeeConvertToJsonTest()
        {
            Assert.IsFalse(GetPayee().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void PayeeToStringTest()
        {
            Assert.IsFalse(GetPayee().ToString().Length == 0);
        }
    }
}
