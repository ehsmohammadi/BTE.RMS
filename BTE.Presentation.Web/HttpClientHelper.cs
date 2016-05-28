using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BTE.Presentation.Web
{
    public static class HttpClientHelper
    {
        #region Get From API

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
                var response = await client.GetAsync(endpoint);
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
                var response = await client.PostAsJsonAsync(endpoint, sendData);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T1>();
                }
                return await handleException<T1>(response);
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
                var response = await client.PutAsJsonAsync(endpoint, sendData);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T1>();
                }
                throw new Exception();
            }
        }

        #endregion

        #region Private Methods
        private static void setAcceptHeader(HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private static async Task<T> handleException<T>(HttpResponseMessage response)
        {
            var messageContent = await response.Content.ReadAsStringAsync();
            throw new Exception(messageContent);
        }

        //private static Exception convertException(HttpRequestException httpRequestException)
        //{
        //    return new Exception("api error", httpRequestException);
        //} 
        #endregion
    }
}
