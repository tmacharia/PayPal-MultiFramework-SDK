using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class RedirectUrlsTest
    {
        public static RedirectUrls GetRedirectUrls()
        {
            RedirectUrls urls = new RedirectUrls
            {
                cancel_url = "http://ebay.com/",
                return_url = "http://paypal.com/"
            };
            return urls;
        }

        [TestCase(Category = "Unit")]
        public void RedirectUrlsObjectTest()
        {
            var urls = GetRedirectUrls();
            Assert.AreEqual(urls.cancel_url, "http://ebay.com/");
            Assert.AreEqual(urls.return_url, "http://paypal.com/");
        }

        [TestCase(Category = "Unit")]
        public void RedirectUrlsConvertToJsonTest()
        {
            Assert.IsFalse(GetRedirectUrls().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void RedirectUrlsToStringTest()
        {
            Assert.IsFalse(GetRedirectUrls().ToString().Length == 0);
        }
    }
}
