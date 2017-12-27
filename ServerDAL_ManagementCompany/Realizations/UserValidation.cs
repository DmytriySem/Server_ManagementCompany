using EASendMail;
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
        private CompanyContext ctx = null;
        private static string challenge = String.Empty;
        private static string log = String.Empty;
        private int challengeLength = 10;

        public UserValidation(string connStr)
        {
            ctx = new CompanyContext(connStr);
        }

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

        public void recoverPassword(string email)
        {
            string senderEmail =  ctx.CompanyDatas.Select(x => x.Email).First();
            string senderPass = "helloworld18";

            string recieverEmail = email;

            SmtpServer server = new SmtpServer("smtp.gmail.com", 465);
            server.ConnectType = SmtpConnectType.ConnectSSLAuto;
            server.User = senderEmail;
            server.Password = senderPass;

            string recoverFuturePass = HashMethods.HashMethods.GetRandomString_Challenge(10);

            var query = ctx.Users.Where(f => f.Email == email).FirstOrDefault();
            string login = query.Login;
            query.Password = Encoding.ASCII.GetBytes(HashMethods.HashMethods.GetHashString(recoverFuturePass));
            ctx.SaveChanges();

            SmtpClient client = new SmtpClient();

            SmtpMail message = new SmtpMail("TryIt")
            {
                From = senderEmail,
                To = recieverEmail,
                Subject = "Recovery email",
                TextBody = "Login: " + login + "\nTemporary password: " + recoverFuturePass                
            };

            try
            {
                client.SendMail(server, message);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
