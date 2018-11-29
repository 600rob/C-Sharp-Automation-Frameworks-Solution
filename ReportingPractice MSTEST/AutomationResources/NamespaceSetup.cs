
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingPracticeMSTEST


{
    [TestClass]
   public static class NamespaceSetup
    {
        [AssemblyInitialize]
        public static void ExecuteForCreatingReportsNameSapce(TestContext testContext)
    {
            Report.StartReporter();

    }
        
    }
}
