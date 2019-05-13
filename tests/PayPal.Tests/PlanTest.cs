using NUnit.Framework;
using PayPal.Api;
using PayPal;
using System;
using PayPal.Exception;

namespace PayPal.Tests
{
    /// <summary>
    /// Summary description for PlanTest
    /// </summary>
    
    public class PlanTest : BaseTest
    {
        public static readonly string PlanJson = 
            "{\"name\":\"T-Shirt of the Month Club Plan\"," +
            "\"description\":\"Template creation.\"," +
            "\"type\":\"FIXED\"," +
            "\"payment_definitions\":[" + PaymentDefinitionTest.PaymentDefinitionJson + "]," +
            "\"merchant_preferences\":" + MerchantPreferencesTest.MerchantPreferencesJson + "}";

        public static Plan GetPlan()
        {
            return JsonFormatter.ConvertFromJson<Plan>(PlanJson);
        }

        [TestCase(Category = "Unit")]
        public void PlanObjectTest()
        {
            var testObject = GetPlan();
            Assert.AreEqual("T-Shirt of the Month Club Plan", testObject.name);
            Assert.AreEqual("Template creation.", testObject.description);
            Assert.AreEqual("FIXED", testObject.type);
            Assert.IsNotNull(testObject.payment_definitions);
            Assert.IsTrue(testObject.payment_definitions.Count == 1);
            Assert.IsNotNull(testObject.merchant_preferences);
        }

        [TestCase(Category = "Unit")]
        public void PlanConvertToJsonTest()
        {
            Assert.IsFalse(GetPlan().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void PlanToStringTest()
        {
            Assert.IsFalse(GetPlan().ToString().Length == 0);
        }

        [TestCase(Category = "Functional")]
        public void PlanCreateAndGetTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var plan = GetPlan();
                var createdPlan = plan.Create(apiContext);
                this.RecordConnectionDetails();

                Assert.IsTrue(!string.IsNullOrEmpty(createdPlan.id));
                Assert.AreEqual(plan.name, createdPlan.name);

                var retrievedPlan = Plan.Get(apiContext, createdPlan.id);
                this.RecordConnectionDetails();

                Assert.IsNotNull(retrievedPlan);
                Assert.AreEqual(createdPlan.id, retrievedPlan.id);
                Assert.AreEqual("T-Shirt of the Month Club Plan", retrievedPlan.name);
                Assert.AreEqual("Template creation.", retrievedPlan.description);
                Assert.AreEqual("FIXED", retrievedPlan.type);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [TestCase(Category = "Functional")]
        public void PlanUpdateTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                // Get a test plan for updating purposes.
                var plan = GetPlan();
                var createdPlan = plan.Create(apiContext);
                this.RecordConnectionDetails();

                var planId = createdPlan.id;

                // Create the patch request and update the description to a random value.
                var updatedDescription = Guid.NewGuid().ToString();
                var patch = new Patch
                {
                    op = "replace",
                    path = "/",
                    value = new Plan { description = updatedDescription }
                };

                var patchRequest = new PatchRequest { patch };

                // Update the plan.
                createdPlan.Update(apiContext, patchRequest);
                this.RecordConnectionDetails();

                // Verify the plan was updated successfully.
                var updatedPlan = Plan.Get(apiContext, planId);
                this.RecordConnectionDetails();

                Assert.AreEqual(planId, updatedPlan.id);
                Assert.AreEqual(updatedDescription, updatedPlan.description);
            }
            catch (ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [TestCase(Category = "Functional")]
        public void PlanListTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var planList = Plan.List(apiContext);
                this.RecordConnectionDetails();

                Assert.IsNotNull(planList);
                Assert.IsNotNull(planList.plans);
                Assert.IsTrue(planList.plans.Count > 0);
            }
            catch (ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [TestCase(Category = "Functional")]
        public void PlanDeleteTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var plan = GetPlan();
                var createdPlan = plan.Create(apiContext);
                this.RecordConnectionDetails();

                var planId = createdPlan.id;

                // Create a patch request that will delete the plan
                var patchRequest = new PatchRequest
                {
                    new Patch
                    {
                        op = "replace",
                        path = "/",
                        value = new Plan
                        {
                            state = "DELETED"
                        }
                    }
                };

                createdPlan.Update(apiContext, patchRequest);
                this.RecordConnectionDetails();

                // Attempting to retrieve the plan should result in a PayPalException being thrown.
                TestingUtil.AssertThrownException<PaymentsException>(() => Plan.Get(apiContext, planId));
                this.RecordConnectionDetails();
            }
            catch (ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }
    }
}
