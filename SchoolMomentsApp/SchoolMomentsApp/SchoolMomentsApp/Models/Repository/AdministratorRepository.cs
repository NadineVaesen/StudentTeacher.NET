using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMomentsApp.Models.Repository
{
    public static class AdministratorRepository
    {
        private static HttpClient _httpClient = InitializeHttpClient();

        private static Uri BaseUrl = new Uri("http://10.0.2.2:49630/api");
        public async static Task<IEnumerable<Administrator>> GetAdministrators()
        {
            Console.WriteLine("In GetAdministrators in AdministratorRepository");
            Uri fullUrl = new Uri(BaseUrl + "/administrators");
            Console.WriteLine(fullUrl);

            HttpResponseMessage response = await _httpClient.GetAsync(fullUrl);


            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("success");
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                IEnumerable<Administrator> admins = JsonConvert.DeserializeObject<IEnumerable<Administrator>>(content);
                return admins;
            }
            return null;
        }

        public static Administrator GetAdministrator()
        {
            return new Administrator();
        }
        public static bool AdministratorExistByAdminNumber(string AdminNumber)
        {
            return true;
        }

        private static HttpClient InitializeHttpClient()
        {
            return _httpClient ?? new HttpClient();
        }
    }
}
