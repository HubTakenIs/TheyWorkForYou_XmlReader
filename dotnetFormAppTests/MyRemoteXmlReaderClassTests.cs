using Microsoft.VisualStudio.TestTools.UnitTesting;
using dotnetFormApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetFormApp.Tests
{
    [TestClass]
    public class MyRemoteXmlReaderClassTests
    {
        
        [TestMethod]
        public void GetAllDataTest()
        {
            var testReader = new MyRemoteXmlReaderClass();
            List<IPerson> testList = testReader.GetAllData("https://www.theyworkforyou.com/pwdata/scrapedxml/regmem/regmem2021-12-13.xml");
            
            Assert.IsNotNull(testList);
        }
    }
}