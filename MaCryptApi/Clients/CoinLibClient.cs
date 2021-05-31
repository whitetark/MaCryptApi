using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MaCryptApi.Model;

namespace MaCryptApi.Clients
{
    public class CoinLibClient
    {
        private HttpClient _client;
        private static string _address;
        private static string _apiKey;
        public CoinLibClient()
        {
            _address = Config.Coinlib.address;
            _apiKey = Config.Coinlib.apiKey;

            _client = new HttpClient();
            _client.BaseAddress = new Uri(_address);
        }
        
        public async Task<CryptoBySymbol> GetCryptoBySymbol(string symbol, string pref)
        {
            var response = await _client.GetAsync($"/api/v1/coin?key={_apiKey}&pref={pref}&symbol={symbol}");
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;

            CryptoBySymbol result = JsonConvert.DeserializeObject<CryptoBySymbol>(content);


            return result;
        }

        public async Task<CryptoList> GetCryptoList(string pref, string order)
        {
            var response = await _client.GetAsync($"/api/v1/coinlist?key={_apiKey}&pref={pref}&page=1&order={order}");
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;

            CryptoList result = JsonConvert.DeserializeObject<CryptoList>(content);


            return result;
        }
    }
}
