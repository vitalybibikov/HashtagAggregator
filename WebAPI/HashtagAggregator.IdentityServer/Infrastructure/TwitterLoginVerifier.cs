using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HashtagAggregator.IdentityServer.Infrastructure
{
    public class TwitterLoginVerifier
    {
        private const string TwitterRequestUrl = "https://api.twitter.com/1.1/account/verify_credentials.json";
        private const string OAuthVersion = "1.0";
        private const string OauthSignatureMethod = "HMAC-SHA1";
        private const string RequestEmailQuery = "include_email=true";

        private const string BaseOAuthFormat = 
            "oauth_consumer_key={0}" +
            "&oauth_nonce={1}" +
            "&oauth_signature_method={2}" +
            "&oauth_timestamp={3}" +
            "&oauth_token={4}" +
            "&oauth_version={5}";

        private const string RequestHeaderFormat = 
            "OAuth oauth_consumer_key=\"{0}\", " +
            "oauth_nonce=\"{1}\", " +
            "oauth_signature=\"{2}\", " +
            "oauth_signature_method=\"{3}\", " +
            "oauth_timestamp=\"{4}\", " +
            "oauth_token=\"{5}\", " +
            "oauth_version=\"{6}\"";

        public async Task<string> TwitterLoginAsync(string oauthToken, string oauthTokenSecret, string oauthConsumerKey, string oauthConsumerSecret)
        {
            // unique request details
            var paramBuilder = new UniqueRequestParamsBuilder();
            var oauthNonce = paramBuilder.GetOAuthNonce();
            var oauthTimestamp = paramBuilder.GetOAuthTimeStamp();

            // create oauth signature
            var baseString = String.Format(BaseOAuthFormat,
                                        oauthConsumerKey,
                                        oauthNonce,
                                        OauthSignatureMethod,
                                        oauthTimestamp,
                                        oauthToken,
                                        OAuthVersion);

            var oauthSignature = GetAuthSignature(oauthTokenSecret, oauthConsumerSecret, baseString);

            //// create the request header
            var authHeader = String.Format(RequestHeaderFormat,
                                    Uri.EscapeDataString(oauthConsumerKey),
                                    Uri.EscapeDataString(oauthNonce),
                                    Uri.EscapeDataString(oauthSignature),
                                    Uri.EscapeDataString(OauthSignatureMethod),
                                    Uri.EscapeDataString(oauthTimestamp),
                                    Uri.EscapeDataString(oauthToken),
                                    Uri.EscapeDataString(OAuthVersion));

            var resourceUrl = TwitterRequestUrl + "?" + RequestEmailQuery;
            var dto = await SendRequest(authHeader, resourceUrl);
            return dto?.Email;
        }

        private static string GetAuthSignature(string oauthTokenSecret, string oauthConsumerSecret, string baseString)
        {
      
            baseString = String.Concat("GET&",
                Uri.EscapeDataString(TwitterRequestUrl) +
                "&" + Uri.EscapeDataString(RequestEmailQuery),
                "%26", Uri.EscapeDataString(baseString));

            var compositeKey = String.Concat(Uri.EscapeDataString(oauthConsumerSecret),
                "&", Uri.EscapeDataString(oauthTokenSecret));

            string oauthSignature;
            using (HMACSHA1 hasher = new HMACSHA1(Encoding.ASCII.GetBytes(compositeKey)))
            {
                oauthSignature = Convert.ToBase64String(
                    hasher.ComputeHash(Encoding.ASCII.GetBytes(baseString)));
            }
            return oauthSignature;
        }

        private static async Task<TwitterDto> SendRequest(string authHeader, string resourceUrl)
        {
            TwitterDto dto = null;
            var client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage();
            message.Headers.Add("Authorization", authHeader);
            message.Method = HttpMethod.Get;
            message.RequestUri = new Uri(resourceUrl);

            try
            {
                var response = await client.SendAsync(message);
                var stream = await response.Content.ReadAsStreamAsync();
                dto = JsonConvert.DeserializeObject<TwitterDto>(new StreamReader(stream).ReadToEnd());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //todo: logging here;
            }
            return dto;
        }
    }

    public class TwitterDto
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}

