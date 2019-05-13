using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    /// <summary>
    /// Summary description for OverrideChargeModelTest
    /// </summary>
    
    public class OverrideChargeModelTest
    {
        public static readonly string OverrideChargeModelJson = "{\"charge_id\":\"1234\",\"amount\":" + AmountTest.AmountJson + "}";

        public static OverrideChargeModel GetOverrideChargeModel()
        {
            return JsonFormatter.ConvertFromJson<OverrideChargeModel>(OverrideChargeModelJson);
        }

        [TestCase(Category = "Unit")]
        public void OverrideChargeModelObjectTest()
        {
            var testObject = GetOverrideChargeModel();
            Assert.AreEqual("1234", testObject.charge_id);
            Assert.IsNotNull(testObject.amount);
        }

        [TestCase(Category = "Unit")]
        public void OverrideChargeModelConvertToJsonTest()
        {
            Assert.IsFalse(GetOverrideChargeModel().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void OverrideChargeModelToStringTest()
        {
            Assert.IsFalse(GetOverrideChargeModel().ToString().Length == 0);
        }
    }
}
