//==============================================================================
//
//  This file was auto-generated by a tool using the PayPal REST API schema.
//  More information: https://developer.paypal.com/docs/api/
//
//==============================================================================
using Newtonsoft.Json;

namespace PayPal.Api
{
    /// <summary>
    /// Object used to store the currency conversion rate.
    /// <para>
    /// See <a href="https://developer.paypal.com/docs/api/">PayPal Developer documentation</a> for more information.
    /// </para>
    /// </summary>
    public class CurrencyConversion : PayPalRelationalObject
    {
        /// <summary>
        /// Date of validity for the conversion rate.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "conversion_date")]
        public string conversion_date { get; set; }

        /// <summary>
        /// 3 letter currency code
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "from_currency")]
        public string from_currency { get; set; }

        /// <summary>
        /// Amount participating in currency conversion, set to 1 as default 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "from_amount")]
        public string from_amount { get; set; }

        /// <summary>
        /// 3 letter currency code
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "to_currency")]
        public string to_currency { get; set; }

        /// <summary>
        /// Amount resulting from currency conversion.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "to_amount")]
        public string to_amount { get; set; }

        /// <summary>
        /// Field indicating conversion type applied.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "conversion_type")]
        public string conversion_type { get; set; }

        /// <summary>
        /// Allow Payer to change conversion type.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "conversion_type_changeable")]
        public bool? conversion_type_changeable { get; set; }

        /// <summary>
        /// Base URL to web applications endpoint
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "web_url")]
        public string web_url { get; set; }
    }
}