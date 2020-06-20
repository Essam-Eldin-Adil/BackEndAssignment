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
        public async Task<string> GetRequest(string uri)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(_baseConfig);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(uri);
                response.Wait();
                var result = await response.Result.Content.ReadAsStringAsync();
                return result;
            }
        }
    }
}
