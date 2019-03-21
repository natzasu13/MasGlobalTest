using MasGlobalTest.Business;
using MasGlobalTest.DataAccess;
using MasGlobalTest.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MasGlobalTest.UI.ApiControllers
{
    public class GetEmployeeController : ApiController
    {
        private readonly EmployeeBusiness _employeeBusiness;

        public GetEmployeeController()
        {
            if (_employeeBusiness == null)
                _employeeBusiness = new EmployeeBusiness();
        }

        // GET: api/GetEmployee
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GetEmployee/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        // GET: api/GetEmployee/List?idEmployee
        public List<EmployeeViewModel> List(int idEmployee)
        {
            IEnumerable<Employess> lData = _employeeBusiness.ConsumeApi(idEmployee);
            List<EmployeeViewModel> model = new List<EmployeeViewModel>();

            if (lData != null)
            {
                foreach (var data in lData)
                {
                    EmployeeViewModel viewModel = new EmployeeViewModel();
                    //    viewModel.typeAccount = new typeAccount();
                    //    viewModel.id = data.id;
                    //    viewModel.dateCreate = data.dateCreate;
                    //    viewModel.state = data.state;
                    //    viewModel.description = data.description;
                    //    viewModel.code = data.code;
                    //    viewModel.longDescription = data.longDescription;


                    //    model.Add(viewModel);
                    //}
                }

            }
            return model.OrderBy(x => x.name).ToList();
        }

        // POST: api/GetEmployee
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GetEmployee/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetEmployee/5
        public void Delete(int id)
        {
        }
    }
}
