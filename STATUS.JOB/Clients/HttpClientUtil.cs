using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace STATUS.JOB.Clients
{
    public class HttpClientUtil
    {
        public HttpClient _client {get; private set; }

        public HttpClientUtil(string baseAddress)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseAddress);
        }
        
        public async Task<string> GetAsync(string resource = "")
        {
            var uri = this.CreateUri(resource);

            return await _client.GetAsync(uri)
                .Result
                .Content
                .ReadAsStringAsync();
        }

        public async Task<string> PostAsync(string content, string resource = "")
        {
            var uri = this.CreateUri(resource);
            var httpContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            return await _client.PostAsync(uri, httpContent)
                .Result
                .Content
                .ReadAsStringAsync();
        }

        public Uri CreateUri(string resource = "")
        {
            return string.IsNullOrEmpty(resource) ?
                new Uri($"{_client.BaseAddress}/{resource}") :
                _client.BaseAddress;
        }
    }
}
