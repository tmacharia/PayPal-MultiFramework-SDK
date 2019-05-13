using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class PayoutBatchHeaderTest
    {
        public static readonly string PayoutBatchHeaderJson = 
            "{\"payout_batch_id\":\"H4HF4AT2GZXQN\"," +
            "\"batch_status\":\"PENDING\"," +
            "\"sender_batch_header\":" + PayoutSenderBatchHeaderTest.PayoutSenderBatchHeaderJson + "}";

        public static PayoutBatchHeader GetPayoutBatchHeader()
        {
            return JsonFormatter.ConvertFromJson<PayoutBatchHeader>(PayoutBatchHeaderJson);
        }

        [TestCase(Category = "Unit")]
        public void PayoutBatchHeaderObjectTest()
        {
            var testObject = GetPayoutBatchHeader();
            Assert.IsNotNull(testObject);
            Assert.AreEqual("H4HF4AT2GZXQN", testObject.payout_batch_id);
            Assert.AreEqual("PENDING", testObject.batch_status);
            Assert.IsNotNull(testObject.sender_batch_header);
        }

        [TestCase(Category = "Unit")]
        public void PayoutBatchHeaderConvertToJsonTest()
        {
            Assert.IsFalse(GetPayoutBatchHeader().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void PayoutBatchHeaderToStringTest()
        {
            Assert.IsFalse(GetPayoutBatchHeader().ToString().Length == 0);
        }
    }
}