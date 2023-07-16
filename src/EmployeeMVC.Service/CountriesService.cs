using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using School.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace School.Services
{
    public  class CountriesService:ICountriesService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        HttpClient httpClient = new HttpClient();
        public CountriesService(IConfiguration configuration)
        {
            this._configuration = configuration;
            httpClient.BaseAddress = new Uri(configuration.GetSection("ExternalServices").GetSection("SchoolManagmentSystemAPI").Value);
        }

        public async Task<CountriesBL<Countries>> SelectCountryByID(int ID)
        {
           CountriesBL<Countries> countries = new CountriesBL<Countries>();


            var CountriesJson = await httpClient.GetStringAsync($"Countries/{ID}");
            countries = JsonConvert.DeserializeObject<CountriesBL<Countries>>(CountriesJson);





            return countries;
        }
        public async Task<CountriesBL<Countries>> SelectCountryByName(string CountryName)
        {

            CountriesBL<Countries> countries = new CountriesBL<Countries>();


            var CountryJson = await httpClient.GetStringAsync($"Countries/Name/{CountryName}");
            countries = JsonConvert.DeserializeObject<CountriesBL<Countries>>(CountryJson);


            return countries;
        }
        public async Task < List<CountriesBL<Countries>>> SelectAllCountryes()
        {
              List<CountriesBL<Countries>> countries = new List<CountriesBL<Countries>>();
            
         
            var CountriesJson = await httpClient.GetStringAsync("Countries");
            countries = JsonConvert.DeserializeObject<List<CountriesBL<Countries>>>(CountriesJson);

         
            
            

            return countries;
        }
        public async Task<CountriesBL<Countries>> SaveCountry(CountriesBL<Countries> country)
        {
            var countryJson = JsonConvert.SerializeObject(country);

            var requestContent = new StringContent(countryJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("Countries", requestContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var createdCompany = JsonConvert.DeserializeObject< bool>(content);

            return country;
          
        }
        public async Task<CountriesBL<Countries>> DeleteCountry(int CountryId)
        {

            CountriesBL<Countries> countries = await SelectCountryByID(CountryId);

            HttpResponseMessage response = await httpClient.DeleteAsync("Countries" +"/"+ CountryId);

           

            return countries;
            
          }






        public async Task<CountriesBL<Countries>> UpdateCountry( CountriesBL<Countries> countries)
        {
            var country = JsonConvert.SerializeObject(countries);
            var requestContent = new StringContent(country, Encoding.UTF8, "application/json");
         //   var uri = Path.Combine("Countries", "fc12c11e-33a3-45e2-f11e-08d8bdb38ded");
            var response = await httpClient.PutAsync("Countries", requestContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var createdCompany = JsonConvert.DeserializeObject<bool>(content);

            return countries;
        }
    }
}


