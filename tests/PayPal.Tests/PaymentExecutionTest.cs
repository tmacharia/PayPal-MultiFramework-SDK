using NUnit.Framework;
using System.Collections.Generic;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class PaymentExecutionTest
    {
        public static PaymentExecution GetPaymentExecution()
        {
            var transactions = new List<Transaction>
            {
                TransactionTest.GetTransaction()
            };
            PaymentExecution execution = new PaymentExecution
            {
                payer_id = PayerInfoTest.GetPayerInfo().payer_id,
                transactions = transactions
            };
            return execution;
        }

        [TestCase(Category = "Unit")]
        public void PaymentExecutionObjectTest()
        {
            var execution = GetPaymentExecution();
            Assert.AreEqual(execution.payer_id, "100");
        }

        [TestCase(Category = "Unit")]
        public void PaymentExecutionConvertToJsonTest()
        {
            Assert.IsFalse(GetPaymentExecution().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void PaymentExecutionToStringTest()
        {
            Assert.IsFalse(GetPaymentExecution().ToString().Length == 0);
        }
    }
}
