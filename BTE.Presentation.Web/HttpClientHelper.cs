using System;
using System.Collections.Generic;
//using System.Collections.Generic;
//using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.UI;

namespace BTE.Presentation.Web
{
    public static class HttpClientHelper
    {
        #region Get From API

        public enum MessageFormat { Json, Xml };

        public static T Get<T>(Uri baseAddress, string endpoint)
        {
            return getAsync<T>(baseAddress, endpoint).Result;
        }

        private static async Task<T> getAsync<T>(Uri baseAddress, string endpoint)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                setAcceptHeader(client);
                var response = client.GetAsync(endpoint).Result;
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                return await handleException<T>(response);
            }
        }

        #endregion

        #region Post To API

        public static T1 Post<T1, T2>(Uri baseAddress, string endpoint, T2 sendData)
        {
            return postAsync<T1, T2>(baseAddress, endpoint, sendData).Result;
        }

        private static async Task<T1> postAsync<T1, T2>(Uri baseAddress, string endpoint, T2 sendData)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                setAcceptHeader(client);
                var response = client.PostAsJsonAsync(endpoint, sendData).Result;
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T1>();
                }
                return await handleException<T1>(response);
            }
        }


        public static T1 PostFormUrlEncoded<T1>(Uri baseAddress, string endpoint, IEnumerable<KeyValuePair<string, string>> sendData)
        {
            return postFormUrlEncoded<T1>(baseAddress, endpoint, sendData).Result;
        }

        private static async Task<T1> postFormUrlEncoded<T1>(Uri baseAddress, string endpoint, IEnumerable<KeyValuePair<string, string>> sendData)
        {
            using (var httpClient = new HttpClient())
            {
                using (var content = new FormUrlEncodedContent(sendData))
                {
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                    HttpResponseMessage response = httpClient.PostAsync(baseAddress + endpoint, content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<T1>();
                    }
                    return await handleException<T1>(response);


                }
            }
        }


        public static void Post<T>(Uri baseAddress, string endpoint, T sendData)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                setAcceptHeader(client);
                var response = client.PostAsJsonAsync(endpoint, sendData).Result;
                if (!response.IsSuccessStatusCode)
                {
                    handleException(response);
                }
            }
        }





        #endregion

        #region Put To API

        public static T1 Put<T1, T2>(Uri baseAddress, string endpoint, T2 sendData)
        {
            return putAsync<T1, T2>(baseAddress, endpoint, sendData).Result;
        }

        private static async Task<T1> putAsync<T1, T2>(Uri baseAddress, string endpoint, T2 sendData)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                setAcceptHeader(client);
                var response = client.PutAsJsonAsync(endpoint, sendData).Result;
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T1>();
                }
                throw new Exception();
            }
        }

        public static void Put<T>(Uri baseAddress, string endpoint, T sendData)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                setAcceptHeader(client);
                var response = client.PutAsJsonAsync(endpoint, sendData).Result;
                if (!response.IsSuccessStatusCode)
                {
                    handleException(response);
                }
            }
        }

        #endregion

        #region Private Methods
        private static void setAcceptHeader(HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (ClaimsPrincipal.Current == null) return;
            var authToken = ClaimsPrincipal.Current.Identity.Name;
            client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + authToken);
        }

        private static async Task<T> handleException<T>(HttpResponseMessage response)
        {
            var messageContent = await response.Content.ReadAsStringAsync();
            throw new Exception(messageContent);
        }

        private static void handleException(HttpResponseMessage response)
        {
            var messageContent = response.Content.ReadAsStringAsync().Result;
            throw new Exception(messageContent);
        }

        //private static Exception convertException(HttpRequestException httpRequestException)
        //{
        //    return new Exception("api error", httpRequestException);
        //} 
        #endregion
    }
}
