using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Serialization;

namespace BankAccount
{
    public class bankAccount
    {
        //Variables
        public string Number { get; set; }
        public string Owner { get; }
        public double balance { get; set; }
        private static int accountNumber = 209;
        private List<Transaction> alltransactions = new List<Transaction>();

        //Constructor
        public bankAccount(string xname, double xinitialDeposit, DateTime xdate)
        {
            this.Owner = xname;
            this.Number = accountNumber.ToString();
            accountNumber++;
            //Balance 
            makeDeposit(xinitialDeposit, xdate, "Deposito inicial");
        }


        //Methods  

        public void makeDeposit(double xamount, DateTime xdate, string xnote)
        {
            if (xamount > 2500 || xamount < 200)
            {
                throw new ArgumentOutOfRangeException(nameof(xamount), "El deposito debe ser mayor a 200 y menor a 2500");
            }
            else
            {
                this.balance = this.balance + xamount;
                var deposit = new Transaction((decimal)xamount, xdate, xnote);
                alltransactions.Add(deposit);
            }
        }

        public void Withdrawmoney(double xamount, DateTime xdate, string xnote)
        {
            if (xamount > 2500 || xamount < 200)
            {
                throw new ArgumentOutOfRangeException(nameof(xamount), "El retiro debe ser mayor a 200 y menor a 2500");
            }
            if ((balance - xamount) < 0)
            {
                throw new InvalidOperationException("Fondos insuficientes, por favor intentalo de nuevo");

            }
            else
            {
                this.balance = this.balance - xamount;

                var depositcorrect = new Transaction((decimal)xamount, xdate, xnote);
                alltransactions.Add(depositcorrect);
            }
        }

        public string getAccountHistory()
        {
            var xreport = new StringBuilder();
            xreport.AppendLine("Fecha \t\t\t Cantidad \t\t Nota");

            foreach (var report in alltransactions)
            {
                xreport.AppendLine($"{report.Date} \t\t {report.Amount} \t\t {report.Note}");

            }
            return xreport.ToString();
        }



    }
}
