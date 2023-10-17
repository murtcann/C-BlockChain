using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Security;
using System.Text;
using System.Threading.Tasks;



namespace MyBC
{
    public class BCodes1
    {
        public IList<Transaction> Waitingtrans = new List<Transaction>();
        public IList<Blocks> Chain { get; set; }
        public int diffdegree { get; set; } = 2; // difficult degree for solving nonce. It is changeable,
                                                 // the more you increase the value, the longer the processing time becomes.
        public int Reward { get; set; } = 15; // changeable.
        public BCodes1()
        {
            InıtChain();
            AddGenesis();
        }
        public void InıtChain()
        {
            Chain = new List<Blocks>();
            AddGenesis();
        }
        public Blocks CrGenesis() // creating genesis block
        {
            Blocks block = new Blocks(DateTime.Now, null,new List <Transaction>(Waitingtrans));
            block.Mine(diffdegree);
            Waitingtrans = new List<Transaction>();
            return block;
        }
        public void AddGenesis() // Add the miners to the created genesis block.
        {
            Chain.Add(CrGenesis());
        }
        public Blocks Latest_Block()
        {
            return Chain[Chain.Count - 1]; // calling latest block
        }
        public void AddBlock(Blocks block) // adding block
        {
            Blocks latestblock = Latest_Block(); //Retrieve the latest block and assign it to a variable.
            block.index = latestblock.index + 1;
            block.PrevHashCode = latestblock.HashCode;
            block.HashCode = block.CalculateHash();
            block.Mine(diffdegree);
            Chain.Add(block);
        }
        public void CrTrans(Transaction transaction)
        {
            Waitingtrans.Add(transaction);
        }
        public void procWaiting_Trans(string minerAdress)
        {
            CrTrans(new Transaction(null, minerAdress, Reward));
            Blocks block = new Blocks(DateTime.Now, Latest_Block().HashCode, Waitingtrans);
            AddBlock(block);
            Waitingtrans = new List<Transaction>();
        }
        public bool Verification()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Blocks existblock = Chain[i];
                Blocks prev_block = Chain[i - 1];
                if (existblock.HashCode != existblock.CalculateHash())
                {
                    return false;
                }
                if (existblock.PrevHashCode != prev_block.HashCode)
                {
                    return false;
                }

            }
            return true;
        }
        public int Balance(string address)
        {
            int balance = 0;
            foreach (var block in Chain)
            {
                foreach (var transaction in block.Transactions)
                {
                    if (transaction.FromAdress == address)
                    {
                        balance -= transaction.Amount;
                    }
                    if (transaction.ToAdress == address)
                    {
                        balance += transaction.Amount;
                    }
                }
            }
            return balance;
        }



    }
}
