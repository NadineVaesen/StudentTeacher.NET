using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMomentsApp.Models.Repository
{
    public static class StudentRepository
    {
        private static HttpClient _httpClient = InitializeHttpClient();

        private static Uri BaseUrl = new Uri("http://10.0.2.2:49630/api");

        public async static Task<IEnumerable<Student>> GetStudents()
        {
            Console.WriteLine("In GetStudents in StudentRepository");
            Uri fullUrl = new Uri(BaseUrl + "/students");
            Console.WriteLine(fullUrl);

            HttpResponseMessage response = await _httpClient.GetAsync(fullUrl);


            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("success");
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                IEnumerable<Student> students = JsonConvert.DeserializeObject<IEnumerable<Student>>(content);
                return students;
            }
            return null;
        }

        public async static Task<Student> GetStudent(int id)
        {
            HttpClient httpClient = _httpClient;
            Uri fullUrl = new Uri(BaseUrl + "students/" + id);
            var options = new JsonSerializerSettings { };


            HttpResponseMessage response = await httpClient.GetAsync(fullUrl);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Student student = JsonConvert.DeserializeObject<Student>(content);
                return student;
            }
            return null;
        }
        public static bool StudentExistsByStudentNumber(string studentnumber)
        {
            return true;
        }


        private static HttpClient InitializeHttpClient()
        {
            return _httpClient ?? new HttpClient();
        }

    }
}
