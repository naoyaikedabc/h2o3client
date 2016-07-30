using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainchild.H2O
{
    public class NodeV3
    {
        public string ExcludeFields
        {
            get;
            set;
        }

        public string H2o
        {
            get;
            set;
        }

        public string IpPort
        {
            get;
            set;
        }

        public bool Healthy
        {
            get;
            set;
        }

            public long LastPing
        {
            get;
            set;
        }

        public int PID
        {
            get;
            set;
        }

        public int NumberOfCPUs
        {
            get;
            set;
        }

        public int CPUsAllowed
        {
            get;
            set;
        }

        public int NumberOfThreads
        {
            get;
            set;
        }

        public double SysLoad
        {
            get;
            set;
        }

        public int MyCPUPercentage
        {
            get;
            set;
        }

        public int SysCPUPercentage
        {
            get;
            set;
        }

        public long MemoryValueSize
        {
            get;
            set;
        }

        public long TempSize
        {
            get;
            set;
        }

        public long FreeSize
        {
            get;
            set;
        }

        public long SwapSize
        {
            get;
            set;
        }

        public int NumberOfKeys
        {
            get;
            set;
        }

        public long FreeDisk
        {
            get;
            set;
        }

        public int RPCsActive
        {
            get;
            set;
        }

        public short[] FJThreadsCount
        {
            get;
            set;
        }

        public short[] FJTasksCount
        {
            get;
            set;
        }

        public long MaxMemorySize
        {
            get;
            set;
        }

        public long MaxDiskSize
        {
            get;
            set;
        }

        public int TCPsActive { get; set; }
        public int OpenFDs { get; set; }
        public double GFlops { get; set; }
        public double MemoryBandWidth { get; set; }
    }
}
