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

        public CloudV3 Cloud(bool skipTicks = false, string[] excludeFields = null)
        {
            var result = new CloudV3();

            var request = new RestRequest("3/Cloud", Method.GET);
            request.AddParameter("skip_ticks", skipTicks);
            ParseExcludeFields(excludeFields, request);
            var response = client.Execute(request);
            var responseObject = DynamicJson.Parse(response.Content);

            bool skip_ticks = responseObject.skip_ticks;
            string _exclude_fields = responseObject._exclude_fields;
            string version = responseObject.version;
            string branch_name = responseObject.branch_name;
            string build_number = responseObject.build_number;
            string build_age = responseObject.build_age;
            bool build_too_old = responseObject.build_too_old;
            int node_idx = (int)responseObject.node_idx;
            string cloud_name = responseObject.cloud_name;
            int cloud_size = (int)responseObject.cloud_size;
            long cloud_uptime_millis = (long)responseObject.cloud_uptime_millis;
            bool cloud_healthy = responseObject.cloud_healthy;
            int bad_nodes = (int)responseObject.bad_nodes;
            bool consensus = responseObject.consensus;
            bool locked = responseObject.locked;
            bool is_client = responseObject.is_client;
            var nodes = responseObject.nodes;

            var nodeInfoList = new List<NodeV3>();
            foreach(var node in nodes)
            {
                var nodeInfo = new NodeV3();
                nodeInfo.ExcludeFields = node._exclude_fields;
                nodeInfo.H2o = node.h2o;
                nodeInfo.IpPort = node.ip_port;
                nodeInfo.Healthy = node.healthy;
                nodeInfo.PID = (int)node.pid;
                nodeInfo.NumberOfCPUs = (int)node.num_cpus;
                nodeInfo.CPUsAllowed = (int)node.cpus_allowed;
                nodeInfo.NumberOfThreads = (int)node.nthreads;
                nodeInfo.SysLoad = (double)node.sys_load;
                nodeInfo.MyCPUPercentage = (int)node.my_cpu_pct;
                nodeInfo.SysCPUPercentage = (int)node.sys_cpu_pct;
                nodeInfo.MemoryValueSize = (long)node.mem_value_size;
                nodeInfo.TempSize = (long)node.pojo_mem;
                nodeInfo.FreeSize = (long)node.free_mem;
                nodeInfo.SwapSize = (long)node.swap_mem;
                nodeInfo.NumberOfKeys = (int)node.num_keys;
                nodeInfo.FreeDisk = (long)node.free_disk;
                nodeInfo.RPCsActive = (int)node.rpcs_active;
                nodeInfo.TCPsActive = (int)node.tcps_active;
                nodeInfo.OpenFDs = (int)node.open_fds;
                nodeInfo.GFlops = (double)node.gflops;
                nodeInfo.MemoryBandWidth = (double)node.mem_bw;
                nodeInfo.MaxMemorySize = (long)node.max_mem;
                nodeInfo.MaxDiskSize = (long)node.max_disk;

                var fjTasksCount = new List<short>();
                var fjqueue = node.fjqueue;
                foreach(var x in fjqueue)
                {
                    fjTasksCount.Add((short)x);
                }
                nodeInfo.FJTasksCount = fjTasksCount.ToArray();

                var fjThreadsCount = new List<short>();
                var fjthrds = node.fjthrds;
                foreach(var x in fjthrds)
                {
                    fjThreadsCount.Add((short)x);
                }
                nodeInfo.FJThreadsCount = fjThreadsCount.ToArray();

                nodeInfoList.Add(nodeInfo);
            }

            result.SkipTicks = skip_ticks;
            result.ExcludeFields = _exclude_fields;
            result.Version = version;
            result.BranchName = branch_name;
            result.BuildNumber = build_number;
            result.BuildAge = build_age;
            result.BuildTooOld = build_too_old;
            result.NodeIndex = node_idx;
            result.CloudName = cloud_name;
            result.CloudSize = cloud_size;
            result.CloudUptimeMillis = cloud_uptime_millis;
            result.CloudHealthy = cloud_healthy;
            result.BadNodes = bad_nodes;
            result.Consensus = consensus;
            result.Locked = locked;
            result.IsClient = is_client;
            result.Nodes = nodeInfoList.ToArray();

            return (result);
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
