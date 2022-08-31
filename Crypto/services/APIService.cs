using Crypto.model;
using Newtonsoft.Json;
using RestSharp;
using System;
using static Crypto.model.MarketsData;

namespace Crypto.services
{
    internal class APIService
    {
        private readonly string API_URL = "https://api.coincap.io/v2/assets";
        private readonly RestClient _client;

        private readonly string API_URL_MARKETS = "/markets";

        public MarketData[] getMarketsList(string name)
        {
            try
            {
                RestRequest request = new RestRequest("/" + name + API_URL_MARKETS);
                RestResponse response = _client.Get(request);
                return JsonConvert.DeserializeObject<MarketsList>
                                       (response.Content.ToString()).data;
            }
            catch (Exception)
            {
                throw new Exception("Error initialization: Check your the Internet connection");
            }
        }

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
