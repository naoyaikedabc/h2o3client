using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brainchild.H2O;

namespace h2o3_client_test
{
    [TestClass]
    public class CloudTest
    {
        [TestMethod]
        public void CloudMethod()
        {
            var client = new H2O3Client();
            client.Cloud(false, new string[] {"version"});
        }
    }
}
