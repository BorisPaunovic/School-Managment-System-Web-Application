using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.IServices
{
    public interface ICoursesService
    {
        public Task<CoursesBL<Courses>> SelectCourseByID(int CourseID);

        public Task<CoursesBL<Courses>> SelectCourseByName(string CourseName);

        public Task<List<CoursesBL<Courses>>> SelectAllCourses();

        public Task<CoursesBL<Courses>> SaveCourse(CoursesBL<Courses> Course);

        public Task<CoursesBL<Courses>> DeleteCourse(int CountryId);

        public Task<CoursesBL<Courses>> UpdateCourse(CoursesBL<Courses> Course);
    }
}
