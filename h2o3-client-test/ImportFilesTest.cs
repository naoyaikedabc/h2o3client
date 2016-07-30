using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brainchild.H2O;

namespace h2o3_client_test
{
    [TestClass]
    public class ImportFilesTest
    {
        [TestMethod]
        public void ImportFilesMethod()
        {
            var client = new H2O3Client();
            var importfiles = client.ImportFiles("test.csv");
        }
    }
}
