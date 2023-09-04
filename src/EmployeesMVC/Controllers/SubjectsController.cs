using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.DataModels.Models;
using SMS.BusinessLogic;
using SMS.IBusinessLogic;
using SMS.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagmentSystem.Controllers
{
    public class SubjectsController : Controller
    {

        private readonly IMapper _mapper;
        private readonly ISubjectsService _subjectsService;
        private readonly ISubjectsBusinessLogic _subjectsBusinessLogic;

        [BindProperty(SupportsGet = true)]
        public string IsDeleted { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        public SubjectsBL<Subjects> SubjectsBL { get; set; }


        [BindProperty(SupportsGet = true)]

        public string filter { get; set; }
        public SubjectsController(IMapper mapper, ISubjectsService subjectsService, ISubjectsBusinessLogic subjectsBusinessLogic)
        {

            this._mapper = mapper;
            this._subjectsService = subjectsService;
            this._subjectsBusinessLogic = subjectsBusinessLogic;
        }


        public async Task<IActionResult> Index()
        {
            List<SubjectsBL<Subjects>> subjects = await _subjectsBusinessLogic.SelectAllSubjects();
            List<SubjectsBL<Subjects>> filterdSubjects= new List<SubjectsBL<Subjects>>();
            if (filter != null)
            {

                foreach (var element in subjects)
                {
                    if (element.Data.SubjectName.ToLower().Contains(filter.ToLower()))
                    {
                        filterdSubjects.Add(element);
                    }
                }
                subjects.Clear();
                subjects = filterdSubjects;
            }

            ViewBag.IsDeleted = IsDeleted;
            return View(subjects);
        }

        public async Task<IActionResult> Details()
        {
            SubjectsBL < Subjects > subjectsBL = await _subjectsBusinessLogic.SelectSubjectByID(Id);

            return View(subjectsBL);
        }


        public async Task<IActionResult> Delete()
        {
            SubjectsBL<Subjects> subjectsBL = await _subjectsBusinessLogic.SelectSubjectByID(Id);

            return View(subjectsBL);
        }

        public async Task<IActionResult> ConfirmDelete()
        {
            await _subjectsBusinessLogic.DeleteSubject(Id);

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Save()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveSubject()
        {

            var countriesBL = await _subjectsBusinessLogic.SaveSubject(SubjectsBL);



            return RedirectToAction("Index");
        }




        [HttpGet]
        public async Task<IActionResult> Edit()
        {

            SubjectsBL = await _subjectsBusinessLogic.SelectSubjectByID(Id);
            return View(SubjectsBL);

        }
        [HttpPost]
        public async Task<IActionResult> EditSubject()
        {

            SubjectsBL = await _subjectsBusinessLogic.UpdateSubject(SubjectsBL);

            return RedirectToAction("Index");
        }
    }
}
