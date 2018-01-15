using DTOs_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Interfaces
{
    public interface IAdminMethods
    {
        UserDTO GetUserByNumberOfAppartment(int numOfAppartment);

        void SendMailToUser(int numberOfAppartment, string message);
        void SendMailsToAllUsers(string userStatus, string message);
        void SendMailToWorker(string status, string message);

        List<bool> GetAllLightsStates();
        void TurnOnOffLight(int id, bool workState);

        List<bool> GetAllLiftsStates();
        void TurnOnOffLift(int id, bool state);

        List<bool> GetAllCleaningEntrance();
        void CleanEntrance(int id, bool state);

        void AddImageToNewsInDB(byte[] image);

    }
}
