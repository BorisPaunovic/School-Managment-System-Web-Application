using EmployeesMVC.DataModel;
using EmployeesMVC.DataModel.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMVC.IServices
{
    public interface IEmployeeService
    {

        public Task<CommandResponse<IEnumerable<Employee>>> GetEmployees();

    }
}
