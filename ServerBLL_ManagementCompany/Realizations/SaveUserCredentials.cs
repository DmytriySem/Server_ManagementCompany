using DTOs_library;
using ServerBLL_ManagementCompany.Interfaces;
using ServerDAL_ManagementCompany.Entities;
using ServerDAL_ManagementCompany.Interfaces;
using ServerDAL_ManagementCompany.Realizations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ServerBLL_ManagementCompany.Realizations
{
    public class SaveUserCredentials : ISaveUserCredentials
    {
        private ISaveUser saveUser = null;
        public SaveUserCredentials(string connStr)
        {
            saveUser = new SaveUser(connStr);
        }
        void ISaveUserCredentials.SaveUserCredentials(UserDTO userDTO)
        {
            saveUser.SaveUser(userDTO);
        }
    }
}
