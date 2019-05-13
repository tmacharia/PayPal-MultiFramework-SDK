using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    /// <summary>
    /// Summary description for ChargeModelsTest
    /// </summary>
    
    public class ChargeModelTest
    {
        public static readonly string ChargeModelJson = "{\"id\":\"CHM-92S85978TN737850VRWBZEUA\",\"type\":\"TAX\",\"amount\":" + CurrencyTest.CurrencyJson + "}";

        public static ChargeModel GetChargeModel()
        {
            return JsonFormatter.ConvertFromJson<ChargeModel>(ChargeModelJson);
        }

        [TestCase(Category = "Unit")]
        public void ChargeModelObjectTest()
        {
            var testObject = GetChargeModel();
            Assert.AreEqual("CHM-92S85978TN737850VRWBZEUA", testObject.id);
            Assert.AreEqual("TAX", testObject.type);
            Assert.IsNotNull(testObject.amount);
        }

        [TestCase(Category = "Unit")]
        public void ChargeModelConvertToJsonTest()
        {
            Assert.IsFalse(GetChargeModel().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void ChargeModelToStringTest()
        {
            Assert.IsFalse(GetChargeModel().ToString().Length == 0);
        }
    }
}
