using AutoMapper;
using School.DataModels.Models;
using School.Services.Interfaces;
using SMS.IBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SMS.BusinessLogic
{
    public class CountriesBusinessLogic:ICountriesBusinessLogic
    {
      
      
        private readonly ICountriesService _countriesService;
        private readonly IMapper mapper;

        public CountriesBusinessLogic(ICountriesService countriesService,IMapper mapper)
        {
            
         
            this._countriesService = countriesService;
            this.mapper = mapper;
        }

        public async Task<CountriesBL<Countries>> SelectCountryByID(int ID)
        {
            CountriesBL<Countries> countries = new CountriesBL<Countries>();
            countries = await _countriesService.SelectCountryByID(ID);

            return countries;
        }
        public async Task<CountriesBL<Countries>> SelectCountryByName(string CountryName)
        {
            CountriesBL<Countries> countries = new CountriesBL<Countries>();
            countries = await _countriesService.SelectCountryByName(CountryName);

            return countries;
        }
        public async Task<List<CountriesBL<Countries>>> SelectAllCountryes()
        {
            List<CountriesBL<Countries>> countries = new List<CountriesBL<Countries>>();
            countries = await _countriesService.SelectAllCountryes();

            return countries;
        }
       
        public async Task<CountriesBL<Countries>> DeleteCountry(int CountryId)
        {
           CountriesBL<Countries> countries = new CountriesBL<Countries>();
            countries = await _countriesService.DeleteCountry(CountryId);

            return countries;


        }
        public  async Task<CountriesBL<Countries>> SaveCountry(CountriesBL<Countries> country)
        {
            var savedCountry = await _countriesService.SaveCountry(country);
            return savedCountry;
        }

        public  async Task<CountriesBL<Countries>> UpdateCountry(CountriesBL<Countries> countries)
        {
            var savedCountry = await _countriesService.UpdateCountry(countries);
            return savedCountry;
           
        }




        
    }
}
