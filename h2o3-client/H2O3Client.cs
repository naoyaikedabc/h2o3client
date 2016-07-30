using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Codeplex.Data;

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

        public Dictionary<string, string> About(string[] excludeFields = null)
        {
            var result = new Dictionary<string, string>();
            var request = new RestRequest("3/About", Method.GET);
            ParseExcludeFields(excludeFields, request);
            var response = client.Execute(request);
            var responseObject = DynamicJson.Parse(response.Content);
            var entries = responseObject.entries;

            foreach(var item in entries)
            {
                result.Add(item.name, item.value);
            }

            return result;
        }

        public void Cloud(bool skipTicks = false, string[] excludeFields = null)
        {
            var result = new Dictionary<string, string>();
            var request = new RestRequest("3/Cloud", Method.GET);
            request.AddParameter("skip_ticks", skipTicks);
            ParseExcludeFields(excludeFields, request);
            var response = client.Execute(request);
            var responseObject = DynamicJson.Parse(response.Content);
            bool skip_ticks = responseObject.skip_ticks;
            string _exclude_fields = responseObject._exclude_fields;
            string version = responseObject.version;
            string branch_name = responseObject.branch_name;
        }

        private static void ParseExcludeFields(string[] excludeFields, RestRequest request)
        {
            if (excludeFields != null)
            {
                var sb = new StringBuilder();

                if (excludeFields.Length > 2)
                {
                    for (int i = 0; i < excludeFields.Length - 1; i++)
                    {
                        sb.AppendFormat("{0},", excludeFields[i]);
                    }
                    sb.Append(excludeFields[excludeFields.Length - 1]);
                }
                else
                {
                    if (excludeFields.Length == 1)
                    {
                        sb.Append(excludeFields[0]);
                    }
                }

                request.AddParameter("_exclude_fields", sb.ToString());
            }
        }
    }
}
