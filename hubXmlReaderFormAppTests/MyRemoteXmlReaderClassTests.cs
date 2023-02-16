using Microsoft.VisualStudio.TestTools.UnitTesting;
using hubXmlReaderFormApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubXmlReaderFormApp.Tests
{
    [TestClass()]
    public class MyRemoteXmlReaderClassTests
    {
        [TestMethod()]
        public void GetAllDataTest()
        {
            var test = Factory.GetRemoteDocumentReader();
            var testlist = test.GetAllData("https://www.theyworkforyou.com/pwdata/scrapedxml/regmem/regmem2021-12-13.xml");
            Assert.IsNotNull(testlist);
        }
    }
}