using ServerBLL_ManagementCompany.Interfaces;
using ServerDAL_ManagementCompany.Interfaces;
using ServerDAL_ManagementCompany.Realizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs_library;

namespace ServerBLL_ManagementCompany.Realizations
{
    public class MethodsOfAdmin : IMethodsOfAdmin
    {
        private IAdminMethods methodsAdmin = null;
        public MethodsOfAdmin(string connStr)
        {
            methodsAdmin = new AdminMethods(connStr);
        }

        public UserDTO GetUserByNumberOfAppartment(int numOfAppartment)
        {
            
            return methodsAdmin.GetUserByNumberOfAppartment(numOfAppartment);
        }
    }
}
