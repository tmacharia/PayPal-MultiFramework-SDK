//==============================================================================
//
//  This file was auto-generated by a tool using the PayPal REST API schema.
//  More information: https://developer.paypal.com/docs/api/
//
//==============================================================================
using Newtonsoft.Json;
using PayPal.Util;

namespace PayPal.Api
{
    /// <summary>
    /// A resource representing a bank account that can be used to fund a payment.
    /// <para>
    /// See <a href="https://developer.paypal.com/docs/api/">PayPal Developer documentation</a> for more information.
    /// </para>
    /// </summary>
    public class BankAccount : PayPalRelationalObject
    {
        /// <summary>
        /// ID of the bank account being saved for later use.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
        public string id { get; set; }

        /// <summary>
        /// Account number in either IBAN (max length 34) or BBAN (max length 17) format.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "account_number")]
        public string account_number { get; set; }

        /// <summary>
        /// Type of the bank account number (International or Basic Bank Account Number). For more information refer to http://en.wikipedia.org/wiki/International_Bank_Account_Number.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "account_number_type")]
        public string account_number_type { get; set; }

        /// <summary>
        /// Routing transit number (aka Bank Code) of the bank (typically for domestic use only - for international use, IBAN includes bank code). For more information refer to http://en.wikipedia.org/wiki/Bank_code.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "routing_number")]
        public string routing_number { get; set; }

        /// <summary>
        /// Type of the bank account.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "account_type")]
        public string account_type { get; set; }

        /// <summary>
        /// A customer designated name.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "account_name")]
        public string account_name { get; set; }

        /// <summary>
        /// Type of the check when this information was obtained through a check by the facilitator or merchant.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "check_type")]
        public string check_type { get; set; }

        /// <summary>
        /// How the check was obtained from the customer, if check was the source of the information provided.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "auth_type")]
        public string auth_type { get; set; }

        /// <summary>
        /// Time at which the authorization (or check) was captured. Use this field if the user authorization needs to be captured due to any privacy requirements.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "auth_capture_timestamp")]
        public string auth_capture_timestamp { get; set; }

        /// <summary>
        /// Name of the bank.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "bank_name")]
        public string bank_name { get; set; }

        /// <summary>
        /// 2 letter country code of the Bank.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "country_code")]
        public string country_code { get; set; }

        /// <summary>
        /// Account holder's first name.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "first_name")]
        public string first_name { get; set; }

        /// <summary>
        /// Account holder's last name.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "last_name")]
        public string last_name { get; set; }

        /// <summary>
        /// Birth date of the bank account holder.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "birth_date")]
        public string birth_date { get; set; }

        /// <summary>
        /// Billing address.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "billing_address")]
        public Address billing_address { get; set; }

        /// <summary>
        /// State of this funding instrument.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "state")]
        public string state { get; set; }

        /// <summary>
        /// Confirmation status of a bank account.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "confirmation_status")]
        public string confirmation_status { get; set; }

        /// <summary>
        /// Deprecated - Use external_customer_id instead.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payer_id")]
        public string payer_id { get; set; }

        /// <summary>
        /// A unique identifier of the customer to whom this bank account belongs to. Generated and provided by the facilitator. This is required when creating or using a stored funding instrument in vault.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "external_customer_id")]
        public string external_customer_id { get; set; }

        /// <summary>
        /// A unique identifier of the merchant for which this bank account has been stored for. Generated and provided by the facilitator so it can be used to restrict the usage of the bank account to the specific merchant.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "merchant_id")]
        public string merchant_id { get; set; }

        /// <summary>
        /// A client supplied unique identifier of the bank account resource, to faciliate easy look up of the resource, via GET queries
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "external_account_id")]
        public string external_account_id { get; set; }

        /// <summary>
        /// Time the resource was created.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "create_time")]
        public string create_time { get; set; }

        /// <summary>
        /// Time the resource was last updated.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "update_time")]
        public string update_time { get; set; }

        /// <summary>
        /// Date/Time until this resource can be used to fund a payment.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "valid_until")]
        public string valid_until { get; set; }

        /// <summary>
        /// Creates a new Bank Account Resource.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <returns>BankAccount</returns>
        public BankAccount Create(APIContext apiContext)
        {
            return BankAccount.Create(apiContext, this);
        }

        /// <summary>
        /// Creates a new Bank Account Resource.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="bankAccount">The BankAccount object specifying the details of the PayPal resource to create.</param>
        /// <returns>BankAccount</returns>
        public static BankAccount Create(APIContext apiContext, BankAccount bankAccount)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);

            // Configure and send the request
            var resourcePath = "v1/vault/bank-accounts";
            return PayPalResource.ConfigureAndExecute<BankAccount>(apiContext, HttpMethod.POST, resourcePath, bankAccount.ConvertToJson());
        }

        /// <summary>
        /// Obtain the Bank Account resource for the given identifier.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="bankAccountId">Identifier of the bank account resource to obtain the data for.</param>
        /// <returns>BankAccount</returns>
        public static BankAccount Get(APIContext apiContext, string bankAccountId)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(bankAccountId, "bankAccountId");

            // Configure and send the request
            var pattern = "v1/vault/bank-accounts/{0}";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { bankAccountId });
            return PayPalResource.ConfigureAndExecute<BankAccount>(apiContext, HttpMethod.GET, resourcePath);
        }

        /// <summary>
        /// Delete the bank account resource for the given identifier.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        public void Delete(APIContext apiContext)
        {
            BankAccount.Delete(apiContext, this.id);
        }

        /// <summary>
        /// Delete the bank account resource for the given identifier.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="bankAccountId">Identifier of the bank account resource to obtain the data for.</param>
        public static void Delete(APIContext apiContext, string bankAccountId)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(bankAccountId, "bankAccountId");

            // Configure and send the request
            apiContext.MaskRequestId = true;
            var pattern = "v1/vault/bank-accounts/{0}";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { bankAccountId });
            PayPalResource.ConfigureAndExecute(apiContext, HttpMethod.DELETE, resourcePath);
        }

        /// <summary>
        /// Update information in a previously saved bank account. Only the modified fields need to be passed in the request.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="patchRequest">PatchRequest</param>
        /// <returns>BankAccount</returns>
        public BankAccount Update(APIContext apiContext, PatchRequest patchRequest)
        {
            return BankAccount.Update(apiContext, this.id, patchRequest);
        }

        /// <summary>
        /// Update information in a previously saved bank account. Only the modified fields need to be passed in the request.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="bankAccountId">ID of the bank account to update.</param>
        /// <param name="patchRequest">PatchRequest</param>
        /// <returns>BankAccount</returns>
        public static BankAccount Update(APIContext apiContext, string bankAccountId, PatchRequest patchRequest)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(bankAccountId, "bankAccountId");
            ArgumentValidator.Validate(patchRequest, "patchRequest");

            // Configure and send the request
            var pattern = "v1/vault/bank-accounts/{0}";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { bankAccountId });
            return PayPalResource.ConfigureAndExecute<BankAccount>(apiContext, HttpMethod.PATCH, resourcePath, patchRequest.ConvertToJson());
        }

        /// <summary>
        /// Retrieves a list of bank account resources.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="pageSize">Number of items to be returned in the current page size, by a GET operation. Defaults to a size of 10.</param>
        /// <param name="page">The page number to be retrieved, for the list of items, by the current GET request. Defaults to a size of 1.</param>
        /// <param name="startTime">Resource creation time  as ISO8601 date-time format (ex: 1994-11-05T13:15:30Z) that indicates the start of a range of results.</param>
        /// <param name="endTime">Resource creation time as ISO8601 date-time format (ex: 1994-11-05T13:15:30Z) that indicates the end of a range of results.</param>
        /// <param name="sortOrder">Sort based on order of results. Options include 'asc' for ascending order or 'desc' for descending order. Defaults to 'asc'.</param>
        /// <param name="sortBy">Sort based on 'create_time' or 'update_time'. Defaults to 'create_time'.</param>
        /// <param name="merchantId">Identifier the merchants who owns this resource</param>
        /// <param name="externalCustomerId">Identifier of the external customer resource to obtain the data for.</param>
        /// <param name="externalAccountId">Identifier of the external bank account resource id to obtain the data for.</param>
        /// <returns>BankAccountList</returns>
        public static BankAccountList List(APIContext apiContext, int pageSize = 10, int page = 1, string startTime = "", string endTime = "", string sortOrder = "asc", string sortBy = "create_time", string merchantId = "", string externalCustomerId = "", string externalAccountId = "")
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);

            var queryParameters = new QueryParameters();
            queryParameters["page_size"] = pageSize.ToString();
            queryParameters["page"] = page.ToString();
            queryParameters["start_time"] = startTime;
            queryParameters["end_time"] = endTime;
            queryParameters["sort_order"] = sortOrder;
            queryParameters["sort_by"] = sortBy;
            queryParameters["merchant_id"] = merchantId;
            queryParameters["external_customer_id"] = externalCustomerId;
            queryParameters["external_account_id"] = externalAccountId;

            // Configure and send the request
            var resourcePath = "v1/vault/bank-accounts" + queryParameters.ToUrlFormattedString();
            return PayPalResource.ConfigureAndExecute<BankAccountList>(apiContext, HttpMethod.GET, resourcePath);
        }
    }
}