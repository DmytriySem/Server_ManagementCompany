using DTOs_library;
using ServerDAL_ManagementCompany.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Interfaces
{
    public interface ISaveUser
    {
        void SaveUser(UserDTO userDTO);
    }
}
