using DTOs_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBLL_ManagementCompany.Interfaces
{
    public interface IWorkMethods
    {
        
        UserDTO GetUserByNumberOfAppartment(int numOfAppartment);
        UserDTO GetUserByNumberOfParkingPlace(int numOfParking);
        List<bool> GetAllEntrancesLights();
        List<bool> GetAllFloorsLightsStates();
        void TurnOnOffHallwayLight(int idHallway);
        void TurnOnOffEntranceLight(int idEntrance);
        List<bool> GetAllLiftsStates();
        void TurnOnOffLift(int idLift);
        List<bool> GetAllCleaningStatusOfEntrances();
        void CleanEntrance(int idEntrance);
        void SendMailsToAllUsers(int userStatus, string message);
        void SendMailToUserByNumberOfAppartment(int numberOfAppartment, string message);
        void SendMailToUserByNumberOfParking(int numberOfParking, string message);
        void AddImageNewsToDB(byte[] image, int companyId);
        List<byte[]> GetAllNews();

        //-----------------------------------
        void CleanPlayGround(int playGroundId);
        bool GetPlayGroundCleaningStatus(int playGroundId);
        List<bool> GetPlayGroundGarbagePlacesStatuses(int playGroundId);

        void CleanRestTerritory(int restTerritoryId);
        bool GetRestTerritoryCleaningStatus(int restTerritoryId);
        List<bool> GetRestTerritoryGarbagePlacesStatuses(int restTerritoryId);

        void CleanTerritory(int territoryId);
        bool GetTerritoryCleaningStatus(int territoryId);
        bool GetTerritoryGarbagePlaceStatus(int territoryId);

        //----------------------------------------------------------------------

        bool GetParkingTerritoryCleaningStatus(int parkingTerritoryId);
        void CleanParkingTerritory(int parkingTerritoryId);
        List<bool> GetParkingPlacesCleaningStatuses(int parkingTerritoryId);
        void CleanParkingPlace(int parkingNumber);
        List<bool> GetAllParkingTerritoryLightStates(int parkingTerritoryId);
        //void TurnOnOffParkingTerritoryLight(int ??????);
        List<int> GetAllParkingPlacesStatusesOfPremises(int parkingTerritoryId);
        void ChangeParkingPlaceStatusOfPremises(int parkingPlaceId, int statusOfPremises);
    }
}
