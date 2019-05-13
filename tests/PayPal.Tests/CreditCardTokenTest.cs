using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class CreditCardTokenTest
    {
        public static CreditCardToken GetCreditCardToken()
        {
            CreditCardToken cardToken = new CreditCardToken
            {
                credit_card_id = "CARD-8PV12506MG6587946KEBHH4A",
                payer_id = "009",
                expire_month = 10,
                expire_year = 2015
            };
            return cardToken;
        }

        [TestCase(Category = "Unit")]
        public void CreditCardTokenObjectTest()
        {
            var token = GetCreditCardToken();
            Assert.AreEqual(token.credit_card_id, "CARD-8PV12506MG6587946KEBHH4A");
            Assert.AreEqual(token.payer_id, "009");
        }

        [TestCase(Category = "Unit")]
        public void CreditCardTokenConvertToJsonTest()
        {
            var token = GetCreditCardToken();
            string expected = "{\"credit_card_id\":\"CARD-8PV12506MG6587946KEBHH4A\",\"payer_id\":\"009\",\"expire_month\":10,\"expire_year\":2015}";
            string actual = token.ConvertToJson();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(Category = "Unit")]
        public void CreditCardTokenToStringTest()
        {
            Assert.IsFalse(GetCreditCardToken().ToString().Length == 0);
        }
    }
}
