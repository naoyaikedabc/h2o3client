using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainchild.H2O
{
    public class CloudV3
    {
        public bool SkipTicks
        {
            get;
            set;
        }
        public string ExcludeFields
        {
            get;
            set;
        }
        public string Version
        {
            get;
            set;
        }
        public string BranchName
        {
            get;
            set;
        }
        public string BuildNumber
        {
            get;
            set;
        }
        public string BuildAge
        {
            get;
            set;
        }
        public bool BuildTooOld
        {
            get;
            set;
        }
        public int NodeIndex
        {
            get;
            set;
        }
        public string CloudName
        {
            get;
            set;
        }
        public int CloudSize
        {
            get;
            set;
        }
        public long CloudUptimeMillis
        {
            get;
            set;
        }
        public bool CloudHealthy
        {
            get;
            set;
        }
        public int BadNodes
        {
            get;
            set;
        }
        public bool Consensus
        {
            get;
            set;
        }
        public bool Locked
        {
            get;
            set;
        }
        public bool IsClient
        {
            get;
            set;
        }
        public NodeV3[] Nodes
        {
            get;
            set;
        }
    }
}
