﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModels.Models
{
    public class UsersBL
    {
        /*
        public int UsersID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public bool Administrator { get; set; }
        public bool Deleted { get; set; }
        */

        public string Message { get; set; }
        public string Status { get; set; }
    }
    public class UsersBL<T> : UsersBL
    {
        public T Data { get; set; }
    }

}
