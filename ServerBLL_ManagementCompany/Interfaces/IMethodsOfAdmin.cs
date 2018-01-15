using DTOs_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBLL_ManagementCompany.Interfaces
{
    public interface IMethodsOfAdmin
    {
       UserDTO GetUserByNumberOfAppartment(int numOfAppartment);
    }
}
