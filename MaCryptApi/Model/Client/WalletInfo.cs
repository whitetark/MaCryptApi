using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaCryptApi.Model
{
    public class Tx
    {
        public string hash { get; set; }
        public double fee { get; set; }
        public string time { get; set; }
        public double result { get; set; }
        public double balance { get; set; }
    }

    public class WalletInfo
    {
        public string address { get; set; }
        public int n_tx { get; set; }
        public double total_received { get; set; }
        public double total_sent { get; set; }
        public double final_balance { get; set; }
        public List<Tx> txs { get; set; }
    }
 
}
