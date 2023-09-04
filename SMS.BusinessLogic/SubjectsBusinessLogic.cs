using AutoMapper;
using School.DataModels.Models;
using SMS.IBusinessLogic;
using SMS.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.BusinessLogic
{
    public class SubjectsBusinessLogic : ISubjectsBusinessLogic
    {
        private readonly ISubjectsService _subjectsService;
        private readonly IMapper mapper;

        public SubjectsBusinessLogic(ISubjectsService subjectsService, IMapper mapper)
        {


            this._subjectsService = subjectsService;
            this.mapper = mapper;
        }

        public async Task<SubjectsBL<Subjects>> SelectSubjectByID(int SubjectId)
        {
            SubjectsBL<Subjects> subject = new SubjectsBL<Subjects>();
            subject = await _subjectsService.SelectSubjectByID(SubjectId);

            return subject;
        }
        public async Task<SubjectsBL<Subjects>> SelectSubjectByName(string subjectName)
        {
            SubjectsBL<Subjects> subject = new SubjectsBL<Subjects>();
            subject = await _subjectsService.SelectSubjectByName(subjectName);

            return subject;
        }
        public async Task<List<SubjectsBL<Subjects>>> SelectAllSubjects()
        {
            List<SubjectsBL<Subjects>> subjects = new List<SubjectsBL<Subjects>>();
            subjects = await _subjectsService.SelectAllSubjects();

            return subjects;
        }

        public async Task<SubjectsBL<Subjects>> DeleteSubject(int CourseId)
        {
            SubjectsBL<Subjects> subject = new SubjectsBL<Subjects>();
            subject = await _subjectsService.DeleteSubject(CourseId);

            return subject;


        }
        public async Task<SubjectsBL<Subjects>> SaveSubject(SubjectsBL<Subjects> Subject)
        {
            var subject = await _subjectsService.SaveSubject(Subject);
            return subject;
        }

        public async Task<SubjectsBL<Subjects>> UpdateSubject(SubjectsBL<Subjects> Subject)
        {
            var subject = await _subjectsService.UpdateSubject(Subject);
            return subject;

        }
    }
}
