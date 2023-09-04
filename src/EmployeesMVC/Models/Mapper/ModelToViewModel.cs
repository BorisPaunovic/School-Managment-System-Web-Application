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

            this.CreateMap<Courses, CoursesBL<Courses>>().ForPath(courses => courses.Data.CoursesID, element => element.MapFrom(coursesBL => coursesBL.CoursesID))
              .ForPath(courses => courses.Data.CoursesDescription, element => element.MapFrom(coursesBL => coursesBL.CoursesDescription))
              .ForPath(courses => courses.Data.CoursesName, element => element.MapFrom(coursesBL => coursesBL.CoursesName))
              .ForPath(courses => courses.Data.Deleted, element => element.MapFrom(coursesBL => coursesBL.Deleted))
              .ReverseMap();

            this.CreateMap<Subjects, SubjectsBL<Subjects>>().ForPath(subjects => subjects.Data.SubjectId, element => element.MapFrom(subjectsBL => subjectsBL.SubjectId))
            .ForPath(subjects => subjects.Data.SubjectDescription, element => element.MapFrom(subjectsBL => subjectsBL.SubjectDescription))
            .ForPath(subjects => subjects.Data.SubjectName, element => element.MapFrom(subjectsBL => subjectsBL.SubjectName))
            .ForPath(subjects => subjects.Data.Deleted, element => element.MapFrom(subjectsBL => subjectsBL.Deleted))
            .ReverseMap();

            this.CreateMap<Teachers, TeachersBL<Teachers>>().ForPath(teachers => teachers.Data.TeachersId, element => element.MapFrom(teachersBL => teachersBL.TeachersId))
            .ForPath(teachers => teachers.Data.FirstName, element => element.MapFrom(teachersBL => teachersBL.FirstName))
            .ForPath(teachers => teachers.Data.LastName, element => element.MapFrom(teachersBL => teachersBL.LastName))
            .ForPath(teachers => teachers.Data.DateOfBirth, element => element.MapFrom(teachersBL => teachersBL.DateOfBirth))
            .ForPath(teachers => teachers.Data.Email, element => element.MapFrom(teachersBL => teachersBL.Email))
            .ForPath(teachers => teachers.Data.Adress, element => element.MapFrom(teachersBL => teachersBL.Adress))
            .ForPath(teachers => teachers.Data.Deleted, element => element.MapFrom(teachersBL => teachersBL.Deleted))
            .ReverseMap();
        }
    }
}
