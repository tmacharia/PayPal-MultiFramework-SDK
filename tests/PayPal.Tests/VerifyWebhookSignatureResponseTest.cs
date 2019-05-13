using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class VerifyWebhookSignatureResponseTest
    {
        public static readonly string VerifyWebhookSignatureResponseJson =
            "{\"verification_status\":\"TestSample\"}";


        public static VerifyWebhookSignatureResponse GetVerifyWebhookResponseSignature()
        {
            return JsonFormatter.ConvertFromJson<VerifyWebhookSignatureResponse>(VerifyWebhookSignatureResponseJson);
        }

        [TestCase(Category = "Unit")]
        public void VerifyWebhookSignatureObjectTest()
        {
            var testObject = GetVerifyWebhookResponseSignature();
            Assert.AreEqual("TestSample", testObject.verification_status);
        }
    }
}
