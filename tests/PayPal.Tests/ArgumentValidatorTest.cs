using System;
using NUnit.Framework;
using PayPal.Util;

namespace PayPal.Tests
{
    
    public class ArgumentValidatorTest
    {
        [TestCase(Category = "Unit")]
        public void EmptyStringMustThrow()
        {
            try
            {
                ArgumentValidator.Validate("", "EmptyString");
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is ArgumentNullException);
            }
        }

        [TestCase(Category = "Unit")]
        public void NullStringMustThrow()
        {
            try
            {
                string str = null;
                ArgumentValidator.Validate(str, "NullString");
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is ArgumentNullException);
            }
        }

        [TestCase(Category = "Unit")]
        public void BooleanMustDoesntThrow()
        {
            try
            {
                ArgumentValidator.Validate(false, "NullString");
            }
            catch (System.Exception ex)
            {
                Assert.IsFalse(ex is ArgumentNullException);
            }
        }

        [TestCase(Category = "Unit")]
        public void IntegerMustDoesntThrow()
        {
            try
            {
                ArgumentValidator.Validate(15, "NullString");
            }
            catch (System.Exception ex)
            {
                Assert.IsFalse(ex is ArgumentNullException);
            }
        }

        [TestCase(Category = "Unit")]
        public void ObjectMustDoesntThrow()
        {
            try
            {
                ArgumentValidator.Validate(new Object(), "NullString");
            }
            catch (System.Exception ex)
            {
                Assert.IsFalse(ex is ArgumentNullException);
            }
        }

        [TestCase(Category = "Unit")]
        public void NullObjectMustThrow()
        {
            try
            {
                ArgumentValidator.Validate(null, "NullString");
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is ArgumentNullException);
            }
        }

        [TestCase(Category = "Unit")]
        public void NullableBooleanMustThrow()
        {
            try
            {
                bool? nullableBool = null;
                ArgumentValidator.Validate(nullableBool, "NullString");
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is ArgumentNullException);
            }
        }
    }
}
