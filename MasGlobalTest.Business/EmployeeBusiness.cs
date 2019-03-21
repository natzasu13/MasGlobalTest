using MasGlobalTest.DataAccess;
using MasGlobalTest.DataAccess.Interfaces;
using MasGlobalTest.DataAccess.Repositories;
using System;
using System.Collections.Generic;

namespace MasGlobalTest.Business
{
    public class EmployeeBusiness : IEmployeeRepository
    {
        IEmployeeRepository _Repositorio;
        private IEmployeeRepository Repositorio
        {
            get
            {
                if (_Repositorio == null)
                    _Repositorio = new EmployeeRepository();
                return _Repositorio;
            }
        }

        public IEnumerable<Employess> ConsumeApi(int id)
        {
            return Repositorio.ConsumeApi(id);
        }
    }
}
