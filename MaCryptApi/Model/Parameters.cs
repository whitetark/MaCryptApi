using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaCryptApi.Model
{
    public class Parameters
    {
        public class OneCryptoParameter
        {
            public string Symbol { get; set; }
            public string Pref { get; set; }
        }

        public class CryptoListParameter
        {
            public string Pref { get; set; }
            public string Order { get; set; }
        }
        
        public class WalletParameter
        {
            public string Adress { get; set; }
        }
    }
}
