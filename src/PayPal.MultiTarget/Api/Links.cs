﻿using Newtonsoft.Json;
using System;

namespace PayPal.Api
{
    /// <summary>
    /// A HATEOAS (Hypermedia as the Engine of Application State) link included with most PayPal REST API resource objects.
    /// <para>
    /// See <a href="https://developer.paypal.com/docs/api/">PayPal Developer documentation</a> for more information.
    /// </para>
    /// </summary>
    public class Links : PayPalSerializableObject
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "href")]
        public string href { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "rel")]
        public string rel { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[Obsolete]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "targetSchema")]
        public HyperSchema targetSchema { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "method")]
        public string method { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[Obsolete]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "enctype")]
        public string enctype { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[Obsolete]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "schema")]
        public HyperSchema schema { get; set; }
    }
}
