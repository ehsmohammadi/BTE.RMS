using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using BTE.Core;
using BTE.Presentation.Web;
using Newtonsoft.Json.Linq;
using ArgumentException = System.ArgumentException;

namespace BTE.RMS.Api.Test
{
    public static class TestHttpClientHelper
    {
        #region Get From API

        public enum MessageFormat { Json, Xml };

        public static T Get<T>(Uri baseAddress, string endpoint, string authToken)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                setAcceptHeader(client, authToken);
                var response = client.GetAsync(endpoint).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<T>().Result;
                }
                handleException(response);
                return default(T);
            }
        }

        #endregion

        #region Post To API

        public static T1 Post<T1, T2>(Uri baseAddress, string endpoint, T2 sendData, string authToken)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                setAcceptHeader(client, authToken);
                var response = client.PostAsJsonAsync(endpoint, sendData).Result;
                if (response.IsSuccessStatusCode)
                {
                    return  response.Content.ReadAsAsync<T1>().Result;
                }
                handleException(response);
                return default(T1);
            }
        }


        public static T1 PostFormUrlEncoded<T1>(Uri baseAddress, string endpoint, IEnumerable<KeyValuePair<string, string>> sendData)
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
                        return  response.Content.ReadAsAsync<T1>().Result;
                    }
                    handleException(response);
                    return default(T1);


                }
            }
        }

       
        public static void Post<T>(Uri baseAddress, string endpoint, T sendData, string authToken)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                setAcceptHeader(client,authToken);
                var response = client.PostAsJsonAsync(endpoint, sendData).Result;
                if (!response.IsSuccessStatusCode)
                {
                    handleException(response);
                }
            }
        }


        #endregion

        #region Put To API

        public static T1 Put<T1, T2>(Uri baseAddress, string endpoint, T2 sendData, string authToken)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                setAcceptHeader(client, authToken);
                var response = client.PutAsJsonAsync(endpoint, sendData).Result;
                if (response.IsSuccessStatusCode)
                {
                    return  response.Content.ReadAsAsync<T1>().Result;
                }
                handleException(response);
                return default(T1);
            }
           
        }


        public static void Put<T>(Uri baseAddress, string endpoint, T sendData, string authToken)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                setAcceptHeader(client,authToken);
                var response = client.PutAsJsonAsync(endpoint, sendData).Result;
                if (!response.IsSuccessStatusCode)
                {
                    handleException(response);
                }
            }
        }


        #endregion

        public static void Delete<T>(Uri baseAddress, string endpoint, T id, string authToken)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                setAcceptHeader(client,authToken);
                var response = client.DeleteAsync(endpoint +"/" + id).Result;
                if (!response.IsSuccessStatusCode)
                {
                    handleException(response);
                }
            }
        }

        #region Private Methods
        private static void setAcceptHeader(HttpClient client, string token)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var authToken = token;
            if (string.IsNullOrWhiteSpace(authToken))
            {
                if (ClaimsPrincipal.Current == null) 
                    throw new ArgumentException("Token is empty and can't be get from ClaimsPrincipal","token");
                authToken = ClaimsPrincipal.Current.Identity.Name;
            }
            client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + authToken);
        }

        private static void handleException(HttpResponseMessage response)
        {
            var message = response.Content.ReadAsStringAsync().Result;
            var json = JObject.Parse(message);
            var dic = json.ToDictionary();
            var exception = ExceptionConverterService.ConvertBack(dic.ToDictionary(k=>k.Key,v=>v.Value.ToString()));
            throw exception;
        }

        #endregion
    }
}
