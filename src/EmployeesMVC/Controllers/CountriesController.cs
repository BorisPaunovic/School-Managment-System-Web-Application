using AutoMapper;
using EmployeeMVC.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;
using School.DataModels.Models;
using School.Services.Interfaces;
using SMS.IBusinessLogic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagmentSystem.Controllers
{

    public class CountriesController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IMapper _mapper;
        private readonly ICountriesService _countriesService;
        private readonly ICountriesBusinessLogic _countriesBusinessLogic;

        [BindProperty(SupportsGet = true)]
        public string IsDeleted { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        public CountriesBL<Countries> CountriesBL { get; set; }


        [BindProperty(SupportsGet = true)]

        public string filter { get; set; }
        public CountriesController(IEmployeeService _employeeService, IMapper mapper, ICountriesService countriesService, ICountriesBusinessLogic countriesBusinessLogic)
        {
            employeeService = _employeeService;
            this._mapper = mapper;
            this._countriesService = countriesService;
            this._countriesBusinessLogic = countriesBusinessLogic;
        }


        public async Task<IActionResult> Index()
        {
            List<CountriesBL<Countries>> countries = await _countriesBusinessLogic.SelectAllCountryes();
            List<CountriesBL<Countries>> filterdCountries = new List<CountriesBL<Countries>>();
            if (filter != null)
            {

                foreach (var element in countries)
                {
                    if (element.Data.CountryName.ToLower().Contains(filter.ToLower()))
                    {
                        filterdCountries.Add(element);
                    }
                }
                countries.Clear();
                countries = filterdCountries;
            }

            ViewBag.IsDeleted = IsDeleted;
            return View(countries);
        }

        public async Task<IActionResult> Details()
        {
            CountriesBL = await _countriesBusinessLogic.SelectCountryByID(Id);

            return View(CountriesBL);
        }


        public async Task<IActionResult> Delete()
        {
            CountriesBL<Countries> countriesBL = await _countriesBusinessLogic.SelectCountryByID(Id);
            return View(countriesBL);
        }

        public async Task<IActionResult> ConfirmDelete()
        {
            await _countriesService.DeleteCountry(Id);

            return RedirectToAction("Index");

        }
        [HttpGet]
        public  IActionResult Save()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveCountry()
        {

            var countriesBL = await _countriesBusinessLogic.SaveCountry(CountriesBL);



            return RedirectToAction("Index");
        }




        [HttpGet("Edit")]
        public async Task<IActionResult> Edit()
        {

            CountriesBL = await _countriesBusinessLogic.SelectCountryByID(Id);
            return View(CountriesBL);
            
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> EditCountry()
        {

            CountriesBL = await _countriesBusinessLogic.UpdateCountry(CountriesBL);

          return  RedirectToAction("Index");
        }

    }
}
