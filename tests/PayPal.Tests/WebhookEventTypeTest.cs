using System;
using NUnit.Framework;
using PayPal.Api;
using PayPal.Exception;

namespace PayPal.Tests
{
    
    public class WebhookEventTypeTest : BaseTest
    {
        public static readonly string WebhookEventTypeJsonCreated = "{\"name\":\"PAYMENT.AUTHORIZATION.CREATED\"}";
        public static readonly string WebhookEventTypeJsonVoided = "{\"name\":\"PAYMENT.AUTHORIZATION.VOIDED\"}";

        public static WebhookEventType GetWebhookEventType()
        {
            return JsonFormatter.ConvertFromJson<WebhookEventType>(WebhookEventTypeJsonCreated);
        }

        [TestCase(Category = "Unit")]
        public void WebhookEventTypeObjectTest()
        {
            var testObject = GetWebhookEventType();
            Assert.AreEqual("PAYMENT.AUTHORIZATION.CREATED", testObject.name);
            Assert.IsTrue(string.IsNullOrEmpty(testObject.description));
        }

        [TestCase(Category = "Unit")]
        public void WebhookEventTypeConvertToJsonTest()
        {
            Assert.IsFalse(GetWebhookEventType().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void WebhookEventTypeToStringTest()
        {
            Assert.IsFalse(GetWebhookEventType().ToString().Length == 0);
        }

        [Ignore(reason: "Unknown")]
        public void WebhookEventTypeSubscribedEventsTest()
        {
            var webhookEventTypeList = WebhookEventType.SubscribedEventTypes(TestingUtil.GetApiContext(), "45R80540W07069023");
            Assert.IsNotNull(webhookEventTypeList);
            Assert.IsNotNull(webhookEventTypeList.event_types);
            Assert.AreEqual(2, webhookEventTypeList.event_types.Count);
        }

        [TestCase(Category = "Functional")]
        public void WebhookEventTypeAvailableEventsTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var webhookEventTypeList = WebhookEventType.AvailableEventTypes(apiContext);
                this.RecordConnectionDetails();

                Assert.IsNotNull(webhookEventTypeList);
                Assert.IsNotNull(webhookEventTypeList.event_types);
                Assert.IsTrue(webhookEventTypeList.event_types.Count > 2);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }
    }
}
