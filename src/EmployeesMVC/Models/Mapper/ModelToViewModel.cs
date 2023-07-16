using AutoMapper;
using EmployeesMVC.DataModel.Employee;
using School.DataModels.Models;

namespace EmployeesMVC.Models.Mapper
{
    public class ModelToViewModel:Profile
    {
        public ModelToViewModel() 
        {
            this.CreateMap<Employee, EmployeeViewModel>().
                ForMember(e => e.Name, evm => evm.MapFrom(c => c.Employee_Name)).
                ForMember(e => e.ProfileImage, evm => evm.MapFrom(c => c.Profile_Image)).
                ForMember(e => e.Salary, evm => evm.MapFrom(c => c.Employee_Salary)).
                ForMember(e => e.Age, evm => evm.MapFrom(c => c.Employee_Age));

            this.CreateMap<Countries, CountriesBL<Countries>>().ForPath(countries => countries.Data.CountriesID, element => element.MapFrom(countriesBL => countriesBL.CountriesID))
               .ForPath(countries => countries.Data.ISO, element => element.MapFrom(countriesBL => countriesBL.ISO))
               .ForPath(countries => countries.Data.CountryName, element => element.MapFrom(countriesBL => countriesBL.CountryName))
               .ForPath(countries => countries.Data.Deleted, element => element.MapFrom(countriesBL => countriesBL.Deleted))
               .ForPath(countries => countries.Data.PhoneCode, element => element.MapFrom(countriesBL => countriesBL.PhoneCode))
               .ForPath(countries => countries.Data.ISO3, element => element.MapFrom(countriesBL => countriesBL.ISO3)).ReverseMap();

        }
    }
}
