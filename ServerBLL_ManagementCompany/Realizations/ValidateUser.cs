using ServerBLL_ManagementCompany.Interfaces;
using ServerDAL_ManagementCompany.Interfaces;
using ServerDAL_ManagementCompany.Realizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBLL_ManagementCompany.Realizations
{
    public class ValidateUser : IValidateUser
    {
        IUserValidation userValidation = new UserValidation();
        public string GetRandomStringByLoginForCheckPass(string login)
        {
            return userValidation?.GetRandomStringByLoginForCheckPass(login);
        }

        public int? GetUserIdIfPasswordValid(string hashPassChall)
        {
            return userValidation?.GetUserIdIfPasswordValid(hashPassChall);
        }

        public bool? IsEmailValid(string email)
        {
            return userValidation?.IsEmailValid(email);
        }

        public bool? IsLoginValid(string login)
        {
            return userValidation?.IsLoginValid(login);
        }

        public void recoverPassword(string email)
        {
            userValidation.recoverPassword(email);
        }
    }
}
