using NUnit.Framework;
using PayPal;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class FundingInstrumentTest
    {
        public static FundingInstrument GetFundingInstrument()
        {
            FundingInstrument instrument = new FundingInstrument
            {
                credit_card = CreditCardTest.GetCreditCard()
            };
            return instrument;
        }

        [TestCase(Category = "Unit")]
        public void FundingInstrumentConvertToJsonTest()
        {
            Assert.IsFalse(GetFundingInstrument().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void FundingInstrumentToStringTest()
        {
            Assert.IsFalse(GetFundingInstrument().ToString().Length == 0);
        }
    }
}
