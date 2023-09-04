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
    public class SubjectsService: ISubjectsService
    {

        private readonly IConfiguration _configuration;
      
        HttpClient httpClient = new HttpClient();
        public SubjectsService(IConfiguration configuration)
        {
            this._configuration = configuration;
            httpClient.BaseAddress = new Uri(configuration.GetSection("ExternalServices").GetSection("SchoolManagmentSystemAPI").Value);
        }

        public async Task<SubjectsBL<Subjects>> SelectSubjectByID(int SubjectID)
        {
            SubjectsBL<Subjects> subjectsBL = new SubjectsBL<Subjects>();


            var SubjectJson = await httpClient.GetStringAsync($"Subjects/{SubjectID}");
            subjectsBL = JsonConvert.DeserializeObject < SubjectsBL < Subjects >> (SubjectJson);





            return subjectsBL;
        }
        public async Task<SubjectsBL<Subjects>> SelectSubjectByName(string SubjectName)
        {

            SubjectsBL<Subjects> subjectsBL = new SubjectsBL<Subjects>();


            var SubjectJson = await httpClient.GetStringAsync($"Subjects/Name/{SubjectName}");
            subjectsBL = JsonConvert.DeserializeObject<SubjectsBL<Subjects>>(SubjectJson);


            return subjectsBL;
        }
        public async Task<List<SubjectsBL<Subjects>>> SelectAllSubjects()
        {
            List<SubjectsBL<Subjects>> subjectsBLs = new List<SubjectsBL<Subjects>>();


            var SubjectJson = await httpClient.GetStringAsync("Subjects");
            subjectsBLs = JsonConvert.DeserializeObject<List<SubjectsBL<Subjects>>>(SubjectJson);





            return subjectsBLs;
        }
        public async Task<SubjectsBL<Subjects>> SaveSubject(SubjectsBL<Subjects> Subject)
        {
            var subjectJson = JsonConvert.SerializeObject(Subject);

            var requestContent = new StringContent(subjectJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("Subjects", requestContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var createdSubject = JsonConvert.DeserializeObject<bool>(content);

            return Subject;

        }
        public async Task<SubjectsBL<Subjects>> DeleteSubject(int CourseId)
        {

            SubjectsBL < Subjects > subject = await SelectSubjectByID(CourseId);

            HttpResponseMessage response = await httpClient.DeleteAsync("Subjects" + "/" + CourseId);



            return subject;

        }






        public async Task<SubjectsBL<Subjects>> UpdateSubject(SubjectsBL<Subjects> subject)
        {
            var subjectJson = JsonConvert.SerializeObject(subject);
            var requestContent = new StringContent(subjectJson, Encoding.UTF8, "application/json");
            //   var uri = Path.Combine("Countries", "fc12c11e-33a3-45e2-f11e-08d8bdb38ded");
            var response = await httpClient.PutAsync("Subjects", requestContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var createdCompany = JsonConvert.DeserializeObject<bool>(content);

            return subject;
        }
    }
}
