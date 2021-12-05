using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMomentsApp.Models.Repository
{
    public static class TeacherRepository
    {

        private static HttpClient _httpClient = InitializeHttpClient();
        private static Uri BaseUrl = new Uri("http://10.0.2.2:49630/api");
        private static IEnumerable<Teacher> teachers;
        public async static Task<IEnumerable<Teacher>> GetTeachers()
        {
            Console.WriteLine("In GetTeachers in TeacherRepository");
            Uri fullUrl = new Uri(BaseUrl + "/teachers");
            Console.WriteLine(fullUrl);

            HttpResponseMessage response = await _httpClient.GetAsync(fullUrl);


            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("success");
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                teachers = JsonConvert.DeserializeObject<IEnumerable<Teacher>>(content);
                return teachers;
            }
            return null;
        }

        public async static Task<Teacher> GetTeacher(int id)
        {
            HttpClient httpClient = _httpClient;
            Uri fullUrl = new Uri(BaseUrl + "teachers/" + id);
            var options = new JsonSerializerSettings { };


            HttpResponseMessage response = await httpClient.GetAsync(fullUrl);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Teacher teacher = JsonConvert.DeserializeObject<Teacher>(content);
                return teacher;
            }
            return null;
        }

        public static bool TeacherExistsByTeacherNumber(string teachernumber)
        {
            foreach(var teacher in teachers)
            {
                if(teacher.TeacherNumber == teachernumber)
                {
                    return true;
                }
            }
            return false;
        }

        private static HttpClient InitializeHttpClient()
        {
            return _httpClient ?? new HttpClient();
        }
    }
}
