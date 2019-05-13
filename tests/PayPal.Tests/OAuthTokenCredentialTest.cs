using System;
using NUnit.Framework;
using PayPal.Api;
using System.Collections.Generic;
using PayPal.Exception;

namespace PayPal.Tests
{
    
    public class OAuthTokenCredentialTest : BaseTest
    {
        #region Unit Tests
        [TestCase(Category = "Unit")]
        public void OAuthTokenCredentialCtorConfigTest()
        {
            var config = new Dictionary<string, string>();
            config[BaseConstants.ClientId] = "xxx";
            config[BaseConstants.ClientSecret] = "yyy";
            var oauthTokenCredential = new OAuthTokenCredential(config);
            Assert.AreEqual("xxx", oauthTokenCredential.ClientId);
            Assert.AreEqual("yyy", oauthTokenCredential.ClientSecret);
        }

        [TestCase(Category = "Unit")]
        public void OAuthTokenCredentialCtorClientInfoTest()
        {
            var oauthTokenCredential = new OAuthTokenCredential("aaa", "bbb");
            Assert.AreEqual("aaa", oauthTokenCredential.ClientId);
            Assert.AreEqual("bbb", oauthTokenCredential.ClientSecret);
        }

        [TestCase(Category = "Unit")]
        public void OAuthTokenCredentialCtorClientInfoConfigTest()
        {
            var config = new Dictionary<string, string>();
            config[BaseConstants.ClientId] = "xxx";
            config[BaseConstants.ClientSecret] = "yyy";
            var oauthTokenCredential = new OAuthTokenCredential("aaa", "bbb", config);
            Assert.AreEqual("aaa", oauthTokenCredential.ClientId);
            Assert.AreEqual("bbb", oauthTokenCredential.ClientSecret);
        }

        [TestCase(Category = "Unit")]
        public void OAuthTokenCredentialCtorEmptyConfigTest()
        {
            var config = new Dictionary<string, string>();
            var oauthTokenCredential = new OAuthTokenCredential(config);
            Assert.IsTrue(string.IsNullOrEmpty(oauthTokenCredential.ClientId));
            Assert.IsTrue(string.IsNullOrEmpty(oauthTokenCredential.ClientSecret));
        }

        [TestCase(Category = "Unit")]
        public void OAuthTokenCredentialCtorNullValuesTest()
        {
            // If null values are passed in, OAuthTokenCredential uses the values specified in the config.
            var oauthTokenCredential = new OAuthTokenCredential(null, null, null);
            Assert.IsTrue(!string.IsNullOrEmpty(oauthTokenCredential.ClientId));
            Assert.IsTrue(!string.IsNullOrEmpty(oauthTokenCredential.ClientSecret));
        }

        [TestCase(Category = "Unit")]
        public void OAuthTokenCredentialMissingClientIdTest()
        {
            var config = ConfigManager.Instance.GetProperties();
            config[BaseConstants.ClientId] = "";
            var oauthTokenCredential = new OAuthTokenCredential("", "abc", config);
            TestingUtil.AssertThrownException<MissingCredentialException>(() => oauthTokenCredential.GetAccessToken());
        }

        [TestCase(Category = "Unit")]
        public void OAuthTokenCredentialMissingClientSecretTest()
        {
            var config = ConfigManager.Instance.GetProperties();
            config[BaseConstants.ClientSecret] = "";
            var oauthTokenCredential = new OAuthTokenCredential(config);
            TestingUtil.AssertThrownException<MissingCredentialException>(() => oauthTokenCredential.GetAccessToken());
        }
        #endregion

        #region Functional Tests
        [TestCase(Category = "Functional")]
        public void OAuthTokenCredentialGetAccessTokenTest()
        {
            try
            {
                var oauthTokenCredential = new OAuthTokenCredential();
                var accessToken = oauthTokenCredential.GetAccessToken();
                this.RecordConnectionDetails();

                Assert.IsTrue(accessToken.StartsWith("Bearer "));
            }
            catch(ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [TestCase(Category = "Functional")]
        public void OAuthTokenCredentialInvalidClientIdTest()
        {
            try
            {
                var config = ConfigManager.Instance.GetProperties();
                config[BaseConstants.ClientId] = "abc";
                var oauthTokenCredential = new OAuthTokenCredential(config);
                TestingUtil.AssertThrownException<IdentityException>(() => oauthTokenCredential.GetAccessToken());
                this.RecordConnectionDetails();
            }
            catch (ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }

        [TestCase(Category = "Functional")]
        public void OAuthTokenCredentialInvalidClientSecretTest()
        {
            try
            {
                var config = ConfigManager.Instance.GetProperties();
                config[BaseConstants.ClientSecret] = "abc";
                var oauthTokenCredential = new OAuthTokenCredential(config);
                TestingUtil.AssertThrownException<IdentityException>(() => oauthTokenCredential.GetAccessToken());
                this.RecordConnectionDetails();
            }
            catch (ConnectionException)
            {
                this.RecordConnectionDetails(false);
                throw;
            }
        }
        #endregion
    }
}
