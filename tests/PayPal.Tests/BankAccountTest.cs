using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    /// <summary>
    /// Summary description for BankAccountTest
    /// </summary>
    
    public class BankAccountTest
    {
        public static BankAccount GetBankAccount()
        {
            var bankAccount = new BankAccount();
            bankAccount.account_name = "Test Account";
            bankAccount.account_number = "01234567890123456789";
            bankAccount.account_number_type = "BBAN";
            bankAccount.account_type = "CHECKING";
            bankAccount.check_type = "PERSONAL";
            bankAccount.billing_address = AddressTest.GetAddress();
            bankAccount.links = LinksTest.GetLinksList();
            return bankAccount;
        }

        [TestCase(Category = "Unit")]
        public void BankAccountObjectTest()
        {
            var bankAccount = GetBankAccount();
            Assert.AreEqual("Test Account", bankAccount.account_name);
            Assert.AreEqual("01234567890123456789", bankAccount.account_number);
            Assert.AreEqual("BBAN", bankAccount.account_number_type);
            Assert.AreEqual("CHECKING", bankAccount.account_type);
            Assert.AreEqual("PERSONAL", bankAccount.check_type);
            Assert.IsNotNull(bankAccount.billing_address);
            Assert.IsNotNull(bankAccount.links);
        }

        [TestCase(Category = "Unit")]
        public void BankAccountConvertToJsonTest()
        {
            Assert.IsFalse(GetBankAccount().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void BankAccountToStringTest()
        {
            Assert.IsFalse(GetBankAccount().ToString().Length == 0);
        }
    }
}
