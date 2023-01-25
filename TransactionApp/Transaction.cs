using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionApp
{
    public class Transaction : IEquatable<Transaction>
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }

        public bool Equals(Transaction other)
        {
            throw new NotImplementedException();
        }

        internal int ToString(string v)
        {
            throw new NotImplementedException();
        }
    }
}
