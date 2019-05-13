using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class PayoutSenderBatchHeaderTest
    {
        public static readonly string PayoutSenderBatchHeaderJson = 
            "{\"sender_batch_id\":\"batch_25\"," +
            "\"email_subject\":\"You have a payment\"}";

        public static PayoutSenderBatchHeader GetPayoutSenderBatchHeader()
        {
            return JsonFormatter.ConvertFromJson<PayoutSenderBatchHeader>(PayoutSenderBatchHeaderJson);
        }

        [TestCase(Category = "Unit")]
        public void PayoutSenderBatchHeaderObjectTest()
        {
            var testObject = GetPayoutSenderBatchHeader();
            Assert.IsNotNull(testObject);
            Assert.IsTrue(!string.IsNullOrEmpty(testObject.sender_batch_id));
            Assert.AreEqual("You have a payment", testObject.email_subject);
        }

        [TestCase(Category = "Unit")]
        public void PayoutSenderBatchHeaderConvertToJsonTest()
        {
            Assert.IsFalse(GetPayoutSenderBatchHeader().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void PayoutSenderBatchHeaderToStringTest()
        {
            Assert.IsFalse(GetPayoutSenderBatchHeader().ToString().Length == 0);
        }
    }
}