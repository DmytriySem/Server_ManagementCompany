using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBLL_ManagementCompany.Interfaces
{
    public interface IValidateUser
    {
        bool? IsLoginValid(string login);
        string GetRandomStringByLoginForCheckPass(string login);
        int? GetUserIdIfPasswordValid(string hashPassChall);
        bool? IsEmailValid(string email);
        void recoverPassword(string email);
    }
}
