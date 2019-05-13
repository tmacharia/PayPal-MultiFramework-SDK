using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class MeasurementTest
    {
        public static readonly string MeasurementJson =
            "{\"value\":\"2\"," +
            "\"unit\":\"meters\"}";

        public static Measurement GetMeasurement()
        {
            return JsonFormatter.ConvertFromJson<Measurement>(MeasurementJson);
        }

        [TestCase(Category = "Unit")]
        public void MeasurementObjectTest()
        {
            var testObject = GetMeasurement();
            Assert.AreEqual("2", testObject.value);
            Assert.AreEqual("meters", testObject.unit);
        }

        [TestCase(Category = "Unit")]
        public void MeasurementConvertToJsonTest()
        {
            Assert.IsFalse(GetMeasurement().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void MeasurementToStringTest()
        {
            Assert.IsFalse(GetMeasurement().ToString().Length == 0);
        }
    }
}
