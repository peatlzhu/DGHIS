using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGHIS.Response
{
    public class ApiResult
    {
   
        public bool Status { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
  
        public object Data { get; set; }

    }
}
