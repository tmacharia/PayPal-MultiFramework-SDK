using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class PayoutItemDetailsTest
    {
        public static readonly string PayoutItemDetailsJson = 
            "{\"payout_item_id\":\"7SB2EHDQ8MWCS\"," +
            "\"transaction_status\":\"PENDING\"," +
            "\"payout_item_fee\":" + CurrencyTest.CurrencyJson + "," +
            "\"payout_batch_id\":\"CFBTNR3EKL8A8\"," +
            "\"payout_item\":" + PayoutItemTest.PayoutItemJson + "," +
            "\"links\":[{" +
                "\"href\":\"https://api.sandbox.paypal.com/v1/payments/payouts-item/7SB2EHDQ8MWCS\"," +
                "\"rel\":\"item\"," +
                "\"method\":\"GET\"}]}";

        public static PayoutItemDetails GetPayoutItemDetails()
        {
            return JsonFormatter.ConvertFromJson<PayoutItemDetails>(PayoutItemDetailsJson);
        }

        [TestCase(Category = "Unit")]
        public void PayoutItemDetailsObjectTest()
        {
            var testObject = GetPayoutItemDetails();
            Assert.IsNotNull(testObject);
            Assert.AreEqual("7SB2EHDQ8MWCS", testObject.payout_item_id);
            Assert.AreEqual(PayoutTransactionStatus.PENDING, testObject.transaction_status);
            Assert.AreEqual("CFBTNR3EKL8A8", testObject.payout_batch_id);
            Assert.IsNotNull(testObject.payout_item_fee);
            Assert.IsNotNull(testObject.payout_item);
            Assert.IsNotNull(testObject.links);
        }

        [TestCase(Category = "Unit")]
        public void PayoutItemDetailsConvertToJsonTest()
        {
            Assert.IsFalse(GetPayoutItemDetails().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void PayoutItemDetailsToStringTest()
        {
            Assert.IsFalse(GetPayoutItemDetails().ToString().Length == 0);
        }
    }
}