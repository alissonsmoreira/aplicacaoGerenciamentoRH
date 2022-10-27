using System;
using System.Configuration;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web;

using lurin.meurhonline.infrastructure.invoke.interfaces;

namespace lurin.meurhonline.infrastructure.invoke
{
    public class ApiInvoke : IApiInvoke
    {       
        private static string _baseUrl = ConfigurationManager.AppSettings["UrlBaseApi"];

        private static string _tokenAPI;
        private static string _userName;
        private static string _password;

        public ApiInvoke()
        {
            _userName = "MeuRHOnline";
            _password = "Web@#2021";        
            _tokenAPI = "Autenticacao/Token";
        }

        public T PostReturn<T>(int colaboradorId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);

            HttpResponseMessage response =
              client.PostAsync(_tokenAPI,
                new StringContent(string.Format("grant_type=password&username={0}_{2}&password={1}",
                  HttpUtility.UrlEncode(_userName),
                  HttpUtility.UrlEncode(_password),
                  colaboradorId),
                  Encoding.UTF8,
                  "application/x-www-form-urlencoded")).Result;

            string resultJSON = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<T>(resultJSON);

            return result;
        }
    }
}