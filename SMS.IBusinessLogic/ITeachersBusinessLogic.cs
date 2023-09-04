using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.IBusinessLogic
{
    public interface ITeachersBusinessLogic
    {
        public Task<TeachersBL<Teachers>> SelectTeacherByID(int TeachersId);

        public Task<TeachersBL<Teachers>> SelectTeacherByName(string TeachersName);

        public Task<List<TeachersBL<Teachers>>> SelectAllTeachers();

        public Task<TeachersBL<Teachers>> SaveTeacher(TeachersBL<Teachers> Teachers);

        public Task<TeachersBL<Teachers>> DeleteTeacher(int TeachersId);

        public Task<TeachersBL<Teachers>> UpdateTeacher(TeachersBL<Teachers> Teachers);
    }
}
