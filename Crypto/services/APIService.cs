using Crypto.model;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace Crypto.services
{
    internal class APIService
    {
        private readonly string API_URL = "https://api.coincap.io/v2/assets";
        private readonly RestClient _client;

        public APIService()
        {
            _client = new RestClient(API_URL);
        }

        public CryptoCoinData[] getCoinList()
        {
            try
            {
                RestRequest request = new RestRequest();
                RestResponse response = _client.Get(request);
                return JsonConvert.DeserializeObject<CryptoCoinList>
                                       (response.Content.ToString()).data;
            }
            catch (Exception)
            {
                throw new Exception("Error initialization: Check your the Internet connection");
            }
        }
    }
}
