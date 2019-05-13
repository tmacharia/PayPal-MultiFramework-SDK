using NUnit.Framework;
using PayPal.Api;
using PayPal.Exception;
using System;

namespace PayPal.Tests
{
    
    public class WebProfileTest : BaseTest
    {
        public static readonly string WebProfileJson =
            "{\"name\": \"Test profile\"," +
            "\"presentation\": " + PresentationTest.PresentationJson + "," +
            "\"input_fields\": " + InputFieldsTest.InputFieldsJson + "," +
            "\"flow_config\":" + FlowConfigTest.FlowConfigJson + "," +
            "\"temporary\":true}";

        public static WebProfile GetWebProfile()
        {
            return JsonFormatter.ConvertFromJson<WebProfile>(WebProfileJson);
        }

        [TestCase(Category = "Unit")]
        public void WebProfileObjectTest()
        {
            var webProfile = GetWebProfile();
            Assert.AreEqual("Test profile", webProfile.name);
            Assert.IsNotNull(webProfile.presentation);
            Assert.IsNotNull(webProfile.input_fields);
            Assert.IsNotNull(webProfile.flow_config);
            Assert.AreEqual(true, webProfile.temporary);
        }

        [TestCase(Category = "Unit")]
        public void WebProfileConvertToJsonTest()
        {
            Assert.IsFalse(GetWebProfile().ConvertToJson().Length == 0);
        }

        [TestCase(Category = "Unit")]
        public void WebProfileToStringTest()
        {
            Assert.IsFalse(GetWebProfile().ToString().Length == 0);
        }

        [TestCase(Category = "Functional")]
        public void WebProfileGetListTest()
        {
            try
            {
                // Create a new profile
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var profileName = Guid.NewGuid().ToString();
                var profile = WebProfileTest.GetWebProfile();
                profile.name = profileName;
                var createdProfile = profile.Create(apiContext);
                this.RecordConnectionDetails();

                // Get the list of profiles
                var profiles = WebProfile.GetList(apiContext);
                this.RecordConnectionDetails();

                Assert.IsNotNull(profiles);
                Assert.IsTrue(profiles.Count > 0);

                // Delete the profile
                profile.id = createdProfile.id;
                profile.Delete(apiContext);
                this.RecordConnectionDetails();
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
            }
        }

        [TestCase(Category = "Functional")]
        public void WebProfileCreateAndGetTest()
        {
            try
            {
                // Create the profile
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                var profile = WebProfileTest.GetWebProfile();
                profile.name = Guid.NewGuid().ToString();
                var response = profile.Create(apiContext);
                this.RecordConnectionDetails();

                Assert.IsNotNull(response);
                Assert.IsNotNull(response.id);

                // Get the profile
                var profileId = response.id;
                var retrievedProfile = WebProfile.Get(apiContext, profileId);
                this.RecordConnectionDetails();

                Assert.AreEqual(profileId, retrievedProfile.id);

                // Delete the profile
                retrievedProfile.Delete(apiContext);
                this.RecordConnectionDetails();
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [TestCase(Category = "Functional")]
        public void WebProfileUpdateTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                // Create a new profile
                var profileName = Guid.NewGuid().ToString();
                var profile = WebProfileTest.GetWebProfile();
                profile.name = profileName;
                var createdProfile = profile.Create(apiContext);
                this.RecordConnectionDetails();

                // Get the profile object for the new profile
                profile = WebProfile.Get(apiContext, createdProfile.id);
                this.RecordConnectionDetails();

                // Update the profile
                var newName = "New " + profileName;
                profile.name = newName;
                profile.Update(apiContext);
                this.RecordConnectionDetails();

                // Get the profile again and verify it was successfully updated.
                var retrievedProfile = WebProfile.Get(apiContext, profile.id);
                this.RecordConnectionDetails();

                Assert.AreEqual(newName, retrievedProfile.name);

                // Delete the profile
                profile.Delete(apiContext);
                this.RecordConnectionDetails();
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [TestCase(Category = "Functional")]
        public void WebProfilePartialUpdateTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                // Create a new profile
                var profileName = Guid.NewGuid().ToString();
                var profile = WebProfileTest.GetWebProfile();
                profile.name = profileName;
                var createdProfile = profile.Create(apiContext);
                this.RecordConnectionDetails();

                // Get the profile object for the new profile
                profile = WebProfile.Get(apiContext, createdProfile.id);
                this.RecordConnectionDetails();

                // Partially update the profile
                var newName = "New " + profileName;
                var patch1 = new Patch
                {
                    op = "add",
                    path = "/presentation/brand_name",
                    value = newName
                };

                var patch2 = new Patch
                {
                    op = "remove",
                    path = "/flow_config/landing_page_type"
                };

                var patchRequest = new PatchRequest
                {
                    patch1,
                    patch2
                };

                profile.PartialUpdate(apiContext, patchRequest);
                this.RecordConnectionDetails();

                // Get the profile again and verify it was successfully updated via the patch commands.
                var retrievedProfile = WebProfile.Get(apiContext, profile.id);
                this.RecordConnectionDetails();

                Assert.AreEqual(newName, retrievedProfile.presentation.brand_name);
                Assert.IsTrue(string.IsNullOrEmpty(retrievedProfile.flow_config.landing_page_type));

                // Delete the profile
                profile.Delete(apiContext);
                this.RecordConnectionDetails();
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [TestCase(Category = "Functional")]
        public void WebProfileDeleteTest()
        {
            try
            {
                var apiContext = TestingUtil.GetApiContext();
                this.RecordConnectionDetails();

                // Create a new profile
                var profileName = Guid.NewGuid().ToString();
                var profile = WebProfileTest.GetWebProfile();
                profile.name = profileName;
                var createdProfile = profile.Create(apiContext);
                this.RecordConnectionDetails();

                // Get the profile object for the new profile
                profile = WebProfile.Get(apiContext, createdProfile.id);
                this.RecordConnectionDetails();

                // Delete the profile
                profile.Delete(apiContext);
                this.RecordConnectionDetails();

                Assert.AreEqual(204, (int)PayPalResource.LastResponseDetails.Value.StatusCode);
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }
    }
}
