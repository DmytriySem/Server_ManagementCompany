using ServerBLL_ManagementCompany.Interfaces;
using ServerDAL_ManagementCompany.Interfaces;
using ServerDAL_ManagementCompany.Realizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs_library;

namespace ServerBLL_ManagementCompany.Realizations
{
    public class WorkMethods : IWorkMethods
    {
        private IMethodsOfWork workMethods = null;
        public WorkMethods(string connStr)
        {
            workMethods = new MethodsOfWork(connStr);
        }

        public void CleanEntrance(int idEntrance)
        {
            workMethods.CleanEntrance(idEntrance);
        }

        public List<bool> GetAllLiftsStates()
        {
            return workMethods.GetAllLiftsStates();
        }

        public List<bool> GetAllFloorsLightsStates()
        {
            return workMethods.GetAllFloorsLightsStates();
        }

        public UserDTO GetUserByNumberOfAppartment(int numOfAppartment)
        {
            
            return workMethods.GetUserByNumberOfAppartment(numOfAppartment);
        }

        public void TurnOnOffLift(int idLift)
        {
            workMethods.TurnOnOffLift(idLift);
        }

        public void TurnOnOffLight(int idLight)
        {
            workMethods.TurnOnOffLight(idLight);
        }

        public void SendMailsToAllUsers(int userStatus, string message)
        {
            workMethods.SendMailsToAllUsers(userStatus, message);
        }

        public List<bool> GetAllEntrancesLights()
        {
            return workMethods.GetAllEntrancesLights();
        }

        public List<bool> GetAllCleaningStatusOfEntrances()
        {
            return workMethods.GetAllCleaningStatusOfEntrances();
        }

        public List<byte[]> GetAllNews()
        {
            return workMethods.GetAllNews();
        }

        public void AddImageNewsToDB(byte[] image, int companyId)
        {
            workMethods.AddImageNewsToDB(image, companyId);
        }

        //------------------------------------------------------------

        public void CleanPlayGround(int playGroundId)
        {
            workMethods.CleanPlayGround(playGroundId);
        }

        public bool GetPlayGroundCleaningStatus(int playGroundId)
        {
            return workMethods.GetPlayGroundCleaningStatus(playGroundId);
        }

        public List<bool> GetPlayGroundGarbagePlacesStatuses(int playGroundId)
        {
            return workMethods.GetPlayGroundGarbagePlacesStatuses(playGroundId);
        }

        //------------------------------------------------------------

        public void CleanRestTerritory(int restTerritoryId)
        {
            workMethods.CleanRestTerritory(restTerritoryId);
        }

        public bool GetRestTerritoryCleaningStatus(int restTerritoryId)
        {
            return workMethods.GetRestTerritoryCleaningStatus(restTerritoryId);
        }

        public List<bool> GetRestTerritoryGarbagePlacesStatuses(int restTerritoryId)
        {
            return workMethods.GetRestTerritoryGarbagePlacesStatuses(restTerritoryId);
        }

        public void CleanTerritory(int territoryId)
        {
            workMethods.CleanTerritory(territoryId);
        }

        public bool GetTerritoryCleaningStatus(int territoryId)
        {
            return workMethods.GetTerritoryCleaningStatus(territoryId);
        }

        public bool GetTerritoryGarbagePlaceStatus(int territoryId)
        {
            return workMethods.GetTerritoryGarbagePlaceStatus(territoryId);
        }

        public UserDTO GetUserByNumberOfParkingPlace(int numOfParking)
        {
            return workMethods.GetUserByNumberOfParkingPlace(numOfParking);
        }
    }
}
