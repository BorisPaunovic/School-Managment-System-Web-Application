using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesMVC.DataModel
{
    public class CommandResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
      
    }
    public class CommandResponse<T>:CommandResponse
    {
        public T Data { get; set; }

    }
}
