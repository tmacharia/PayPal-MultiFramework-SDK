using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    /// <summary>
    /// Summary description for PlanListTest
    /// </summary>
    
    public class PlanListTest
    {
        public static readonly string PlanListJson = "{\"plans\":[" + PlanTest.PlanJson + "]}";

        public static PlanList GetPlanList()
        {
            return JsonFormatter.ConvertFromJson<PlanList>(PlanListJson);
        }

        [TestCase(Category = "Unit")]
        public void PlanListObjectTest()
        {
            var testObject = GetPlanList();
            Assert.IsNotNull(testObject.plans);
            Assert.IsTrue(testObject.plans.Count == 1);
        }

        [TestCase(Category = "Unit")]
        public void PlanListConvertToJsonTest()
        {
            Assert.IsFalse(GetPlanList().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void PlanListToStringTest()
        {
            Assert.IsFalse(GetPlanList().ToString().Length == 0);
        }
    }
}
