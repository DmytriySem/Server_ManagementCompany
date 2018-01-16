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
        List<bool> GetAllLightsStates();
        void TurnOnOffLight(int idLight);
        List<bool> GetAllLiftsStates();
        void TurnOnOffLift(int idLift);
        void CleanEntrance(int idEntrance);
    }
}
