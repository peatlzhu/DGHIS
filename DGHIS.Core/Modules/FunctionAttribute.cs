using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGHIS.Core.Modules
{
    public class FunctionAttribute : Attribute
    {
        public string UniqueName
        {
            get;
            set;
        }

        public FunctionAttribute(string path)
        {
            UniqueName = path;
        }
    }
}
