using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Brainchild.H2O
{
    public class H2O3Client
    {
        RestClient client;

        public H2O3Client(string endPoint)
        {
            this.client = new RestClient(endPoint);
        }

        public H2O3Client(): this("http://localhost:54321/")
        {

        }

    }
}
