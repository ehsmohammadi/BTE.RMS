using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BTE.Presentation.UI.WPF
{
    public static class RMSHttpClient
    {
        #region Public methods

        public static async void Get<T>(Action<T, Exception> action, Uri baseAddress, string endpoint)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                setAcceptHeader(client);
                try
                {
                    var response = await client.GetAsync(endpoint);
                    response.EnsureSuccessStatusCode();
                    action(response.Content.ReadAsAsync<T>().Result, null);

                }
                catch (HttpRequestException e)
                {
                    action(default(T), e);
                }

            }
        }

        public static async void Post<T1, T2>(Action<T1, Exception> action, Uri baseAddress, string endpoint, T2 sendData)
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

        public static async void Put<T1, T2>(Action<T1, Exception> action, Uri baseAddress, string endpoint, T2 sendData)
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
        
        #region Private Methods

        private static void setAcceptHeader(HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #endregion
    }
}