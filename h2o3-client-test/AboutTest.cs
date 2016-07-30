using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brainchild.H2O;

namespace h2o3_client_test
{
    [TestClass]
    public class AboutTest
    {
        [TestMethod]
        public void AboutMethod()
        {
            var client = new H2O3Client();
            client.About();
        }
    }
}
