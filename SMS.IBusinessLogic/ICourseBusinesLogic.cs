using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.IBusinessLogic
{
    public interface ICourseBusinesLogic
    {
        public Task<CoursesBL<Courses>> SelectCourseByID(int CourseID);

        public Task<CoursesBL<Courses>> SelectCourseByName(string CountryName);

        public Task<List<CoursesBL<Courses>>> SelectAllCourses();

        public Task<CoursesBL<Courses>> SaveCourse(CoursesBL<Courses> country);

        public Task<CoursesBL<Courses>> DeleteCourse(int CountryId);

        public Task<CoursesBL<Courses>> UpdateCourse(CoursesBL<Courses> countries);
    }
}
