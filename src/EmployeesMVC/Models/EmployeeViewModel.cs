using System;

namespace EmployeesMVC.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public decimal Salary { get; set; }
        public int Age { get { return DateTime.Now.Year - Age; } }
        public int YearOfBirth { get; set; }
        public string ProfileImage { get; set; }

    }
}
