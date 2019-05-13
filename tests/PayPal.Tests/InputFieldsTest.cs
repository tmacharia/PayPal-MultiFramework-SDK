using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class InputFieldsTest
    {
        public static readonly string InputFieldsJson = "{\"allow_note\": true, \"no_shipping\": 0, \"address_override\": 1}";

        public static InputFields GetInputFields()
        {
            return JsonFormatter.ConvertFromJson<InputFields>(InputFieldsJson);
        }

        [TestCase(Category = "Unit")]
        public void InputFieldsObjectTest()
        {
            var inputFields = GetInputFields();
            Assert.IsTrue(inputFields.allow_note.Value);
            Assert.AreEqual(0, inputFields.no_shipping);
            Assert.AreEqual(1, inputFields.address_override);
        }

        [TestCase(Category = "Unit")]
        public void InputFieldsConvertToJsonTest()
        {
            Assert.IsFalse(GetInputFields().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void InputFieldsToStringTest()
        {
            Assert.IsFalse(GetInputFields().ToString().Length == 0);
        }
    }
}
