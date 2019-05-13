using NUnit.Framework;
using System.Collections.Generic;
using PayPal;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class PayerTest
    {
        public static Payer GetPayerUsingPayPal()
        {
            var pay = new Payer
            {
                payer_info = PayerInfoTest.GetPayerInfoBasic(),
                payment_method = "paypal"
            };
            return pay;
        }

        public static Payer GetPayerUsingCreditCard()
        {
            var fundingInstrumentList = new List<FundingInstrument>
            {
                FundingInstrumentTest.GetFundingInstrument()
            };
            var pay = new Payer
            {
                funding_instruments = fundingInstrumentList,
                payer_info = PayerInfoTest.GetPayerInfo()
            };
            pay.payer_info.phone = null;
            pay.payment_method = "credit_card";
            return pay;
        }

        [TestCase(Category = "Unit")]
        public void PayerObjectTest()
        {
            var pay = GetPayerUsingCreditCard();
            Assert.AreEqual("credit_card", pay.payment_method);
            Assert.AreEqual("Joe", pay.payer_info.first_name);
            Assert.IsNotNull(pay.funding_instruments);
        }

        [TestCase(Category = "Unit")]
        public void PayerConvertToJsonTest()
        {
            Assert.IsFalse(GetPayerUsingCreditCard().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void PayerToStringTest()
        {
            Assert.IsFalse(GetPayerUsingCreditCard().ToString().Length == 0);
        }
    }    
}
