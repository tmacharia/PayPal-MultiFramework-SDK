using NUnit.Framework;
using PayPal.Api;
using System.Collections.Generic;

namespace PayPal.Tests
{
    
    public class PayPalResourceTest
    {
        [TestCase(Category = "Unit")]
        public void PayPalResourceEndpointOverrideNoTrailingSlashTest()
        {
            var config = new Dictionary<string, string> { {"endpoint", "http://test"} };
            Assert.AreEqual("http://test/", PayPalResource.GetEndpoint(config));
        }

        [TestCase(Category = "Unit")]
        public void PayPalResourceEndpointOverrideWithTrailingSlashTest()
        {
            var config = new Dictionary<string, string> { { "endpoint", "http://test/" } };
            Assert.AreEqual("http://test/", PayPalResource.GetEndpoint(config));
        }
        
        [TestCase(Category = "Unit")]
        public void PayPalResourceEndpointDefaultTest()
        {
            var config = new Dictionary<string, string>();
            Assert.AreEqual(BaseConstants.RESTSandboxEndpoint, PayPalResource.GetEndpoint(config));
        }

        [TestCase(Category = "Unit")]
        public void PayPalResourceEndpointSandboxModeTest()
        {
            var config = new Dictionary<string, string> { { "mode", "sandbox" } };
            Assert.AreEqual(BaseConstants.RESTSandboxEndpoint, PayPalResource.GetEndpoint(config));
        }

        [TestCase(Category = "Unit")]
        public void PayPalResourceEndpointLiveModeTest()
        {
            var config = new Dictionary<string, string> { { "mode", "live" } };
            Assert.AreEqual(BaseConstants.RESTLiveEndpoint, PayPalResource.GetEndpoint(config));
        }

        [TestCase(Category = "Unit")]
        public void PayPalResourceEndpointInvalidModeTest()
        {
            var config = new Dictionary<string, string> { { "mode", "test" } };
            Assert.AreEqual(BaseConstants.RESTSandboxEndpoint, PayPalResource.GetEndpoint(config));
        }
    }
}
