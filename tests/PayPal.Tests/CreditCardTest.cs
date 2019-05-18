using NUnit.Framework;
using PayPal;
using PayPal.Api;
using PayPal.Exception;

namespace PayPal.Tests
{
    [TestFixture(TestOf = typeof(CreditCard))]
    public class CreditCardTest : BaseTest
    {
        public static readonly string CreditCardJson = "{" +
            "\"cvv2\": \"962\"," +
            "\"expire_month\": 01," +
            "\"expire_year\": 2018," +
            "\"first_name\": \"John\"," +
            "\"last_name\": \"Doe\"," +
            "\"number\": \"4449335840161468\"," +
            "\"type\": \"visa\"," +
            "\"billing_address\": " + AddressTest.AddressJson + "}";

        public static CreditCard GetCreditCard()
        {
            return JsonFormatter.ConvertFromJson<CreditCard>(CreditCardJson);
        }

        [TestCase(Category = "Unit")]
        public void CreditCardObjectTest()
        {
            var card = GetCreditCard();
            Assert.AreEqual("4449335840161468", card.number);
            Assert.AreEqual("John", card.first_name);
            Assert.AreEqual("Doe", card.last_name);
            Assert.AreEqual(01, card.expire_month);
            Assert.AreEqual(2018, card.expire_year);
            Assert.AreEqual("962", card.cvv2);
            Assert.AreEqual("visa", card.type);
            Assert.IsNotNull(card.billing_address);
        }

        [TestCase(Category = "Unit")]        
        public void CreditCardConvertToJsonTest()
        {
            var card = GetCreditCard();
            var jsonString = card.ConvertToJson();
            var credit = JsonFormatter.ConvertFromJson<CreditCard>(jsonString);
            Assert.IsNotNull(credit);
        }

        [TestCase(Category = "Functional")]
        public void CreditCardGetTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var card = GetCreditCard();
                var createdCreditCard = card.Create(apiContext);
                this.RecordConnectionDetails();

                var retrievedCreditCard = CreditCard.Get(apiContext, createdCreditCard.id);
                this.RecordConnectionDetails();

                Assert.AreEqual(createdCreditCard.id, retrievedCreditCard.id);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [TestCase(Category = "Functional")]
        public void CreditCardDeleteTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var card = GetCreditCard();
                var createdCreditCard = card.Create(apiContext);
                this.RecordConnectionDetails();

                var retrievedCreditCard = CreditCard.Get(apiContext, createdCreditCard.id);
                this.RecordConnectionDetails();

                retrievedCreditCard.Delete(apiContext);
                this.RecordConnectionDetails();
            }
            catch (ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [Ignore(reason: "Unknown")]
        public void CreditCardListTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var creditCardList = CreditCard.List(apiContext, startTime: "2014-11-01T19:27:56Z", endTime: "2014-12-25T19:27:56Z");
                this.RecordConnectionDetails();

                Assert.IsNotNull(creditCardList);
                Assert.IsTrue(creditCardList.total_items > 0);
                Assert.IsTrue(creditCardList.total_pages > 0);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
            }
        }

        [TestCase(Category = "Functional")]
        public void CreditCardUpdateTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var creditCard = GetCreditCard().Create(apiContext);
                this.RecordConnectionDetails();

                // Create a patch request to update the credit card.
                var patchRequest = new PatchRequest
                {
                    new Patch
                    {
                        op = "replace",
                        path = "/billing_address",
                        value = new Address
                        {
                            line1 = "111 First Street",
                            city = "Saratoga",
                            country_code = "US",
                            state = "CA",
                            postal_code = "95070"
                        }
                    }
                };

                var updatedCreditCard = creditCard.Update(apiContext, patchRequest);
                this.RecordConnectionDetails();

                // Retrieve the credit card details from the vault and verify the
                // billing address was updated properly.
                var retrievedCreditCard = CreditCard.Get(apiContext, updatedCreditCard.id);
                this.RecordConnectionDetails();

                Assert.IsNotNull(retrievedCreditCard);
                Assert.IsNotNull(retrievedCreditCard.billing_address);
                Assert.AreEqual("111 First Street", retrievedCreditCard.billing_address.line1);
                Assert.AreEqual("Saratoga", retrievedCreditCard.billing_address.city);
                Assert.AreEqual("US", retrievedCreditCard.billing_address.country_code);
                Assert.AreEqual("CA", retrievedCreditCard.billing_address.state);
                Assert.AreEqual("95070", retrievedCreditCard.billing_address.postal_code);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [TestCase(Category = "Unit")]
        public void CreditCardNullIdTest()
        {
            TestingUtil.AssertThrownException<System.ArgumentNullException>(() => CreditCard.Get(new APIContext("token"), null));
        }
    }
}
