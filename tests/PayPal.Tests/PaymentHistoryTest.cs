using NUnit.Framework;
using System.Collections.Generic;
using PayPal;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class PaymentHistoryTest
    {
        public static PaymentHistory GetPaymentHistory()
        {
            List<Payment> paymentList = new List<Payment>
            {
                PaymentTest.GetPaymentForSale()
            };
            PaymentHistory history = new PaymentHistory
            {
                count = 1,
                payments = paymentList,
                next_id = "1"
            };
            return history;
        }

        [TestCase(Category = "Unit")]
        public void PaymentHistoryObjectTest()
        {
            var history = GetPaymentHistory();
            Assert.AreEqual(history.count, 1);
            Assert.AreEqual(history.next_id, "1");
            Assert.AreEqual(history.payments.Count, 1);
        }

        [TestCase(Category = "Unit")]
        public void PaymentHistoryConvertToJsonTest()
        {
            Assert.IsFalse(GetPaymentHistory().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void PaymentHistoryToStringTest()
        {
            Assert.IsFalse(GetPaymentHistory().ToString().Length == 0);
        }
    }
}
