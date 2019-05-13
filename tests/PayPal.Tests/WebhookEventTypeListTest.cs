using System;
using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class WebhookEventTypeListTest
    {
        public static readonly string WebhookEventTypeListJson = 
            "{\"event_types\": [" +
            WebhookEventTypeTest.WebhookEventTypeJsonCreated + "," +
            WebhookEventTypeTest.WebhookEventTypeJsonVoided + "]}";

        public static WebhookEventTypeList GetWebhookEventTypeList()
        {
            return JsonFormatter.ConvertFromJson<WebhookEventTypeList>(WebhookEventTypeListJson);
        }

        [TestCase(Category = "Unit")]
        public void WebhookEventTypeListObjectTest()
        {
            var testObject = GetWebhookEventTypeList();
            Assert.IsNotNull(testObject.event_types);
            Assert.IsTrue(testObject.event_types.Count == 2);
        }

        [TestCase(Category = "Unit")]
        public void WebhookEventTypeListConvertToJsonTest()
        {
            Assert.IsFalse(GetWebhookEventTypeList().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void WebhookEventTypeListToStringTest()
        {
            Assert.IsFalse(GetWebhookEventTypeList().ToString().Length == 0);
        }
    }
}
