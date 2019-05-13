using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    /// <summary>
    /// Summary description for AgreementTransaction
    /// </summary>
    
    public class AgreementTransactionTest
    {
        public static readonly string AgreementTransactionJson =
            "{\"transaction_id\":\"I-0LN988D3JACS\"," +
            "\"status\":\"Created\"," +
            "\"transaction_type\":\"Recurring Payment\"," +
            "\"payer_email\":\"bbuyer@example.com\"," +
            "\"payer_name\":\"Betsy Buyer\"," +
            "\"time_zone\":\"GMT\"}";

        public static AgreementTransaction GetAgreementTransaction()
        {
            return JsonFormatter.ConvertFromJson<AgreementTransaction>(AgreementTransactionJson);
        }

        [TestCase(Category = "Unit")]
        public void AgreementTransactionObjectTest()
        {
            var testObject = GetAgreementTransaction();
            Assert.AreEqual("I-0LN988D3JACS", testObject.transaction_id);
            Assert.AreEqual("Created", testObject.status);
            Assert.AreEqual("Recurring Payment", testObject.transaction_type);
            Assert.AreEqual("bbuyer@example.com", testObject.payer_email);
            Assert.AreEqual("Betsy Buyer", testObject.payer_name);
            Assert.AreEqual("GMT", testObject.time_zone);
        }

        [TestCase(Category = "Unit")]
        public void AgreementTransactionConvertToJsonTest()
        {
            Assert.IsFalse(GetAgreementTransaction().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void AgreementTransactionToStringTest()
        {
            Assert.IsFalse(GetAgreementTransaction().ToString().Length == 0);
        }
    }
}
