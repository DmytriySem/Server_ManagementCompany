using ServerDAL_ManagementCompany.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs_library;
using ServerDAL_ManagementCompany.Entities;

namespace ServerDAL_ManagementCompany.Realizations
{
    public class AdminMethods : IAdminMethods
    {
        private CompanyContext ctx = null;

        public AdminMethods(string connStr)
        {
            ctx = new CompanyContext(connStr);
        }

        public void AddImageToNewsInDB(byte[] image)
        {
            throw new NotImplementedException();
        }

        public void CleanEntrance(int id, bool state)
        {
            throw new NotImplementedException();
        }

        public List<bool> GetAllCleaningEntrance()
        {
            throw new NotImplementedException();
        }

        public List<bool> GetAllLiftsStates()
        {
            throw new NotImplementedException();
        }

        public List<bool> GetAllLightsStates()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserByNumberOfAppartment(int numOfAppartment)
        {
            User user = ctx.Appartments.Where(x => x.AppartmentNumber == numOfAppartment).Select(x => x.User).First();
            //User user = ctx.Users.Where(x => x.Id == userId).First();
            UserDTO userDTO = new UserDTO()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                Phone = user.Phone
            };

            return userDTO;
        }

        public void SendMailsToAllUsers(string userStatus, string message)
        {
            throw new NotImplementedException();
        }

        public void SendMailToUser(int numberOfAppartment, string message)
        {
            throw new NotImplementedException();
        }

        public void SendMailToWorker(string status, string message)
        {
            throw new NotImplementedException();
        }

        public void TurnOnOffLift(int id, bool state)
        {
            throw new NotImplementedException();
        }

        public void TurnOnOffLight(int id, bool workState)
        {
            throw new NotImplementedException();
        }
    }
}
