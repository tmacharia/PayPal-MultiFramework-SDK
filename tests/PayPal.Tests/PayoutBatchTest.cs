using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class PayoutBatchTest
    {
        public static readonly string PayoutBatchJson = 
            "{\"batch_header\":" + PayoutBatchHeaderTest.PayoutBatchHeaderJson + "," +
            "\"links\":[{" +
                "\"href\":\"https://api.sandbox.paypal.com/v1/payments/payouts/H4HF4AT2GZXQN\"," +
                "\"rel\":\"self\"," +
                "\"method\":\"GET\"}]}";

        public static PayoutBatch GetPayoutBatch()
        {
            return JsonFormatter.ConvertFromJson<PayoutBatch>(PayoutBatchJson);
        }

        [TestCase(Category = "Unit")]
        public void PayoutBatchObjectTest()
        {
            var testObject = GetPayoutBatch();
            Assert.IsNotNull(testObject);
            Assert.IsNotNull(testObject.batch_header);
            Assert.IsNotNull(testObject.links);
            Assert.IsTrue(testObject.links.Count == 1);
        }

        [TestCase(Category = "Unit")]
        public void PayoutBatchConvertToJsonTest()
        {
            Assert.IsFalse(GetPayoutBatch().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void PayoutBatchToStringTest()
        {
            Assert.IsFalse(GetPayoutBatch().ToString().Length == 0);
        }
    }
}