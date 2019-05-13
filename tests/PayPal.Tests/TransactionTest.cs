using System.Collections.Generic;
using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class TransactionTest
    {
        public static Transaction GetTransaction()
        {
            var transaction = new Transaction();
            transaction.description = "Test Description";
            transaction.note_to_payee = "Test note to payee";
            transaction.amount = AmountTest.GetAmount();
            transaction.payee = PayeeTest.GetPayee();
            transaction.item_list = ItemListTest.GetItemList();
            transaction.related_resources = new List<RelatedResources>();
            transaction.related_resources.Add(RelatedResourcesTest.GetRelatedResources());
            return transaction;
        }

        public static List<Transaction> GetTransactionList()
        {
            var transactionList = new List<Transaction>();
            transactionList.Add(GetTransaction());
            return transactionList;
        }

        [TestCase(Category = "Unit")]
        public void TransactionObjectTest()
        {
            var transaction = GetTransaction();
            Assert.AreEqual("Test Description", transaction.description);
            Assert.AreEqual("Test note to payee", transaction.note_to_payee);
            Assert.IsNotNull(transaction.amount);
            Assert.IsNotNull(transaction.payee);
            Assert.IsNotNull(transaction.item_list);
            Assert.IsNotNull(transaction.related_resources);
        }

        [TestCase(Category = "Unit")]
        public void TransactionConvertToJsonTest()
        {
            Assert.IsFalse(GetTransaction().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void TransactionToStringTest()
        {
            Assert.IsFalse(GetTransaction().ToString().Length == 0);
        }
    }
}
