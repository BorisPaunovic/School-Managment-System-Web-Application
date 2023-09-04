using AutoMapper;
using School.DataModels.Models;
using School.Services.Interfaces;
using SMS.IBusinessLogic;
using SMS.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.BusinessLogic
{
    public class CourseBusinessLogic : ICourseBusinesLogic
    {
        private readonly ICoursesService _courseService;
        private readonly IMapper mapper;

        public CourseBusinessLogic(ICoursesService courseService, IMapper mapper)
        {


            this._courseService = courseService;
            this.mapper = mapper;
        }

        public async Task<CoursesBL<Courses>> SelectCourseByID(int CoursesID)
        {
            CoursesBL < Courses > courses = new CoursesBL<Courses>();
            courses = await _courseService.SelectCourseByID(CoursesID);

            return courses;
        }
        public async Task<CoursesBL<Courses>> SelectCourseByName(string CourseName)
        {
            CoursesBL<Courses> courses = new CoursesBL<Courses>();
            courses = await _courseService.SelectCourseByName(CourseName);

            return courses;
        }
        public async Task<List<CoursesBL<Courses>>> SelectAllCourses()
        {
                List<CoursesBL<Courses>> countries = new List<CoursesBL<Courses>>();
                countries = await _courseService.SelectAllCourses();

            return countries;
        }

        public async Task<CoursesBL<Courses>> DeleteCourse(int CourseId)
        {
            CoursesBL<Courses> courses = new CoursesBL<Courses>();
            courses = await _courseService.DeleteCourse(CourseId);

            return courses;


        }
        public async Task<CoursesBL<Courses>> SaveCourse(CoursesBL<Courses> Course)
        {
            var savedCourse = await _courseService.SaveCourse(Course);
            return savedCourse;
        }

        public async Task<CoursesBL<Courses>> UpdateCourse(CoursesBL<Courses> Course)
        {
            var savedCourse = await _courseService.UpdateCourse(Course);
            return savedCourse;

        }
    }
}
