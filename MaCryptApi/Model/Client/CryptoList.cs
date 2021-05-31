using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaCryptApi.Model
{
    public class Coin
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public int rank { get; set; }
        public double price { get; set; }
        public double market_cap { get; set; }
        public double volume_24h { get; set; }
        public string delta_24h { get; set; }
    }

    public class CryptoList
    {
        public List<Coin> coins { get; set; }
    }
}
