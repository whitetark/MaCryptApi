using MaCryptApi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MaCryptApi.Clients
{
    public class BlockchainClient
    {
        private HttpClient _client;
        private static string _address;
        public BlockchainClient()
        {
            _address = Config.Blockchain.address;

            _client = new HttpClient();
            _client.BaseAddress = new Uri(_address);
        }
        public async Task<WalletInfo> GetWalletInfo(string bitcoinAddress)
        {
            var response = await _client.GetAsync($"/rawaddr/{bitcoinAddress}?limit=5");
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<WalletInfo>(content);

            return result;

        }
    }
}
