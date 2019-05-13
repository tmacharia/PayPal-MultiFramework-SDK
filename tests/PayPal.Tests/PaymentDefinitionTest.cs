using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    /// <summary>
    /// Summary description for PaymentDefinitionTest
    /// </summary>
    
    public class PaymentDefinitionTest
    {
        public static readonly string PaymentDefinitionJson = 
            "{\"name\":\"Regular Payments\"," +
		    "\"type\":\"REGULAR\"," +
		    "\"frequency\":\"MONTH\"," +
		    "\"frequency_interval\":\"2\"," +
		    "\"amount\":" + CurrencyTest.CurrencyJson + "," +
		    "\"cycles\":\"12\"," +
		    "\"charge_models\":[" + ChargeModelTest.ChargeModelJson + "]}";

        public static PaymentDefinition GetPaymentDefinition()
        {
            return JsonFormatter.ConvertFromJson<PaymentDefinition>(PaymentDefinitionJson);
        }

        [TestCase(Category = "Unit")]
        public void PaymentDefinitionObjectTest()
        {
            var testObject = GetPaymentDefinition();
            Assert.AreEqual("Regular Payments", testObject.name);
            Assert.AreEqual("REGULAR", testObject.type);
            Assert.AreEqual("MONTH", testObject.frequency);
            Assert.AreEqual("2", testObject.frequency_interval);
            Assert.AreEqual("12", testObject.cycles);
            Assert.IsNotNull(testObject.amount);
            Assert.IsNotNull(testObject.charge_models);
            Assert.IsTrue(testObject.charge_models.Count == 1);
        }

        [TestCase(Category = "Unit")]
        public void PaymentDefinitionConvertToJsonTest()
        {
            Assert.IsFalse(GetPaymentDefinition().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void PaymentDefinitionToStringTest()
        {
            Assert.IsFalse(GetPaymentDefinition().ToString().Length == 0);
        }
    }
}
