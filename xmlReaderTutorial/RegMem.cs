using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xmlReaderTutorial
{
    public class RegMem :IPerson, IRegmemFinancialRecords
    {
        //class props
        public string PartyAffiliation { get; set; }
        public string constituency { get; set; }

        //interface props
        public List<decimal> PaymentsReceived { get; set; }
        public string Name { get; set; }
        public string id { get; set; }
        public string donor { get; set; }

        public void AddPaymentReceived(decimal value)
        {
            PaymentsReceived.Add(value);
        }

        public List<decimal> getPaymentsReceived()
        {
            return PaymentsReceived;
        }


     
    }
}
