using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public string Note { get; set; }

        public Transaction() { }


        public Transaction(decimal xamount, DateTime xDate, String xNote)
        {
            this.Amount = xamount;
            this.Date = xDate;
            this.Note = xNote;
        }


    }
}
