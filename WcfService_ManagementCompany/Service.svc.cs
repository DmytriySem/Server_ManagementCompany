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
        private string connStr = String.Empty;
        private IValidateUser userValidate = null;
        private ICreateHouse createHouse = null;
        private ISaveUserCredentials saveUser = null;
        private IWorkMethods methodsWork = null;

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
                methodsWork = new WorkMethods(connStr);
            }
            catch(OutOfMemoryException ex)
            {
                throw new Exception("out of memory" + ex.InnerException.ToString());
            }
        }

        #region USER VALIDATE METHODS

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

        public void RecoverPassword(string email)
        {
            userValidate.recoverPassword(email);
        }

        #endregion

        #region CREATE COMPANY

        public void CreateHouse()
        {
            createHouse.BuildHouse();
        }

        #endregion

        #region WORKING METHODS

        public DTOUser GetUserByNumberOfAppartment(int numOfAppartment)
        {

            UserDTO userDTO =  methodsWork.GetUserByNumberOfAppartment(numOfAppartment);
            DTOUser dtoUser = new DTOUser()
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                BirthDate = userDTO.BirthDate,
                Email = userDTO.Email,
                Phone = userDTO.Phone
            };

            return dtoUser;
        }

        public void TurnOnOffLight(int idLight)
        {
            methodsWork.TurnOnOffLight(idLight);
        }

        public void TurnOnOffLift(int idLift)
        {
            methodsWork.TurnOnOffLift(idLift);
        }

        public List<bool> GetAllFloorsLightsStates()
        {
            return methodsWork.GetAllFloorsLightsStates();
        }

        public List<bool> GetAllLiftsStates()
        {
            return methodsWork.GetAllLiftsStates();
        }

        public void CleanEntrance(int idEntrance)
        {
            methodsWork.CleanEntrance(idEntrance);
        }

        public void SendMailsToAllUsers(int userStatus, string message)
        {
            methodsWork.SendMailsToAllUsers(userStatus, message);
        }

        public List<bool> GetAllEntrancesLights()
        {
            return methodsWork.GetAllEntrancesLights();
        }

        public List<bool> GetAllCleaningStatusOfEntrances()
        {
            return methodsWork.GetAllCleaningStatusOfEntrances();
        }

        public List<byte[]> GetAllNews()
        {
            return methodsWork.GetAllNews();
        }

        public void AddImageNewsToDB(byte[] image, int companyId)
        {
            methodsWork.AddImageNewsToDB(image, companyId);
        }

        #endregion
    }
}
