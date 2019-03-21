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
                    viewModel.name = data.name;
                    viewModel.monthlySalary = data.monthlySalary;
                    viewModel.id = data.id;
                    viewModel.roleDescription = data.roleDescription;
                    viewModel.roleId = data.roleId;
                    viewModel.roleName = data.roleName;
                    viewModel.hourlySalary = data.hourlySalary;


                    model.Add(viewModel);
                }
            }

            return model.OrderBy(x => x.name).ToList();
        }

    
    }
}
