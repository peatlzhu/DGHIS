using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGHIS.Core.Modules
{
    public class ControlMapping
    {
        public string RegionName
        {
            get;
            set;
        }

        public Type ControlType
        {
            get;
            set;
        }

        public Type TargetType
        {
            get;
            set;
        }
    }

}
