using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.Interfaces
{
    public interface ICountriesService
    {


        public Task<CountriesBL<Countries>> SelectCountryByID(int CountryID);

        public Task<CountriesBL<Countries>> SelectCountryByName(string CountryName);

        public  Task<List<CountriesBL<Countries>>> SelectAllCountryes();

        public Task<CountriesBL<Countries>> SaveCountry(CountriesBL<Countries> country);

        public Task<CountriesBL<Countries>> DeleteCountry(int CountryId);

        public Task<CountriesBL<Countries>> UpdateCountry(CountriesBL<Countries> countries);
     


    }
}
