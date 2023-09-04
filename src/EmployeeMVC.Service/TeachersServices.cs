using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using School.DataModels.Models;
using SMS.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SMS.Service
{
    public class TeachersServices:ITeachersServices
    {

        private readonly IConfiguration _configuration;
        
        HttpClient httpClient = new HttpClient();
        public TeachersServices(IConfiguration configuration)
        {
            this._configuration = configuration;
            httpClient.BaseAddress = new Uri(configuration.GetSection("ExternalServices").GetSection("SchoolManagmentSystemAPI").Value);
        }

        public async Task<TeachersBL<Teachers>> SelectTeacherByID(int TeacherID)
        {
            TeachersBL<Teachers> teacherBL = new TeachersBL<Teachers>();


            var TeacherJson = await httpClient.GetStringAsync($"Teachers/{TeacherID}");
            teacherBL = JsonConvert.DeserializeObject<TeachersBL<Teachers>>(TeacherJson);





            return teacherBL;
        }
        public async Task<TeachersBL<Teachers>> SelectTeacherByName(string TeacherName)
        {

            TeachersBL<Teachers> teacherBL = new TeachersBL<Teachers>();


            var TeacherJson = await httpClient.GetStringAsync($"Teachers/Name/{TeacherName}");
            teacherBL = JsonConvert.DeserializeObject<TeachersBL<Teachers>>(TeacherJson);


            return teacherBL;
        }
        public async Task<List<TeachersBL<Teachers>>> SelectAllTeachers()
        {
            List<TeachersBL<Teachers>> teachersBL = new List<TeachersBL<Teachers>>();


            var TeachersJson = await httpClient.GetStringAsync("Teachers");
            teachersBL = JsonConvert.DeserializeObject<List<TeachersBL<Teachers>>>(TeachersJson);


          var a =  SelectTeacherByName("Milan");



            return teachersBL;
        }
        public async Task<TeachersBL<Teachers>> SaveTeacher(TeachersBL<Teachers> Teacher)
        {
            var teacherJson = JsonConvert.SerializeObject(Teacher);

            var requestContent = new StringContent(teacherJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("Teachers", requestContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var createdTeacher = JsonConvert.DeserializeObject<bool>(content);

            return Teacher;

        }
        public async Task<TeachersBL<Teachers>> DeleteTeacher(int TeacherId)
        {

            TeachersBL<Teachers> teacher = await SelectTeacherByID(TeacherId);

            HttpResponseMessage response = await httpClient.DeleteAsync("Teachers" + "/" + TeacherId);



            return teacher;

        }






        public async Task<TeachersBL<Teachers>> UpdateTeacher(TeachersBL<Teachers> Teacher)
        {
            var teacherJson = JsonConvert.SerializeObject(Teacher);
            var requestContent = new StringContent(teacherJson, Encoding.UTF8, "application/json");
            //   var uri = Path.Combine("Countries", "fc12c11e-33a3-45e2-f11e-08d8bdb38ded");
            var response = await httpClient.PutAsync("Teachers", requestContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var createdCompany = JsonConvert.DeserializeObject<bool>(content);

            return Teacher;
        }
    }
}
