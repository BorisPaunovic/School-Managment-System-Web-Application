using EmployeeMVC.IServices;
using EmployeesMVC.DataModel.Employee;
using EmployeesMVC.DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeesMVC.Models;
using AutoMapper;
using School.Services.Interfaces;
using School.DataModels.Models;

namespace EmployeesMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IMapper _mapper;
        private readonly ICountriesService _countriesService;

        public EmployeesController(IEmployeeService _employeeService,IMapper mapper,ICountriesService countriesService)
        {
            employeeService = _employeeService;
            this._mapper = mapper;
            this._countriesService = countriesService;
        }
        public async Task<IActionResult> List()
        {
            var a = _countriesService.SelectAllCountryes();
            CommandResponse<IEnumerable<Employee>> response = await employeeService.GetEmployees();
            if (response.Status != "success" || response.Data == null)
            {
               
                return NotFound();
            }
            IEnumerable<EmployeeViewModel> employees = _mapper.Map<IEnumerable<EmployeeViewModel>>(response.Data);
            return View(employees);
       
        }
        
        public async Task<IActionResult> Index()
        {
            List<CountriesBL<Countries>> countriesBl = await _countriesService.SelectAllCountryes();



            



            CommandResponse<IEnumerable<Employee>> response =  await employeeService.GetEmployees();
            if(response.Status!="success" || response.Data==null)
            {
              
                return NotFound();
            }
           
            return View(response);
           
        }
    }
}

