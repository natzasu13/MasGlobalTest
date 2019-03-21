using MasGlobalTest.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace MasGlobalTest.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Employess> ConsumeApi(int id)
        {
            IEnumerable<Employess> members = null;
            string url = "http://masglobaltestapi.azurewebsites.net/swagger/#!/Employees/ApiEmployeesGet";

            using (var client = new HttpClient())
            {
                if (id != 0)
                    client.BaseAddress = new Uri(url);
                else
                {
                    url = url + "/" + id;
                    client.BaseAddress = new Uri(url);
                }

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("member");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Employess>>();
                    readTask.Wait();

                    members = readTask.Result;
                }
                else
                {
                    //Error response received   
                    members = Enumerable.Empty<Employess>();
                }
            }
            return members;
        }
    }
}
