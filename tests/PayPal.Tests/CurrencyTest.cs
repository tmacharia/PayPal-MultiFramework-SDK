using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    /// <summary>
    /// Summary description for CurrencyTest
    /// </summary>
    
    public class CurrencyTest
    {
        public static readonly string CurrencyJson = "{\"value\":\"1\",\"currency\":\"USD\"}";

        public static Currency GetCurrency()
        {
            return JsonFormatter.ConvertFromJson<Currency>(CurrencyJson);
        }

        [TestCase(Category = "Unit")]
        public void CurrencyObjectTest()
        {
            var testObject = GetCurrency();
            Assert.AreEqual("1", testObject.value);
            Assert.AreEqual("USD", testObject.currency);
        }

        [TestCase(Category = "Unit")]
        public void CurrencyConvertToJsonTest()
        {
            Assert.IsFalse(GetCurrency().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void CurrencyToStringTest()
        {
            Assert.IsFalse(GetCurrency().ToString().Length == 0);
        }
    }
}
