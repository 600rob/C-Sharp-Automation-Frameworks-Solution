using NUnit.Framework;
using ReportingPractice.AutomationResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingPractice


{
    
    [SetUpFixture]
    //[TestClass]
    

    public class NamespaceSetup 
    {
       /* 
        * WE CAN IMPLEMENT FROM THE iNTERFACE IF WE WANTED
        * [Test]
        [OneTimeSetUp]
        public void CallStartReport()
        {
            Report.StartReporter();


        }*/

        [Test]
        [OneTimeSetUp]
        //[AssemblyInitialize]
         public static void ExecuteForCreatingReportsNameSapce()
        {
        Report.StartReporter();

    }
        
    }
}
