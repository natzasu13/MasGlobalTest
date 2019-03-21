using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasGlobalTest.DataAccess.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employess> ConsumeApi(int id);
    }
}
