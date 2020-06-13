using BackEndAssignment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BackEndAssignment.Helpers
{
    public class APIHub
    {
        private readonly string _baseConfig = "https://api.stackexchange.com/";
        public string Post(string uri, string data)
        {
            string responseJson = string.Empty;
            using (var client = new HttpClient())
            {
                var baseUri = _baseConfig;
                client.BaseAddress = new System.Uri(baseUri);
                HttpContent content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PostAsync(baseUri + uri, content);
                var res = response.Result.Content.ReadAsStringAsync();
                return "";
            }
        }
        public string Get(string uri)
        {
            string url = _baseConfig + uri;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = _baseConfig;
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                webClient.Headers[HttpRequestHeader.CacheControl] = "private";
                webClient.Headers[HttpRequestHeader.ContentEncoding] = "charset=utf-8";
                //webClient.Headers[HttpRequestHeader.or] = "gzip";
                var json = webClient.DownloadString(uri);
                return json;
            }
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(_baseConfig);
            //    client.DefaultRequestHeaders.Add("Accept", "application/json");

            //    client.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");
            //    client.DefaultRequestHeaders.Add("Access-Control-Allow-Headers", "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");
            //    client.DefaultRequestHeaders.Add("Access-Control-Allow-Methods", "GET, POST");
            //    client.DefaultRequestHeaders.Add("Access-Control-Allow-Credentials", "false");
            //    client.DefaultRequestHeaders.Add("x-content-type-options", "nosniff");
            //    client.DefaultRequestHeaders.Add("x-route-name", "Questions/GetAll");
            //    client.DefaultRequestHeaders.Add("cache-control", "private");
            //    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    client.DefaultRequestHeaders.Add("set-cookie", "prov=36f67a17-74dd-4c08-b0e2-98ad525693cd; expires=Fri, 01 Jan 2055 00:00:00 GMT; domain=.stackexchange.com; path=/; secure; samesite=none; httponly");
            //    var baseUri = _baseConfig;
            //    client.BaseAddress = new System.Uri(baseUri);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    var response = client.GetAsync(baseUri + uri);
            //    var result = response.Result.Content.ReadAsStringAsync();
            //    return null;
            //}
        }
    }
}
