using NUnit.Framework;
using PayPal.Api;
using PayPal.Exception;
using System.Collections.Generic;

namespace PayPal.Tests
{
    
    public class PayoutTest : BaseTest
    {
        public static readonly string PayoutJson = 
            "{\"sender_batch_header\":" + PayoutSenderBatchHeaderTest.PayoutSenderBatchHeaderJson + "," +
            "\"items\":[" + PayoutItemTest.PayoutItemJson + "]}";

        public static Payout GetPayout()
        {
            return JsonFormatter.ConvertFromJson<Payout>(PayoutJson);
        }

        [TestCase(Category = "Unit")]
        public void PayoutObjectTest()
        {
            var testObject = GetPayout();
            Assert.IsNotNull(testObject);
            Assert.IsNotNull(testObject.sender_batch_header);
            Assert.IsNotNull(testObject.items);
            Assert.IsTrue(testObject.items.Count == 1);
        }

        [TestCase(Category = "Unit")]
        public void PayoutConvertToJsonTest()
        {
            Assert.IsFalse(GetPayout().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void PayoutToStringTest()
        {
            Assert.IsFalse(GetPayout().ToString().Length == 0);
        }

        [TestCase(Category = "Functional")]
        public void PayoutCreateAndGetTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var payout = PayoutTest.GetPayout();
                var payoutSenderBatchId = "batch_" + System.Guid.NewGuid().ToString().Substring(0, 8);
                payout.sender_batch_header.sender_batch_id = payoutSenderBatchId;
                var createdPayout = payout.Create(apiContext, false);
                this.RecordConnectionDetails();

                Assert.IsNotNull(createdPayout);
                Assert.IsTrue(!string.IsNullOrEmpty(createdPayout.batch_header.payout_batch_id));
                Assert.AreEqual(payoutSenderBatchId, createdPayout.batch_header.sender_batch_header.sender_batch_id);

                var payoutBatchId = createdPayout.batch_header.payout_batch_id;
                var retrievedPayout = Payout.Get(apiContext, payoutBatchId);
                this.RecordConnectionDetails();

                Assert.IsNotNull(payout);
                Assert.AreEqual(payoutBatchId, retrievedPayout.batch_header.payout_batch_id);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [Ignore(reason: "Unknown")]
        public static PayoutBatch CreateSingleSynchronousPayoutBatch(APIContext apiContext)
        {
            return Payout.Create(apiContext, new Payout
            {
                sender_batch_header = new PayoutSenderBatchHeader
                {
                    sender_batch_id = "batch_" + System.Guid.NewGuid().ToString().Substring(0, 8),
                    email_subject = "You have a Payout!"
                },
                items = new List<PayoutItem>
                {
                    new PayoutItem
                    {
                        recipient_type = PayoutRecipientType.EMAIL,
                        amount = new Currency
                        {
                            value = "1.0",
                            currency = "USD"
                        },
                        note = "Thanks for the payment!",
                        sender_item_id = "2014031400023",
                        receiver = "shirt-supplier-one@gmail.com"
                    }
                }
            },
            true);
        }
    }
}
