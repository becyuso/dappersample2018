using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace dappersampleApi2018.ApiHelper
{
    public class ApiHelper
    {
        public static T GetResponseDataSingle<T>(string api, Dictionary<string, object> conditions)
        {
            return GetResponseDataSingle<T>(GetWebConfigSetting(), api, conditions);
        }

        public static T GetResponseDataSingle<T>(string uri, string api, Dictionary<string, object> conditions)
        {
            return (api.Equals("")) ? default(T) : DeserializeObject<T>(SendRequestToAPI(uri, api, conditions));
        }

        public static List<T> GetResponseData<T>(string api, Dictionary<string, object> conditions)
        {
            return GetResponseData<T>(GetWebConfigSetting(), api, conditions);
        }

        public static List<T> GetResponseData<T>(string uri, string api, Dictionary<string, object> conditions)
        {
            return (api.Equals("")) ? new List<T>() : DeserializeList<T>(SendRequestToAPI(uri, api, conditions));
        }

        public static bool SendRequest(string api, Dictionary<string, object> conditions)
        {
            return SendRequestToAPI(GetWebConfigSetting(), api, conditions).Equals("true") ? true : false;
        }

        public static string SendRequestToAPI(string api, object request)
        {
            return SendRequestToAPI(GetWebConfigSetting(), api, request);
        }

        public static T GetResponseObject<T>(string api, string action, Dictionary<string, object> conditions)
        {
            return DeserializeObject<T>(SendRequestToAPI(GetWebConfigSetting(), api, action, conditions));
        }

        public static List<T> GetResponseList<T>(string api, string action, Dictionary<string, object> conditions)
        {
            return DeserializeObject<List<T>>(SendRequestToAPI(GetWebConfigSetting(), api, action, conditions));
        }

        private static string SendRequestToAPI(string uri, string api, string action, object requests)
        {
            string json = JsonConvert.SerializeObject(requests);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsync(string.Format("api/{0}/{1}", api, action), content).Result;
            return response.IsSuccessStatusCode ? response.Content.ReadAsStringAsync().Result : "";
        }

        private static string SendRequestToAPI(string uri, string api, object request)
        {
            string jsonText = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(jsonText, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsync(string.Format("api/{0}/Post", api), content).Result;
            var asdfda = response.Content.ReadAsStringAsync();
            return response.IsSuccessStatusCode ? response.Content.ReadAsStringAsync().Result : "";
        }

        public static T DeserializeObject<T>(string value)
        {
            if (value != default(string) && value.Length > 0)
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(value);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return default(T);
        }

        public static List<T> DeserializeList<T>(string value)
       {
            if (value != default(string) && value.Length > 0)
            {
                try
                {
                    var dadfasd = JsonConvert.DeserializeObject<List<T>>(value);
                    return JsonConvert.DeserializeObject<List<T>>(value);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return default(List<T>);
        }

        private static string GetWebConfigSetting()
        {
            return WebConfigurationManager.AppSettings.Get("Api");
        }
    }

    //public class QueryCondition
    //{
    //    public List<WhereExpression> Conditions { get; set; }
    //    public WhereExpression.OperatorEnum Operator { get; set; }
    //}
}