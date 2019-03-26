using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Legis.UtilityLayer.Helper
{
    public static class ServiceHelper
    {
        public static async Task<string> GetToken(string filter = "")
        {
            //string uri = $"{serviceUrl}/{serviceName}";

            return await postSso(filter);
        }
        public static async Task<string> GetInfo(string serviceUrl, string serviceName)
        {
            string uri = serviceUrl + serviceName;

            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync(uri);
                return await Task.Run(() => content);
            }
        }

        public static async Task<List<T>> GetInfo<T>(string serviceUrl, string serviceName)
        {
            string uri = serviceUrl + serviceName;

            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync(uri);
                return await Task.Run(() => JsonConvert.DeserializeObject<List<T>>(content));
            }
        }

        public static async Task<T1> GetInfo<T1, T2>(string serviceUrl, string serviceName, T2 content)
        {
            string uri = serviceUrl + serviceName;
            var json = JsonConvert.SerializeObject(content);

            HttpContent httpContent = CreateHttpContent(content);

            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, uri);
                request.Content = httpContent;
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = client.SendAsync(request).Result;
                result.EnsureSuccessStatusCode();
                string response = result.Content.ReadAsStringAsync().Result;
                return await Task.Run(() => JsonConvert.DeserializeObject<T1>(response));
            }
        }

        private static HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        public static async Task<string> PostData<T>(string serviceUrl, string serviceName, T data)
        {
            string uri = serviceUrl + serviceName;

            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, uri);
                HttpContent httpContent = CreateHttpContent(data);
                var json = JsonConvert.SerializeObject(data);
                request.Content = httpContent;
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = client.SendAsync(request).Result;

                return await Task.Run(() => $"{result}");
            }
        }

        public async static Task<string> postSso(string code)
        {
            var oSso = await ChargeSsoDataHelper.ChargeSsoData();

            var uri = oSso["url_token_endpoint"];
            oSso.Add("code", code);
            
            HttpClient client = new HttpClient();

            var content = new FormUrlEncodedContent(oSso);
            var response = await client.PostAsync(uri, content);
            var responseString = await response.Content.ReadAsStringAsync();


            return responseString;
        }
    }
}
