using MasGlobalTest.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobalTest.Business
{
    public class EmployeeFactory
    {
        public int CalculateSalary(Employess data)
        {
            int salary = 0;

            if (data.contractTypeName == "HourlySalaryEmployee")
            {
                salary = 120 * data.hourlySalary * 12;
            }
            else if (data.contractTypeName == "MonthlySalaryEmployee")
            {
                salary =  data.monthlySalary * 12;
            }

            return salary;
        }
    }
}
