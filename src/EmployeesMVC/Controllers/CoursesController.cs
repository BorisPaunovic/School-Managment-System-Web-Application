using AutoMapper;
using EmployeeMVC.IServices;
using Microsoft.AspNetCore.Mvc;
using School.DataModels.Models;
using School.Services.Interfaces;
using SMS.IBusinessLogic;
using SMS.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagmentSystem.Controllers
{
    public class CoursesController : Controller
    {
 
        private readonly IMapper _mapper;
        private readonly ICoursesService _coursesServices;
        private readonly ICourseBusinesLogic _coursesBusinessLogic;

        [BindProperty(SupportsGet = true)]
        public string IsDeleted { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        public CoursesBL<Courses> CoursesBL { get; set; }


        [BindProperty(SupportsGet = true)]

        public string filter { get; set; }
        public CoursesController ( IMapper mapper, ICoursesService coursesServices, ICourseBusinesLogic coursesBusinessLogic)
        {
           
            this._mapper = mapper;
            this._coursesServices = coursesServices;
            this._coursesBusinessLogic = coursesBusinessLogic;
        }


        public async Task<IActionResult> Index()
        {
            List<CoursesBL<Courses>> courses = await _coursesBusinessLogic.SelectAllCourses();
            List<CoursesBL<Courses>> filterdCourses = new List<CoursesBL<Courses>>();
            if (filter != null)
            {

                foreach (var element in courses)
                {
                    if (element.Data.CoursesName.ToLower().Contains(filter.ToLower()))
                    {
                        filterdCourses.Add(element);
                    }
                }
                courses.Clear();
                courses = filterdCourses;
            }

            ViewBag.IsDeleted = IsDeleted;
            return View(courses);
        }

        public async Task<IActionResult> Details()
        {
            CoursesBL < Courses > coursesBL = await _coursesBusinessLogic.SelectCourseByID(Id);

            return View(coursesBL);
        }


        public async Task<IActionResult> Delete()
        {
            CoursesBL<Courses> coursesBL = await _coursesBusinessLogic.SelectCourseByID(Id);
            return View(coursesBL);
        }

        public async Task<IActionResult> ConfirmDelete()
        {
            await _coursesBusinessLogic.DeleteCourse(Id);

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Save()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveCourse()
        {

            var countriesBL = await _coursesBusinessLogic.SaveCourse(CoursesBL);



            return RedirectToAction("Index");
        }




        [HttpGet]
        public async Task<IActionResult> Edit()
        {

            CoursesBL = await _coursesBusinessLogic.SelectCourseByID(Id);
            return View(CoursesBL);

        }
        [HttpPost]
        public async Task<IActionResult> EditCourse()
        {

            CoursesBL = await _coursesBusinessLogic.UpdateCourse(CoursesBL);

            return RedirectToAction("Index");
        }
    }
}
