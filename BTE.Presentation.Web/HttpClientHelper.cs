using System;
//using System.Collections.Generic;
//using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BTE.Presentation.Web
{
    public static class HttpClientHelper
    {
        #region Get From API

        public enum MessageFormat { Json, Xml };

        //public static void Get<T>(Uri uri, Action<T, Exception> action, MessageFormat format = MessageFormat.Json, Dictionary<string, string> headers = null)
        //{
        //    var request = (HttpWebRequest)WebRequest.Create(uri);
        //    request.Method = "GET";
        //    //setAcceptHeader(format, request);
        //    if (headers != null)
        //        foreach (var header in headers)
        //            request.Headers[header.Key] = header.Value;
        //    request.BeginGetResponse(iar2 =>
        //    {
        //        WebResponse response = null;
        //        try
        //        {
        //            response = request.EndGetResponse(iar2);
        //        }
        //        catch (WebException exp)
        //        {
        //            //action(default(T), convertException(exp));
        //            return;
        //        }
        //        catch (Exception exp)
        //        {
        //            action(default(T), exp);
        //            return;
        //        }
        //       // action(deserializeObject<T>(format, response.GetResponseStream()), null);
        //    }, null);
        //}


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
