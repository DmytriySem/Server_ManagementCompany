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

        void SendMailToUser(int numberOfAppartment, string message);
        void SendMailsToAllUsers(int userStatus, string message);
        void SendMailToWorker(string status, string message);

        List<bool> GetAllFloorsLightsStates();
        List<bool> GetAllEntrancesLights();
        void TurnOnOffLight(int idLight);

        List<bool> GetAllLiftsStates();
        void TurnOnOffLift(int idLift);

        List<bool> GetAllCleaningStatusOfEntrances();
        void CleanEntrance(int idEntrance);

        void AddImageToNewsInDB(byte[] image);

    }
}
