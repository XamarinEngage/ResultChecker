using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ResultChecker
{
    public class Service
    {

        HttpClient  client;

        public Service()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("http://resultchecking.herokuapp.com")
            };
        }

        public async Task<Candidate> GetResult(string examYear, string examType,  string examNo)
        {
            var response = client.GetAsync($"/result/search?examYear={examYear}&examType={examType}&examNo={examNo}");
            var responseData = await response.Result.Content.ReadAsStringAsync();
            var Candidate = JsonConvert.DeserializeObject<Candidate>(responseData);
            return Candidate;
        }
    }
}
