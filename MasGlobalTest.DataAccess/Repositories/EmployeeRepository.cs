using MasGlobalTest.DataAccess.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
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


            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            //request.UserAgent = RequestConstants.UserAgentValue;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            var content = string.Empty;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }
            }


            var releases = JArray.Parse(content);

            return null;
            
        }
    }
}
