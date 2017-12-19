using ServerDAL_ManagementCompany.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Realizations
{
    public class UserValidation : IUserValidation
    {
        private CompanyContext ctx = new CompanyContext();
        private static string challenge = String.Empty;
        private static string log = String.Empty;
        private int challengeLength = 10;

        public string GetRandomStringByLoginForCheckPass(string login)
        {
            int count = ctx.Users.Where(f => f.Login == login).Count();

            if (count == 0)
                return "-1";

            log = login;
            challenge = HashMethods.HashMethods.GetRandomString_Challenge(challengeLength);
            
            return challenge;
        }

        public bool? IsEmailValid(string email)
        {
            int count = ctx.Users.Where(f => f.Email == email).Count();

            return count != 0 ? true : false;
        }

        public int? GetUserIdIfPasswordValid(string hashPassChall)
        {
            byte[] hashPass = ctx.Users.Where(f => f.Login == log).Select(f => f.Password).First();
            string hashPassword = Encoding.ASCII.GetString(hashPass);

            string hashChallenge = HashMethods.HashMethods.GetHashString(challenge);
            string res = HashMethods.HashMethods.GetHashString(hashPassword + hashChallenge);

            challenge = String.Empty;
            

            if (hashPassChall == res)
                return ctx.Users.Where(f => f.Login == log).Select(f => f.Id).First();
            else
                return -1;
        }

        public bool? IsLoginValid(string login)
        {
            int count = ctx.Users.Where(f => f.Login == login).Count();

            return count != 0 ? true : false;
        }
    }
}
