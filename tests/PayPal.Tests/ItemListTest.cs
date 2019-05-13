using NUnit.Framework;
using System.Collections.Generic;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public class ItemListTest
    {
        public static ItemList GetItemList()
        {
            List<Item> items = new List<Item>
            {
                ItemTest.GetItem(),
                ItemTest.GetItem()
            };
            ItemList itemList = new ItemList
            {
                items = items,
                shipping_address = ShippingAddressTest.GetShippingAddress()
            };
            return itemList;
        }

        [TestCase(Category = "Unit")]
        public void ItemListObjectTest()
        {
            var list = GetItemList();
            Assert.AreEqual(ShippingAddressTest.GetShippingAddress().recipient_name, list.shipping_address.recipient_name);
            Assert.AreEqual(list.items.Count, 2);
        }

        [TestCase(Category = "Unit")]
        public void ItemListConvertToJsonTest()
        {
            Assert.IsFalse(GetItemList().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void ItemListToStringTest()
        {
            Assert.IsFalse(GetItemList().ToString().Length == 0);
        }
    }
}
