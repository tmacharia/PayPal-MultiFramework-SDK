using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using PayPal.Api;

namespace PayPal.Tests
{
    
    public abstract class BaseTest
    {
        private bool hasPreviousRecordings;

        public TestContext TestContext { get; set; }

        
        public virtual void Setup()
        {
            this.hasPreviousRecordings = false;
        }

        
        public virtual void TearDown()
        {
            if(this.hasPreviousRecordings)
            {
                Trace.WriteLine("]");
            }
        }

        /// <summary>
        /// Helper method for functional tests where we want to record more details.
        /// </summary>
        /// <param name="success">True if the connection behaved correctly; false otherwise.</param>
        /// <param name="ex">The exception containing the information to be recorded.</param>
        protected void RecordConnectionDetails(bool success = true)
        {
            Trace.WriteLine(hasPreviousRecordings ? ",{" : "[{");

            bool hasRequestDetails = PayPalResource.LastRequestDetails != null && PayPalResource.LastRequestDetails.Value != null;
            bool hasResponseDetails = PayPalResource.LastResponseDetails != null && PayPalResource.LastResponseDetails.Value != null;

            Trace.WriteLine("  \"test\": \"" + this.TestContext.Test.Name + "\",");
            Trace.WriteLine("  \"success\": " + success.ToString().ToLower() + (hasRequestDetails || hasResponseDetails ? "," : ""));

            // Record the request details.
            if (hasRequestDetails)
            {
                Trace.WriteLine("  \"request\": {");
                var request = PayPalResource.LastRequestDetails.Value;
                Trace.WriteLine("    \"url\": \"" + request.Url + "\",");
                Trace.WriteLine("    \"method\": \"" + request.Method + "\",");
                Trace.WriteLine("    \"headers\": " + this.ConvertWebHeaderCollectionToJson(request.Headers) + ",");
                this.RecordBody(request.Body, (request.Headers == null ? "" : request.Headers[System.Net.HttpRequestHeader.ContentType]));
                Trace.WriteLine("  }" + (hasResponseDetails ? "," : ""));
            }

            // Record the response details, starting with any exception-related information (if provided).
            if (hasResponseDetails)
            {
                Trace.WriteLine("  \"response\": {");
                var response = PayPalResource.LastResponseDetails.Value;
                if (response.Exception != null)
                {
                    Trace.WriteLine("    \"webExceptionStatus\": \"" + response.Exception.WebExceptionStatus + "\",");
                }

                if (response.StatusCode.HasValue)
                {
                    Trace.WriteLine("    \"status\": \"" + (int)response.StatusCode + "\",");
                }

                Trace.WriteLine("    \"headers\": " + this.ConvertWebHeaderCollectionToJson(response.Headers) + ",");
                var body = response.Body;
                if(string.IsNullOrEmpty(body) && response.Exception != null)
                {
                    body = response.Exception.Response;
                }
                this.RecordBody(body, (response.Headers == null ? "" : response.Headers[System.Net.HttpResponseHeader.ContentType]));
                Trace.WriteLine("  }");
            }
            Trace.WriteLine("}");

            this.hasPreviousRecordings = true;
        }

        private string ConvertWebHeaderCollectionToJson(System.Net.WebHeaderCollection headers)
        {
            if(headers == null)
            {
                return "{}";
            }

            var headersDictionary = headers.AllKeys.ToDictionary(key => key, key => headers[key]);
            return "{" + string.Join(", ", headersDictionary.Select(x => string.Format("\"{0}\": \"{1}\"", x.Key, x.Value))) + "}";
        }

        private void RecordBody(string body, string contentType)
        {
            Trace.Write("    \"body\": ");
            if (string.IsNullOrEmpty(body))
            {
                Trace.WriteLine("\"\"");
            }
            else
            {
                Trace.WriteLine(string.Format(contentType == BaseConstants.ContentTypeHeaderJson ? "{0}" : "\"{0}\"", body));
            }
        }
    }
}
