using System;
using System.Transactions;
using Newtonsoft.Json;
namespace MyBC
{
    class Program
    {


        static void Main(string[] args)
        {
            BCodes1 myBlockChain = new BCodes1();
            myBlockChain.CrTrans(new Transaction("X", "Y", 1051));
            //myBlockChain.procWaiting_Trans("Miner");
            myBlockChain.CrTrans(new Transaction("Y", "Z", 2));
            myBlockChain.CrTrans(new Transaction("Z", "X", 2));
            //myBlockChain.procWaiting_Trans("Miner");

            DateTime startTime = DateTime.Now;


            DateTime endTime = DateTime.Now;

            Console.WriteLine("Time:" + (endTime - startTime).ToString());
            Console.WriteLine("X Final:" + myBlockChain.Balance("X:").ToString());
            Console.WriteLine("Y Final:" + myBlockChain.Balance("Y").ToString());
            Console.WriteLine("Z Finale:" + myBlockChain.Balance("Z:").ToString());
            Console.WriteLine("Miner Final:" + myBlockChain.Balance(null).ToString());
            Console.WriteLine(JsonConvert.SerializeObject(myBlockChain, Formatting.Indented));

            /* Console.WriteLine(JsonConvert.SerializeObject(myBlockChain, Formatting.Indented));
             Console.WriteLine("İs it Verified ?:" + myBlockChain.Verification().ToString());
             Console.WriteLine("Changed Data Variation...");
             myBlockChain.Chain[1].Data = "{Gönderen:ABC, Alıcı:NMK, Miktar: 100}";
             Console.WriteLine("Data is Changed.İs it Verified ?:" + myBlockChain.Verification().ToString());
             Console.WriteLine("Hash is Updating...");
             myBlockChain.Chain[1].HashCode = myBlockChain.Chain[1].CalculateHash(); //1.Datanın Hash değerini yeniden hesaplattı(Değiştirdi)
               Console.WriteLine("Hash is Changed.İs it Verified ?:" + myBlockChain.Verification().ToString());
             Console.Write("------------------------------------------------------------------");
             myBlockChain.Chain[2].PrevHashCode = myBlockChain.Chain[1].HashCode;
             myBlockChain.Chain[2].HashCode = myBlockChain.Chain[2].CalculateHash();
             myBlockChain.Chain[3].PrevHashCode = myBlockChain.Chain[2].HashCode;
             myBlockChain.Chain[3].HashCode = myBlockChain.Chain[3].CalculateHash();
             Console.WriteLine("All Chains Hash is Uptaded. İs it valid ?:" + myBlockChain.Verification().ToString());
             ** %51 Attack */
            Console.ReadKey();

        }
    }
}