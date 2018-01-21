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
        public void TurnOnOffHallwayLight(int idHallway)
        {
            methodsWork.TurnOnOffHallwayLight(idHallway);
        }
        public void TurnOnOffLift(int idLift)
        {
            methodsWork.TurnOnOffLift(idLift);
        }
        public void TurnOnOffEntranceLight(int idEntrance)
        {
            methodsWork.TurnOnOffEntranceLight(idEntrance);
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

        //-------------------------------------------------------------------

        public void CleanPlayGround(int playGroundId)
        {
            methodsWork.CleanPlayGround(playGroundId);
        }
        public bool GetPlayGroundCleaningStatus(int playGroundId)
        {
            return methodsWork.GetPlayGroundCleaningStatus(playGroundId);
        }
        public List<bool> GetPlayGroundGarbagePlacesStatuses(int playGroundId)
        {
            return methodsWork.GetPlayGroundGarbagePlacesStatuses(playGroundId);
        }

        //------------------------------------------------------------------

        public void CleanRestTerritory(int restTerritoryId)
        {
            methodsWork.CleanRestTerritory(restTerritoryId);
        }
        public bool GetRestTerritoryCleaningStatus(int restTerritoryId)
        {
            return methodsWork.GetRestTerritoryCleaningStatus(restTerritoryId);
        }
        public List<bool> GetRestTerritoryGarbagePlacesStatuses(int restTerritoryId)
        {
            return methodsWork.GetRestTerritoryGarbagePlacesStatuses(restTerritoryId);
        }

        //---------------------------------------------------------------------------

        public void CleanTerritory(int territoryId)
        {
            methodsWork.CleanTerritory(territoryId);
        }
        public bool GetTerritoryCleaningStatus(int territoryId)
        {
            return methodsWork.GetTerritoryCleaningStatus(territoryId);
        }
        public bool GetTerritoryGarbagePlaceStatus(int territoryId)
        {
            return methodsWork.GetTerritoryGarbagePlaceStatus(territoryId);
        }
        public DTOUser GetUserByNumberOfParkingPlace(int numOfParking)
        {
            UserDTO userDTO = methodsWork.GetUserByNumberOfParkingPlace(numOfParking);
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

        //----------------------------------------------------------------

        public bool GetParkingTerritoryCleaningStatus(int parkingTerritoryId)
        {
            return methodsWork.GetParkingTerritoryCleaningStatus(parkingTerritoryId);
        }
        public void CleanParkingTerritory(int parkingTerritoryId)
        {
            methodsWork.CleanParkingTerritory(parkingTerritoryId);
        }
        public List<bool> GetParkingPlacesCleaningStatuses(int parkingTerritoryId)
        {
            return methodsWork.GetParkingPlacesCleaningStatuses(parkingTerritoryId);
        }
        public void CleanParkingPlace(int parkingNumber)
        {
            methodsWork.CleanParkingPlace(parkingNumber);
        }
        public List<bool> GetAllParkingTerritoryLightStates(int parkingTerritoryId)
        {
            return methodsWork.GetAllParkingTerritoryLightStates(parkingTerritoryId);
        }
        public List<int> GetAllParkingPlacesStatusesOfPremises(int parkingTerritoryId)
        {
            return methodsWork.GetAllParkingPlacesStatusesOfPremises(parkingTerritoryId);
        }
        public void ChangeParkingPlaceStatusOfPremises(int parkingPlaceId, int statusOfPremises)
        {
            methodsWork.ChangeParkingPlaceStatusOfPremises(parkingPlaceId, statusOfPremises);
        }

        //---------------------------------------------------------------------------



        #endregion
    }
}
