using ServerBLL_ManagementCompany.Interfaces;
using ServerBLL_ManagementCompany.Realizations;
using ServerBLL_ManagementCompany.ServiceBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DTOs_library;

namespace WcfService_ManagementCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        private const string connStrServer = "DESKTOP-P136AIJ";
        private const string connStrClient = @"DMITRIY-ПК\SQLEXPRESS";
        private string connStr = String.Empty;
        private IValidateUser userValidate = null;
        private ICreateHouse createHouse = null;
        private ISaveUserCredentials saveUser = null;
        private IMethodsOfAdmin adminMethods = null;

        public Service()
        {
            connStr = GetConnStrForThisMashine.GetConnStr();

            try
            {
                userValidate = /*null;//*/ new ValidateUser(connStr);
                if (userValidate == null)
                    throw new Exception("out of memory");
                createHouse = new CreateHouse(connStr);
                saveUser = new SaveUserCredentials(connStr);
                adminMethods = new MethodsOfAdmin(connStr);
            }
            catch(OutOfMemoryException ex)
            {
                throw new Exception("out of memory" + ex.InnerException.ToString());
            }
        }

        public string GetRandomStringFromServer(string login)
        {
            return userValidate.GetRandomStringByLoginForCheckPass(login);
        }

        public bool IsEmailValid(string email)
        {
            return userValidate.IsEmailValid(email);
        }

        public bool IsLoginValid(string login)
        {
            return userValidate.IsLoginValid(login);
        }

        public int GetUserIdIfPasswordValid(string hashPassChall)
        {
            return userValidate.GetUserIdIfPasswordValid(hashPassChall);
        }

        public void CreateHouse()
        {
            createHouse.BuildHouse();
        }

        public void RecoverPassword(string email)
        {
            userValidate.recoverPassword(email);
        }

        public UserDTO GetUserByNumberOfAppartment(int numOfAppartment)
        {
            return adminMethods.GetUserByNumberOfAppartment(numOfAppartment);
        }
    }
}
