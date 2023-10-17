using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyBC
{
    public class Blocks
    {
        public int index { get; set; }
        public DateTime TickTok { get; set; }
        public string PrevHashCode { get; set; }
        public string HashCode { get; set; }
        public IList<Transaction> Transactions { get; set; }
        public string Data { get; set; }
        public int Nonce { get; set; } = 2;
        public Blocks(DateTime time, string prevhashcode, IList<Transaction> transactions)
        {
            index = 0;
            TickTok = time;
            PrevHashCode = prevhashcode;
            Transactions = transactions;

        }
        public string CalculateHash()
        {
            SHA256 sha256 = SHA256.Create();
            byte[] ipbytes = Encoding.ASCII.GetBytes($"{TickTok} -- {PrevHashCode ?? ""}--{JsonConvert.SerializeObject(Transactions)}--{Nonce}"); // calculating hash code for ASCII
            byte[] opbytes = sha256.ComputeHash(ipbytes);
            return Convert.ToBase64String(opbytes);
        }
        public void Mine(int diffdegree) //PoW Block
        {
            var zeroquan = new string('0', diffdegree); // Nonce Value
            while (this.HashCode == null || this.HashCode.Substring(0, diffdegree) != zeroquan)
            {
                this.Nonce++;
                this.HashCode = this.CalculateHash();

            }
        }
    }
}



