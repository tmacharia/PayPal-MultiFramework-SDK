using NUnit.Framework;
using PayPal.Api;
using System;
using System.Configuration;

namespace PayPal.Tests
{
    public class LameTests
    {
        [TestCase(Category = "Intro")]
        public void ReadSomething()
        {
            //var s = ConfigurationManager.AppSettings["PayPalLogger"];
            var a = ConfigManager.Instance.GetProperties()["mode"];

            //Console.WriteLine(s);
            Console.WriteLine(a);
        }
    }
}