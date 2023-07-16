using EmployeeMVC.IServices;
using EmployeesMVC.DataModel;
using EmployeesMVC.DataModel.Employee;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EmployeeMVC.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _employeeRestServices;
        private readonly IConfiguration configuration;
        private readonly string url = "https://dummy.restapiexample.com/api/v1/";
        private readonly string url1 = null;
        public EmployeeService( IConfiguration _configuration) 
        {
            configuration = _configuration;
            _employeeRestServices = new HttpClient();
           // _employeeRestServices.BaseAddress= new Uri(url);
            //url1 = configuration.GetSection("ExternalServices").GetSection("EmployeeAPI").Value;
           _employeeRestServices.BaseAddress = new Uri( configuration.GetSection("ExternalServices").GetSection("EmployeeAPI").Value);

        }
        public async Task< CommandResponse<IEnumerable<Employee>>> GetEmployees()
        {
            var result = new CommandResponse<IEnumerable<Employee>>();

            try
            {
                var a = configuration.GetSection("MyConnections:Connection1").Value;
                var b = configuration.GetSection("MyConnections").GetSection("Connection1").Value;
                var responce = await _employeeRestServices.GetAsync("employees");
                if(responce.IsSuccessStatusCode)
                {
                    var content = await responce.Content.ReadAsStringAsync();
                  result =  JsonConvert.DeserializeObject<CommandResponse<IEnumerable<Employee>>>(content);
                }

             return result;
            }
            catch(Exception ex)
            {
                result.Status = "Error";
                result.Message = ex.Message;
                
                return result;
            }
            
        }
    }
}
