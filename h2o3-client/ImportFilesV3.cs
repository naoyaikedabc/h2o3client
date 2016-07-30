using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainchild.H2O
{
    public class ImportFilesV3
    {
        public string Path
        {
            get;
            set;
        }

        public string ExcludeFields
        {
            get;
            set;
        }

        public string[] Files
        {
            get;
            set;
        }

        public string[] Fails
        {
            get;
            set;
        }

        public string[] Dels
        {
            get;
            set;
        }

        public string[] DestinationFrames
        {
            get;
            set;
        }
    }
}
