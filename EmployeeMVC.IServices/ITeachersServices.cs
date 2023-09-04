using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.IServices
{
    public interface ITeachersServices
    {
        public Task<TeachersBL<Teachers>> SelectTeacherByID(int TeacherId);

        public Task<TeachersBL<Teachers>> SelectTeacherByName(string TeacherName);

        public Task<List<TeachersBL<Teachers>>> SelectAllTeachers();

        public Task<TeachersBL<Teachers>> SaveTeacher(TeachersBL<Teachers> Teacher);

        public Task<TeachersBL<Teachers>> DeleteTeacher(int TeacherId);

        public Task<TeachersBL<Teachers>> UpdateTeacher(TeachersBL<Teachers> Teacher);
    }
}
