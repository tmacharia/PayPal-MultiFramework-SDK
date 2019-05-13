using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    /// <summary>
    /// Summary description for AgreementTransactionsTest
    /// </summary>
    
    public class AgreementTransactionsTest
    {
        public static readonly string AgreementTransactionsJson = "{\"agreement_transaction_list\":[" + AgreementTransactionTest.AgreementTransactionJson + "]}";

        public static AgreementTransactions GetAgreementTransactions()
        {
            return JsonFormatter.ConvertFromJson<AgreementTransactions>(AgreementTransactionsJson);
        }

        [TestCase(Category = "Unit")]
        public void AgreementTransactionsObjectTest()
        {
            var testObject = GetAgreementTransactions();
            Assert.IsNotNull(testObject.agreement_transaction_list);
            Assert.IsTrue(testObject.agreement_transaction_list.Count == 1);
        }

        [TestCase(Category = "Unit")]
        public void AgreementTransactionsConvertToJsonTest()
        {
            Assert.IsFalse(GetAgreementTransactions().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void AgreementTransactionsToStringTest()
        {
            Assert.IsFalse(GetAgreementTransactions().ToString().Length == 0);
        }
    }
}
