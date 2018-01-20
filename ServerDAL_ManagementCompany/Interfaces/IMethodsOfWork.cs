using DTOs_library;
using ServerDAL_ManagementCompany.Entities.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Interfaces
{
    public interface IMethodsOfWork
    {
        UserDTO GetUserByNumberOfAppartment(int numOfAppartment);
        UserDTO GetUserByNumberOfParkingPlace(int numOfParking);
        void SendMailToUser(int numberOfAppartment, string message);
        void SendMailsToAllUsers(int userStatus, string message);
        List<bool> GetAllFloorsLightsStates();
        List<bool> GetAllEntrancesLights();
        void TurnOnOffLight(int idLight);
        List<bool> GetAllLiftsStates();
        void TurnOnOffLift(int idLift);
        List<bool> GetAllCleaningStatusOfEntrances();
        void CleanEntrance(int idEntrance);
        void AddImageNewsToDB(byte[] image, int companyId);
        List<byte[]> GetAllNews();

        //--------------------------------------------------------
        void CleanPlayGround(int playGroundId);
        bool GetPlayGroundCleaningStatus(int playGroundId);
        List<bool> GetPlayGroundGarbagePlacesStatuses(int playGroundId);
        void CleanRestTerritory(int restTerritoryId);
        bool GetRestTerritoryCleaningStatus(int restTerritoryId);
        List<bool> GetRestTerritoryGarbagePlacesStatuses(int restTerritoryId);
        void CleanTerritory(int territoryId);
        bool GetTerritoryCleaningStatus(int territoryId);
        bool GetTerritoryGarbagePlaceStatus(int territoryId);

    }
}
