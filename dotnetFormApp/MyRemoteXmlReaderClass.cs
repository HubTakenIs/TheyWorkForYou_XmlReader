using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using static System.Net.WebRequestMethods;

namespace dotnetFormApp
{
    public class MyRemoteXmlReaderClass : IRemoteDocumentReader<IPerson>
    {
        List<IPerson> _persons = new List<IPerson>();
        List<decimal> _paymentsReceived = new List<decimal>();
        string _donor = "";

       
        public List<IPerson> GetAllData(string document)
        {
            var settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Ignore;
            XmlReader xmlReader = XmlReader.Create(document, settings);
            int counter = 0;

            while (xmlReader.Read())
            {
                if (xmlReader.Name == "regmem" && xmlReader.HasAttributes)
                {
                    IPerson regMem = Factory.getRegmem();
                    string RegmemID = xmlReader.GetAttribute("personid");
                    string date = xmlReader.GetAttribute("date");
                    string regMemName = xmlReader.GetAttribute("membername");
                    int testindex = RegmemID.IndexOf("person/");
                    string temp;
                    temp = RegmemID.Substring(testindex + 7);
                    temp = temp.Trim();
                    RegmemID = temp;
                    regMem.id = RegmemID;
                    regMem.Name = regMemName;
                    _persons.Add(regMem);

                    _donor = "";
                    _paymentsReceived = new List<decimal>();

                    counter++;

                }
                if (xmlReader.Name == "category" && xmlReader.HasAttributes)
                {
                    string categoryName = xmlReader.GetAttribute("name");
                    string categoryType = xmlReader.GetAttribute("type");
                    
                    


                }
                if (xmlReader.Name == "item")
                {
                    xmlReader.MoveToContent();
                    string itemValue = xmlReader.ReadInnerXml();
                    //  Console.WriteLine($"{itemValue}");
                    // get payment received.
                    string[] itemParts = itemValue.Split(' ');
                    string donor = "";
                    decimal amount = 0;
                    string pattern1 = @"(\d+\.\d+)";
                    string pattern2 = @"(\d+)";

                    Match match;
                    for (int i = 0; i < itemParts.Length; i++)
                    {
                        if (itemParts[i] == "received")
                        {
                            //amount = decimal.Parse(itemParts[i + 1]);
                            //decimal.TryParse(itemParts[i + 1], out amount);
                            match = Regex.Match(itemParts[i + 1], pattern2);
                            if (match.Success) decimal.TryParse(match.Value, out amount);
                            _paymentsReceived.Add(amount);
                        }
                        if (itemParts[i] == "from")
                        {
                            for (int j = i + 1; j < itemParts.Length; j++)
                            {
                                if (itemParts[j] == ",")
                                {
                                    break;
                                }
                                donor += itemParts[j] + " ";
                            }
                            _donor = donor;

                        }
                    }

                    //update donor + paymentReceived.
                    RegMem regMem = (RegMem)_persons[counter-1];
                    regMem.PaymentsReceived = _paymentsReceived;
                    regMem.donor = _donor;
                    //string id = regMem.id;
                    //string regMemURL = "https://www.theyworkforyou.com/mp/" + id;
                    //string[] returnedItems = WebScraper.getPartyAndConstituency(regMemURL);

                    //regMem.PartyAffiliation = returnedItems[0];
                    //regMem.constituency = returnedItems[1];


                }


            }


            Console.ReadLine();


            return _persons;
        }

        public Task<List<IPerson>> GetAllDataAsync(string document)
        {
            return Task.Run(() => GetAllData(document));
        }
    }
}
