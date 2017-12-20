using ServerBLL_ManagementCompany.Interfaces;
using ServerBLL_ManagementCompany.Realizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService_ManagementCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        private IValidateUser userValidate = new ValidateUser();
        private ICreateHouse createHouse = new CreateHouse();
        public string GetRandomStringFromServer(string login)
        {
            return userValidate?.GetRandomStringByLoginForCheckPass(login);
        }

        public bool? IsEmailValid(string email)
        {
            return userValidate?.IsEmailValid(email);
        }

        public bool? IsLoginValid(string login)
        {
            return userValidate?.IsLoginValid(login);
        }

        public int? GetUserIdIfPasswordValid(string hashPassChall)
        {
            return userValidate?.GetUserIdIfPasswordValid(hashPassChall);
        }

        public void CreateHouse()
        {
            createHouse.BuildHouse();
        }

        public void RecoverPassword(string email)
        {
            userValidate.recoverPassword(email);
        }
    }
}
