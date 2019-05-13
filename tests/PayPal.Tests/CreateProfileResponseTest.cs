using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class CreateProfileResponseTest
    {
        public static readonly string CreateProfileResponseJson = "{\"id\": \"XP-VKRN-ZPNE-AXGJ-YFZM\"}";

        public static CreateProfileResponse GetCreateProfileResponse()
        {
            return JsonFormatter.ConvertFromJson<CreateProfileResponse>(CreateProfileResponseJson);
        }

        [TestCase(Category = "Unit")]
        public void CreateProfileResponseObjectTest()
        {
            var response = GetCreateProfileResponse();
            Assert.AreEqual("XP-VKRN-ZPNE-AXGJ-YFZM", response.id);
        }

        [TestCase(Category = "Unit")]
        public void CreateProfileResponseConvertToJsonTest()
        {
            Assert.IsFalse(GetCreateProfileResponse().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void CreateProfileResponseToStringTest()
        {
            Assert.IsFalse(GetCreateProfileResponse().ToString().Length == 0);
        }
    }
}
