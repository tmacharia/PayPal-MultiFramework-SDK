using System;
using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class WebhookListTest
    {
        public static readonly string WebhookListJson = "{\"webhooks\":[" + WebhookTest.WebhookJson + "]}";

        public static WebhookList GetWebhookList()
        {
            return JsonFormatter.ConvertFromJson<WebhookList>(WebhookListJson);
        }

        [TestCase(Category = "Unit")]
        public void WebhookListObjectTest()
        {
            var testObject = GetWebhookList();
            Assert.IsNotNull(testObject.webhooks);
            Assert.IsTrue(testObject.webhooks.Count == 1);
        }

        [TestCase(Category = "Unit")]
        public void WebhookListConvertToJsonTest()
        {
            Assert.IsFalse(GetWebhookList().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void WebhookListToStringTest()
        {
            Assert.IsFalse(GetWebhookList().ToString().Length == 0);
        }
    }
}
