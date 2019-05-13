using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    /// <summary>
    /// Summary description for AgreementStateDescriptorTest
    /// </summary>
    
    public class AgreementStateDescriptorTest
    {
        public static readonly string AgreementStateDescriptorJson = "{\"note\":\"Billing Balance Amount\",\"amount\":" + AmountTest.AmountJson + "}";

        public static AgreementStateDescriptor GetAgreementStateDescriptor()
        {
            return JsonFormatter.ConvertFromJson<AgreementStateDescriptor>(AgreementStateDescriptorJson);
        }

        [TestCase(Category = "Unit")]
        public void AgreementStateDescriptorObjectTest()
        {
            var testObject = GetAgreementStateDescriptor();
            Assert.AreEqual("Billing Balance Amount", testObject.note);
            Assert.IsNotNull(testObject.amount);
        }

        [TestCase(Category = "Unit")]
        public void AgreementStateDescriptorConvertToJsonTest()
        {
            Assert.IsFalse(GetAgreementStateDescriptor().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void AgreementStateDescriptorToStringTest()
        {
            Assert.IsFalse(GetAgreementStateDescriptor().ToString().Length == 0);
        }
    }
}
