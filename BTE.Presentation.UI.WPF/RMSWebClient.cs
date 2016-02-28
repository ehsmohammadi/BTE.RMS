using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BTE.Presentation.UI.WPF
{
    public static class RMSHttpClient
    {
        #region Get From API

        public static void Get<T>(Action<T,Exception> action, Uri baseAddress, string endpoint)
        {
            getAsync(action, baseAddress, endpoint);
        }

        private static async void getAsync<T>(Action<T, Exception> action, Uri baseAddress, string endpoint)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                setAcceptHeader(client);
                try
                {
                    var response =await client.GetAsync(endpoint);
                    response.EnsureSuccessStatusCode();
                    action(response.Content.ReadAsAsync<T>().Result, null);

                }
                catch (HttpRequestException e)
                {
                    action(default(T), e);
                }
               
            }
        }

        #endregion

        #region Post To API

        public static void Post<T1, T2>(Action<T1,Exception> action,Uri baseAddress, string endpoint, T2 sendData)
        {
            postAsync<T1, T2>(action,baseAddress, endpoint, sendData);
        }

        private static async void postAsync<T1, T2>(Action<T1, Exception> action, Uri baseAddress, string endpoint, T2 sendData)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                setAcceptHeader(client);
                try
                {
                    var response = await client.PostAsJsonAsync(endpoint, sendData);
                    response.EnsureSuccessStatusCode();
                    action(response.Content.ReadAsAsync<T1>().Result, null);
                }
                catch (HttpRequestException e)
                {

                    action(default(T1), e);
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

        private static Exception convertException(HttpRequestException httpRequestException)
        {
            return new Exception("api error", httpRequestException);
        } 

        #endregion
    }
}