﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PayPal.Api
{
    /// <summary>
    /// Details of an Error
    /// <para>
    /// See <a href="https://developer.paypal.com/docs/api/">PayPal Developer documentation</a> for more information.
    /// </para>
    /// </summary>
    public class Error : PayPalSerializableObject
    {
        /// <summary>
        /// Human readable, unique name of the error.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "name")]
        public string name { get; set; }

        /// <summary>
        /// Reference ID of the purchase_unit associated with this error
        /// </summary>
        [Obsolete]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "purchase_unit_reference_id")]
        public string purchase_unit_reference_id { get; set; }

        /// <summary>
        /// PayPal internal identifier used for correlation purposes.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "debug_id")]
        public string debug_id { get; set; }

        /// <summary>
        /// Message describing the error.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "message")]
        public string message { get; set; }

        /// <summary>
        /// PayPal internal error code.
        /// </summary>
        [Obsolete]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "code")]
        public string code { get; set; }

        /// <summary>
        /// Additional details of the error
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "details")]
        public List<ErrorDetails> details { get; set; }

        /// <summary>
        /// URI for detailed information related to this error for the developer.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "information_link")]
        public string information_link { get; set; }
    }
}
