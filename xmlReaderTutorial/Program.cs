using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Runtime.InteropServices;

namespace xmlReaderTutorial
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyRemoteXmlReaderClass myRemoteXmlReaderClass = new MyRemoteXmlReaderClass();
            List<IPerson> test =  myRemoteXmlReaderClass.GetAllData("https://www.theyworkforyou.com/pwdata/scrapedxml/regmem/regmem2021-12-13.xml");

            int testcounter = 1;
            foreach (IPerson person in test)
            {

                Console.WriteLine($"{person.Name} {person.id} {testcounter}");
                testcounter++;
                RegMem regMem = (RegMem)person;
                decimal amount =0;
                try
                {
                    amount = regMem.PaymentsReceived[0];
                }
                catch (ArgumentOutOfRangeException e)
                {
                     amount = 0;
                }
                Console.WriteLine($"donor {regMem.donor} amount {amount}");
                
            }

            Console.WriteLine("end");

            Console.ReadLine();

        }
    }

   
}

//var settings = new XmlReaderSettings();
//settings.DtdProcessing = DtdProcessing.Ignore;
//XmlReader xmlReader = XmlReader.Create("https://www.theyworkforyou.com/pwdata/scrapedxml/regmem/regmem2021-12-13.xml", settings);
//int counter = 0;
//while (xmlReader.Read())
//{
//    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "regmem")
//    {
//        // 647 opening regmem tags.
//        // from the opening time we can navigate to descedants

//        counter++;
//    }
//}

//Console.WriteLine(counter.ToString());
//while (xmlReader.Read())
//{
//    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "regmem")
//    {
//        if (xmlReader.IsStartElement())
//        {
//            Console.WriteLine("regmem - start");
//        }

//        //extract their attributes.

//        // grab copy off xml reader and see what we can do with it.
//        //XmlReader subtree = xmlReader.ReadSubtree();
//        //while (subtree.Read())
//        //{
//        //    // not all regmem members have categories.
//        //    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "category")
//        //    {
//        //        Console.WriteLine(subtree.Name);
//        //        // grab category attributes.

//        //        // grab other shit
//        //        XmlReader subtree2 = subtree.ReadSubtree();

//        //    }
//        //}

//    }

//}
//   Console.ReadKey();
//if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "regmem")
//  {
//      Console.WriteLine("regmem");
//      counter++;
//      //extract their attributes.

//      // grab copy off xml reader and see what we can do with it.
//      XmlReader subtree = xmlReader.ReadSubtree();
//      while (subtree.Read())
//      {
//          // not all regmem members have categories.
//          if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "category")
//          {
//              Console.WriteLine(subtree.Name);
//              // grab category attributes.

//          }
//      }


//  }
//// // xml structure: publicwhip -> regmem -> category -> item ->#text    
//XmlDocument xmldoc = new XmlDocument();
//xmldoc.Load("https://www.theyworkforyou.com/pwdata/scrapedxml/regmem/regmem2021-12-13.xml");
//foreach (XmlNode xmlnode in xmldoc.DocumentElement.ChildNodes)
//{
//    XmlNodeList categorynodes = xmlnode.ChildNodes;
//    string regmemid;
//    string membername;
//    string date;
//    if (xmlnode.Attributes["personid"] != null)
//    {
//        regmemid = xmlnode.Attributes["personid"].Value.ToString();
//        int testindex = regmemid.IndexOf("person/");
//        string temp;
//        temp = regmemid.Substring(testindex+7);
//        temp = temp.Trim();
//        regmemid = temp;
//    }
//    else
//    {
//        regmemid = "";                }

//    if (xmlnode.Attributes["membername"] != null)
//    {
//        membername = xmlnode.Attributes["membername"].Value.ToString();
//    }
//    else
//    {
//        membername = "";
//    }


//    if (xmlnode.Attributes["date"] != null)
//    {
//        date = xmlnode.Attributes["date"].Value.ToString();
//    }
//    else
//    {
//        date = "";
//    }

//    Console.WriteLine($"{regmemid} {membername} {date}");

//        // each record here is a regmem , each record has categoies. each category has a type and a few child nodes as well. 
//        // category nodes are returned per each regmem node
//        //console.writeline(categorynodes.count);
//        Console.WriteLine("node start");
//    for (int i = 0; i < categorynodes.Count ; i++)
//    {
//        // grab a child of each category node, get type and get name.
//        XmlNode categorynode = categorynodes[i];
//        string nodename;
//        if (categorynode.Attributes["name"] != null)
//            nodename = categorynode.Attributes["name"].Value.ToString();
//        else
//            nodename = "";

//        string nodetype;
//        if (categorynode.Attributes["type"] != null)
//            nodetype = categorynode.Attributes["type"].Value.ToString();
//        else
//            nodetype = "";

//        XmlNodeList recordnodes = categorynode.ChildNodes;

//        XmlNode recordnode = recordnodes[0];
//        XmlNodeList itemnodes = recordnode.ChildNodes;
//        foreach (XmlNode itemnode in itemnodes)
//        {
//            Console.WriteLine($"{ itemnode.Name}");
//            XmlNode text = itemnode.ChildNodes[0];
//            Console.WriteLine($"{text.InnerText}");

//        }
//        //console.writeline($"nodename:{categorynode.name} name: {nodename} type:{nodetype} ");
//        Console.ReadKey();
//    }
//    Console.WriteLine("node end");
//var settings = new XmlReaderSettings();
//settings.DtdProcessing = DtdProcessing.Ignore;
//XmlReader xmlReader = XmlReader.Create("https://www.theyworkforyou.com/pwdata/scrapedxml/regmem/regmem2021-12-13.xml", settings);
//string currentRegmem;
//int counter=1;

//while (xmlReader.Read())
//{
//    if ( xmlReader.Name == "regmem" && xmlReader.HasAttributes)
//    {

//        currentRegmem = xmlReader.GetAttribute("personid");
//        string date = xmlReader.GetAttribute("date");
//        int testindex = currentRegmem.IndexOf("person/");
//        string temp;
//        temp = currentRegmem.Substring(testindex + 7);
//        temp = temp.Trim();
//        currentRegmem = temp;


//      //  Console.WriteLine($"{xmlReader.Name} {currentRegmem} {date} {counter}");
//        counter++;

//    }
//    if (xmlReader.Name == "category" && xmlReader.HasAttributes)
//    {
//        string categoryName = xmlReader.GetAttribute("name");
//        string categoryType = xmlReader.GetAttribute("type");
//      //  Console.WriteLine($"{categoryName} {categoryType}");



//    }
//    if (xmlReader.Name == "item")
//    {
//        xmlReader.MoveToContent();
//        string itemValue = xmlReader.ReadInnerXml();
//      //  Console.WriteLine($"{itemValue}");
//        // get payment received.
//        string[] itemParts = itemValue.Split(' ');
//        string donor = "";
//        decimal amount = 0;
//        string pattern1 = @"(\d+\.\d+)";
//        string pattern2 = @"(\d+)";

//        Match match;
//        for (int i = 0; i < itemParts.Length; i++)
//        {
//            if (itemParts[i] == "received")
//            {
//                //amount = decimal.Parse(itemParts[i + 1]);
//                //decimal.TryParse(itemParts[i + 1], out amount);
//                match = Regex.Match(itemParts[i + 1], pattern2);
//                if (match.Success) decimal.TryParse(match.Value, out amount);
//            }
//            if (itemParts[i] == "from")
//            {
//                for (int j = i + 1; j < itemParts.Length; j++)
//                {
//                    if (itemParts[j] == ",")
//                    {
//                        break;
//                    }
//                    donor += itemParts[j] + " ";
//                }
//            }
//        }
//        // add to object

//    }


//}


//Console.ReadLine()


