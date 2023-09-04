using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using School.DataModels.Models;
using SMS.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service
{
    public class CoursesService: ICoursesService
    {

        private readonly IConfiguration _configuration;
       
        HttpClient httpClient = new HttpClient();
        public CoursesService(IConfiguration configuration)
        {
            this._configuration = configuration;
            httpClient.BaseAddress = new Uri(configuration.GetSection("ExternalServices").GetSection("SchoolManagmentSystemAPI").Value);
        }

        public async Task<CoursesBL<Courses>> SelectCourseByID(int CourseID)
        {
            CoursesBL<Courses> course = new CoursesBL<Courses>();


            var CourseJson = await httpClient.GetStringAsync($"Course/{CourseID}");
            course = JsonConvert.DeserializeObject<CoursesBL<Courses>>(CourseJson);





            return course;
        }
        public async Task<CoursesBL<Courses>> SelectCourseByName(string CourseName)
        {

            CoursesBL<Courses> course = new CoursesBL<Courses>();


            var CourseJson = await httpClient.GetStringAsync($"Course/Name/{CourseName}");
            course = JsonConvert.DeserializeObject<CoursesBL<Courses>>(CourseJson);


            return course;
        }
        public async Task<List<CoursesBL<Courses>>> SelectAllCourses()
        {
            List<CoursesBL<Courses>> courses = new List<CoursesBL<Courses>>();


            var CoursesJson = await httpClient.GetStringAsync("Course");
            courses = JsonConvert.DeserializeObject<List<CoursesBL<Courses>>>(CoursesJson);





            return courses;
        }
        public async Task<CoursesBL<Courses>> SaveCourse(CoursesBL<Courses> Course)
        {
            var courseJson = JsonConvert.SerializeObject(Course);

            var requestContent = new StringContent(courseJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("Course", requestContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var createdCompany = JsonConvert.DeserializeObject<bool>(content);

            return Course;

        }
        public async Task<CoursesBL<Courses>> DeleteCourse(int CourseId)
        {

            CoursesBL<Courses> course = await SelectCourseByID(CourseId);

            HttpResponseMessage response = await httpClient.DeleteAsync("Course" + "/" + CourseId);
            


               return course;

        }






        public async Task<CoursesBL<Courses>> UpdateCourse(CoursesBL<Courses> course)
        {
            var courseJson = JsonConvert.SerializeObject(course);
            var requestContent = new StringContent(courseJson, Encoding.UTF8, "application/json");
            //   var uri = Path.Combine("Countries", "fc12c11e-33a3-45e2-f11e-08d8bdb38ded");
            var response = await httpClient.PutAsync("Course", requestContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var createdCompany = JsonConvert.DeserializeObject<bool>(content);

            return course;
        }
    }
}
