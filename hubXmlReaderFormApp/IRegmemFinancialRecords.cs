﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubXmlReaderFormApp
{
    public interface IRegmemFinancialRecords
    {
        string donor { get; set; }
        List<decimal> PaymentsReceived { get; set; }

        


    }
}
