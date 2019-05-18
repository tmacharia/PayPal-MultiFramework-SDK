using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    [TestFixture(TestOf = typeof(Amount))]
    public class AmountTest
    {
        public static readonly string AmountJson = 
            "{\"total\":\"100\"," +
            "\"currency\":\"USD\"," +
            "\"details\":" + DetailsTest.DetailsJson + "}";

        public static Amount GetAmount()
        {
            return JsonFormatter.ConvertFromJson<Amount>(AmountJson);
        }

        [TestCase(Category = "Unit")]
        public void AmountObjectTest()
        {
            var amount = GetAmount();
            Assert.AreEqual("USD", amount.currency);
            Assert.AreEqual("100", amount.total);
            Assert.IsNotNull(amount.details);
        }

        [TestCase(Category = "Unit")]
        public void AmountConvertToJsonTest()
        {
            Assert.IsFalse(GetAmount().ConvertToJson().Length == 0);
        }
        
        [TestCase(Category = "Unit")]
        public void AmountToStringTest()
        {
            Assert.IsFalse(GetAmount().ToString().Length == 0);
        }
    }
}
