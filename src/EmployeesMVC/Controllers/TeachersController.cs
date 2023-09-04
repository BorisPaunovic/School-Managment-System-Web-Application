using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.DataModels.Models;
using SMS.IBusinessLogic;
using SMS.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagmentSystem.Controllers
{
    public class TeachersController : Controller
    {
        private readonly IMapper _mapper;
       
        private readonly ITeachersBusinessLogic _teachersBusinessLogic;

        [BindProperty(SupportsGet = true)]
        public string IsDeleted { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        public TeachersBL<Teachers> TeachersBL { get; set; }


        [BindProperty(SupportsGet = true)]

        public string filter { get; set; }
        public TeachersController(IMapper mapper , ITeachersBusinessLogic teachersBusinessLogic)
        {

            this._mapper = mapper;
            
            this._teachersBusinessLogic = teachersBusinessLogic;
        }


        public async Task<IActionResult> Index()
        {
            List<TeachersBL<Teachers>> teachers = await _teachersBusinessLogic.SelectAllTeachers();
            List<TeachersBL<Teachers>> filterdTeachers = new List<TeachersBL<Teachers>>();
            if (filter != null)
            {

                foreach (var element in teachers)
                {
                    if (element.Data.FirstName.ToLower().Contains(filter.ToLower()))
                    {
                        filterdTeachers.Add(element);
                    }
                }
                teachers.Clear();
                teachers = filterdTeachers;
            }

            ViewBag.IsDeleted = IsDeleted;
            return View(teachers);
        }

        public async Task<IActionResult> Details()
        {
            TeachersBL<Teachers> teachersBL = await _teachersBusinessLogic.SelectTeacherByID(Id);

            return View(teachersBL);
        }


        public async Task<IActionResult> Delete()
        {
            TeachersBL<Teachers> teachersBL = await _teachersBusinessLogic.SelectTeacherByID(Id);

            return View(teachersBL);
        }

        public async Task<IActionResult> ConfirmDelete()
        {
            await _teachersBusinessLogic.DeleteTeacher(Id);

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Save()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveTeacher()
        {

            var teachersBL = await _teachersBusinessLogic.SaveTeacher(TeachersBL);



            return RedirectToAction("Index");
        }




        [HttpGet]
        public async Task<IActionResult> Edit()
        {

            TeachersBL = await _teachersBusinessLogic.SelectTeacherByID(Id);
            return View(TeachersBL);

        }
        [HttpPost]
        public async Task<IActionResult> EditTeacher()
        {

            TeachersBL = await _teachersBusinessLogic.UpdateTeacher(TeachersBL);

            return RedirectToAction("Index");
        }
    }
}
