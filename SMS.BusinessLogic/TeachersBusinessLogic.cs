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
    public class TeachersBusinessLogic : ITeachersBusinessLogic
    {
        private readonly ITeachersServices _teachersServices;
        private readonly IMapper mapper;

        public TeachersBusinessLogic(ITeachersServices teachersServices, IMapper mapper)
        {


            this._teachersServices = teachersServices;
            this.mapper = mapper;
        }

        public async Task<TeachersBL<Teachers>> SelectTeacherByID(int TeacherId)
        {
            TeachersBL<Teachers> teacher = new TeachersBL<Teachers>();
            teacher = await _teachersServices.SelectTeacherByID(TeacherId);

            return teacher;
        }
        public async Task<TeachersBL<Teachers>> SelectTeacherByName(string subjectName)
        {
            TeachersBL<Teachers> teacher = new TeachersBL<Teachers>();
            teacher = await _teachersServices.SelectTeacherByName(  subjectName);

            return teacher;
        }
        public async Task<List<TeachersBL<Teachers>>> SelectAllTeachers()
        {
            List<TeachersBL<Teachers>> teachers = new List<TeachersBL<Teachers>>();
            teachers = await _teachersServices.SelectAllTeachers();

            return teachers;
        }

        public async Task<TeachersBL<Teachers>> DeleteTeacher(int TeacherId)
        {
            TeachersBL<Teachers> teacher = new TeachersBL<Teachers>();
            teacher = await _teachersServices.DeleteTeacher(TeacherId);

            return teacher;


        }
        public async Task<TeachersBL<Teachers>> SaveTeacher(TeachersBL<Teachers> Teacher)
        {
            var teacher = await _teachersServices.SaveTeacher(Teacher);
            return teacher;
        }

        public async Task<TeachersBL<Teachers>> UpdateTeacher (TeachersBL<Teachers> Teacher)
        {
            var teacher = await _teachersServices.UpdateTeacher(Teacher);
            return teacher;

        }
    }
}
