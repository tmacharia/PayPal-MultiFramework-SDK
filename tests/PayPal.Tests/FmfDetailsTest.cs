using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class FmfDetailsTest
    {
        public static readonly string FmfDetailsJson =
            "{\"filter_type\":\"FILTER\"," +
            "\"filter_id\":\"001\"," +
            "\"name\":\"Filter name\"," +
            "\"description\":\"Filter description\"}";

        public static FmfDetails GetFmfDetails()
        {
            return JsonFormatter.ConvertFromJson<FmfDetails>(FmfDetailsJson);
        }

        [TestCase(Category = "Unit")]
        public void FmfDetailsObjectTest()
        {
            var testObject = GetFmfDetails();
            Assert.AreEqual("FILTER", testObject.filter_type);
            Assert.AreEqual("001", testObject.filter_id);
            Assert.AreEqual("Filter name", testObject.name);
            Assert.AreEqual("Filter description", testObject.description);
        }

        [TestCase(Category = "Unit")]
        public void FmfDetailsConvertToJsonTest()
        {
            Assert.IsFalse(GetFmfDetails().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void FmfDetailsToStringTest()
        {
            Assert.IsFalse(GetFmfDetails().ToString().Length == 0);
        }
    }
}
