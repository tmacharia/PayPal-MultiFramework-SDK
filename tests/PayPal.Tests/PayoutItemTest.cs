using NUnit.Framework;
using PayPal.Api;
using PayPal.Exception;
using System.Collections.Generic;

namespace PayPal.Tests
{
    
    public class PayoutItemTest : BaseTest
    {
        public static readonly string PayoutItemJson = 
            "{\"recipient_type\":\"EMAIL\"," +
            "\"amount\":" + CurrencyTest.CurrencyJson + "," +
            "\"receiver\":\"shirt-supplier-one@mail.com\"," +
            "\"note\":\"Thank you.\"," +
            "\"sender_item_id\":\"item_1\"}";

        public static PayoutItem GetPayoutItem()
        {
            return JsonFormatter.ConvertFromJson<PayoutItem>(PayoutItemJson);
        }

        [TestCase(Category = "Unit")]
        public void PayoutItemObjectTest()
        {
            var testObject = GetPayoutItem();
            Assert.IsNotNull(testObject);
            Assert.AreEqual(PayoutRecipientType.EMAIL, testObject.recipient_type);
            Assert.AreEqual("shirt-supplier-one@mail.com", testObject.receiver);
            Assert.AreEqual("Thank you.", testObject.note);
            Assert.AreEqual("item_1", testObject.sender_item_id);
            Assert.IsNotNull(testObject.amount);
        }

        [TestCase(Category = "Unit")]
        public void PayoutItemConvertToJsonTest()
        {
            var json = GetPayoutItem().ConvertToJson();
            Assert.IsFalse(json.Length == 0);
            Assert.IsTrue(json.Contains("\"recipient_type\":\"EMAIL\""));
        }

        [TestCase(Category = "Unit")]
        public void PayoutItemToStringTest()
        {
            Assert.IsFalse(GetPayoutItem().ToString().Length == 0);
        }

        [Ignore(reason: "Unknown")]
        public void PayoutItemGetTest()
        {
            try
            {
                var payoutItemId = "G2CFT8SJRB7RN";
                var payoutItemDetails = PayoutItem.Get(TestingUtil.GetApiContext(), payoutItemId);
                this.RecordConnectionDetails();
                Assert.IsNotNull(payoutItemDetails);
                Assert.AreEqual(payoutItemId, payoutItemDetails.payout_item_id);
                Assert.AreEqual("8NX77PFLN255E", payoutItemDetails.payout_batch_id);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
            }
        }

        [TestCase(Category = "Functional")]
        public void PayoutItemDetailsCancelTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                // Create a single synchronous payout with an invalid email address.
                // This will cause the status to be marked as 'UNCLAIMED', allowing
                // us to cancel the payout.
                var payoutBatch = PayoutTest.CreateSingleSynchronousPayoutBatch(apiContext);
                this.RecordConnectionDetails();

                Assert.IsNotNull(payoutBatch);
                Assert.IsNotNull(payoutBatch.items);
                Assert.IsTrue(payoutBatch.items.Count > 0);

                var payoutItem = payoutBatch.items[0];

                if (payoutItem.transaction_status == PayoutTransactionStatus.UNCLAIMED)
                {
                    var payoutItemDetails = PayoutItem.Cancel(apiContext, payoutItem.payout_item_id);
                    this.RecordConnectionDetails();

                    Assert.IsNotNull(payoutItemDetails);
                    Assert.AreEqual(PayoutTransactionStatus.RETURNED, payoutItemDetails.transaction_status);
                }
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }
    }
}