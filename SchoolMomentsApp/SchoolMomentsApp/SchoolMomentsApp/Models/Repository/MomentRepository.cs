using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMomentsApp.Models.Repository
{
    public static class MomentRepository
    {
        private static HttpClient _httpClient = InitializeHttpClient();
        private static Uri BaseUrl = new Uri("http://10.0.2.2:49630/api");

        public async static Task<IEnumerable<Moment>> GetMomentsAsync()
        {

            Console.WriteLine("In GetMomentsAsync in MomentRepository");
            Uri fullUrl = new Uri(BaseUrl + "/moments");
            Console.WriteLine(fullUrl);

            HttpResponseMessage response = await _httpClient.GetAsync(fullUrl);

            
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("success");
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                IEnumerable<Moment> moments = JsonConvert.DeserializeObject<IEnumerable<Moment>>(content);
                return moments;
            }
            return null;
       
        }

        public async static Task<Moment> GetMoment(int id)
        {

            HttpClient httpClient = _httpClient;
            Uri fullUrl = new Uri(BaseUrl + "moments/" + id);
            var options = new JsonSerializerSettings { };


            HttpResponseMessage response = await httpClient.GetAsync(fullUrl);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Moment moment = JsonConvert.DeserializeObject<Moment>(content);
                return moment;
            }
            return null;
        }

        private static HttpClient InitializeHttpClient()
        {
            return _httpClient ?? new HttpClient();
        }
    }
}
