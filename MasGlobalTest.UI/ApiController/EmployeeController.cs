using MasGlobalTest.Business;
using MasGlobalTest.DataAccess;
using MasGlobalTest.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MasGlobalTest.UI.ApiController
{
    public class EmployeeController : System.Web.Http.ApiController
    {
        private readonly EmployeeBusiness _employeeBusiness;

        public EmployeeController()
        {
            if (_employeeBusiness == null)
                _employeeBusiness = new EmployeeBusiness();
        }

        /// <summary>
        /// List Employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("EmployeeList")]
        public List<EmployeeViewModel> EmployeeList(int id)
        {
            int inputId = 0;
            IEnumerable<Employess> lData = _employeeBusiness.ConsumeApi(inputId);
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
    }
}
