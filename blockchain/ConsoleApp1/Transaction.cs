using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBC
{
    public class Transaction
    {
        public string FromAdress { get; set; }
        public string ToAdress { get; set; }
        public int Amount { get; set; }
        public Transaction(string fromAdress, string toAdress, int amount)
        {
            FromAdress = fromAdress;
            ToAdress = toAdress;
            Amount = amount;
        }
    }
}
