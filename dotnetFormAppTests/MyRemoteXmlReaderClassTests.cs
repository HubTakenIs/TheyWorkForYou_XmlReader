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
        public async Task GetAllDataTestAsync()
        {
            var testReader = new MyRemoteXmlReaderClass();
            List<IPerson> testList = await Task.Run(() => testReader.GetAllData("https://www.theyworkforyou.com/pwdata/scrapedxml/regmem/regmem2021-12-13.xml"));

            Assert.IsTrue(testList.Count == 647);


        }

    }
}