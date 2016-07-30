using Brainchild.H2O;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace h2o3_example
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new H2O3Client();
            var about = client.About();
            var cloud = client.Cloud();
            var fileImports = client.ImportFiles("test.csv");

            foreach(var item in about)
            {
                Console.WriteLine("{0}:{1}", item.Key, item.Value);
            }

            Console.WriteLine(cloud.CloudName);
            Console.WriteLine(cloud.Version);

            foreach(var loaded in fileImports.Files)
            {
                Console.WriteLine("{0}", loaded);
            }

            foreach (var loaded in fileImports.DestinationFrames)
            {
                Console.WriteLine("{0}", loaded);
            }
        }
    }
}
