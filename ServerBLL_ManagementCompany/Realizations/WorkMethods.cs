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

        public List<bool> GetAllLightsStates()
        {
            return workMethods.GetAllLightsStates();
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
    }
}
