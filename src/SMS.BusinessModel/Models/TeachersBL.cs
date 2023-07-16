﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModels.Models
{

    public class TeachersBL
    {
        /*
       public int TeachersId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Adress { get; set; }
        public bool Deleted { get; set; }
        */
        public string Message { get; set; }
        public string Status { get; set; }
    }
    public class TeachersBL<T> : TeachersBL
    {
        public T Data { get; set; }
    }
}
