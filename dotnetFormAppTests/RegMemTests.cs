using System;
using System.Collections.Generic;
using dotnetFormApp;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dotnetFormAppTests
{
    [TestClass]
    public class RegMemTests
    {

        [TestMethod]
        public void RegMemInitialisationTestUsingFactory_Pass()
        {
            var testObject = Factory.getRegmem();

            Assert.IsNotNull(testObject);
        }
        [TestMethod]
        public void RegMemInitialisationUsingNew_Pass()
        {
            RegMem testObject = new RegMem();

            Assert.IsNotNull(testObject);
        }

        [TestMethod]
        public void RegMemInitialisationWithIPersonAndNew()
        {
            IPerson testObject = new RegMem();

            Assert.IsNotNull(testObject);
        }

        [TestMethod]
        public void RegMemInitialisationTestFail()
        {
            RegMem testObject = null;
            // idk how to fail this any other way.
            Assert.IsNotNull(testObject);
        }

        [TestMethod]
        public void RegMemIsIPerson()
        {
            IPerson person = new RegMem();

            Assert.IsInstanceOfType(person, typeof(IPerson));
        }



    }
}
