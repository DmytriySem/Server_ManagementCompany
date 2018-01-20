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
        List<bool> GetAllEntrancesLights();
        List<bool> GetAllFloorsLightsStates();
        void TurnOnOffLight(int idLight);
        List<bool> GetAllLiftsStates();
        void TurnOnOffLift(int idLift);
        List<bool> GetAllCleaningStatusOfEntrances();
        void CleanEntrance(int idEntrance);
        void SendMailsToAllUsers(int userStatus, string message);
        void AddImageNewsToDB(byte[] image, int companyId);
        List<byte[]> GetAllNews();
    }
}
