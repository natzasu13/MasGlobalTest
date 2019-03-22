using MasGlobalTest.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
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
            string urlParameters = "";// "?api_key=123";

            if (id != 0)
                url = url + "/" + id;

            // OK                                      
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Get;
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentType = "application/json";
            request.Accept = "application/json";

            var response = request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var json = reader.ReadToEnd();
                // do stuffs...
            }
                                          
            return null;
        }
    }
}
