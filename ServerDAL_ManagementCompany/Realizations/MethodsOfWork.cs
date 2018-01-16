using ServerDAL_ManagementCompany.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs_library;
using ServerDAL_ManagementCompany.Entities;
using ServerDAL_ManagementCompany.Entities.Equipment;
using ServerDAL_ManagementCompany.Entities.Territory;

namespace ServerDAL_ManagementCompany.Realizations
{
    public class MethodsOfWork : IMethodsOfWork
    {
        private CompanyContext ctx = null;

        public MethodsOfWork(string connStr)
        {
            ctx = new CompanyContext(connStr);
        }

        #region ADMIN

        public void AddImageToNewsInDB(byte[] image)
        {
            throw new NotImplementedException();
        }

        public void CleanEntrance(int idEntrance)
        {
            var entranceCleanStatus = ctx.Entrances.Where(x => x.Id == idEntrance).Single();

            if (entranceCleanStatus.StatusOfCleaning == StatusOfCleaning.CLEAN)
            {
                entranceCleanStatus.StatusOfCleaning = StatusOfCleaning.DURT;
                ctx.Entry(entranceCleanStatus).State = System.Data.Entity.EntityState.Modified;
            }

            ctx.SaveChanges();

            
        }

        public List<bool> GetAllCleaningStatusOfEntrances()
        {
            var allEntranceCleaningStates = ((from entrance in ctx.Entrances
                                              select entrance.StatusOfCleaning).ToList()).Select(x => Convert.ToBoolean(x)).ToList();//new Boolean(){ Convert.ToBoolean(entrance.StatusOfCleaning) })).ToList();
            //ctx.Entrances.Select(x => new Boolean() { Convert.ToBoolean(x.StatusOfCleaning)})

            //List<bool> resultList = new List<bool>();
            //foreach (var item in allEntranceCleaningStates)
            //{
            //    resultList.Add(Convert.ToBoolean(item));
            //}
            //анонимный тип через select
            return allEntranceCleaningStates;
        }



        public UserDTO GetUserByNumberOfAppartment(int numOfAppartment)
        {
            User user = ctx.Appartments.Where(x => x.AppartmentNumber == numOfAppartment).Select(x => x.User).First();
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


        public List<bool> GetAllLiftsStates()
        {
            //var allLiftsStates = (from lift in ctx.Lifts
            //                      select lift.EquipmentStatus).ToList();

            List<bool> allLiftsStates = (ctx.Entrances.Select(x => x.StatusOfCleaning).ToList()).Select(x => Convert.ToBoolean(x)).ToList();

            //List<bool> resultList = new List<bool>();
            //foreach (var item in allLiftsStates)
            //{
            //    resultList.Add(Convert.ToBoolean(item));
            //}

            return allLiftsStates;
        }

        public void TurnOnOffLift(int idLift)
        {
            var query = from lift in ctx.Lifts
                        where lift.Id == idLift
                        select lift;

            foreach (var item in query)
            {
                item.EquipmentStatus = item.EquipmentStatus == EquipmentStatus.NOTWORK ? EquipmentStatus.WORK : EquipmentStatus.NOTWORK;
            }

            try
            {
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("cannot submit changes" + ex.InnerException.ToString());
            }
        }

        public List<bool> GetAllLightsStates()
        {
            var allLightsStates = (from light in ctx.Lights
                        select light.EquipmentStatus).ToList();

            List<bool> resultList = new List<bool>();
            foreach (var item in allLightsStates)
            {
                resultList.Add(Convert.ToBoolean(item));
            }

            return resultList;
        }

        public void TurnOnOffLight(int idLight)
        {
            var query = from light in ctx.Lights
                        where light.Id == idLight
                        select light;

            foreach (var item in query)
            {
                item.EquipmentStatus = item.EquipmentStatus == EquipmentStatus.NOTWORK ? EquipmentStatus.WORK : EquipmentStatus.NOTWORK;
            }

            try
            {
                ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("cannot submit changes" + ex.InnerException.ToString());
            }
        }

        #endregion
    }
}
