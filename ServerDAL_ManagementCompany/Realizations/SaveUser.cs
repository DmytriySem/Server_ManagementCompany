using DTOs_library;
using ServerDAL_ManagementCompany.Entities;
using ServerDAL_ManagementCompany.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Realizations
{
    public class SaveUser : ISaveUser
    {
        private CompanyContext ctx = null;

        public SaveUser(string connStrName)
        {
            ctx = new CompanyContext(connStrName);
        }
        void ISaveUser.SaveUser(UserDTO userDTO)
        {
            User user = new User()
            {
                Login = userDTO.Login,
                Password = userDTO.Password,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                Phone = userDTO.Phone,
                BirthDate = userDTO.BirthDate,
                UserStatus = (UserStatus)userDTO.UserStatus
            };

            ctx.Users.Add(user);
            ctx.SaveChanges();
        }
    }
}
