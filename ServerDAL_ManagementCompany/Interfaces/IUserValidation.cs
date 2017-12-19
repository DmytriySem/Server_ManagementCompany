﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Interfaces
{
    public interface IUserValidation
    {
        bool? IsLoginValid(string login);
        string GetRandomStringByLoginForCheckPass(string login);
        int? GetUserIdIfPasswordValid(string hashPassChall);
        bool? IsEmailValid(string email);
    }
}
