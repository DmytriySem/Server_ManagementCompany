using ServerDAL_ManagementCompany.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using DTOs_library;
using ServerDAL_ManagementCompany.Entities;
using ServerDAL_ManagementCompany.Entities.Equipment;
using ServerDAL_ManagementCompany.Entities.Territory;
using EASendMail;
using ServerDAL_ManagementCompany.Entities.ManagementCompany;

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
        /// <summary>
        /// NEWS
        /// </summary>
        /// <param name="image"></param>
        public void AddImageToNewsInDB(byte[] image)
        {
            CompanyData companyData = ctx.Companies.Where(x=>x.Id==1).Select(x=>x.CompanyData).Single();
            CompanyNews companyNews = new CompanyNews()
            {
                CompanyData = companyData,
                Date = DateTime.Now,
                Image = image
            };
            ctx.CompanyNews.Add(companyNews);
            ctx.SaveChanges();
        }

        /// <summary>
        //WORK WITH USERS
        /// </summary>
        /// <param name="numOfAppartment"></param>
        /// <returns></returns>
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

        /// <summary>
        /// SENDING MAILS
        /// </summary>
        /// <param name="userStatus"></param>
        /// <param name="message"></param>
        public void SendMailsToAllUsers(int userStatus, string message)
        {
            string senderEmail = "dmitriysemysiuk@gmail.com";//ctx.CompanyDatas.Select(x => x.Email).First();
            string senderPass = "lizilla15";// "helloworld18";

            SmtpServer server = new SmtpServer("smtp.gmail.com", 465);
            server.ConnectType = SmtpConnectType.ConnectSSLAuto;
            server.User = senderEmail;
            server.Password = senderPass;

            UserStatus tempStat = UserStatus.ADMIN;

            switch (userStatus)
            {
                case 1:
                    tempStat = UserStatus.USER;
                    break;
                case 2:
                    tempStat = UserStatus.DIRECTOR;
                    break;
                case 3:
                    tempStat = UserStatus.ACCOUNTANT;
                    break;
                case 4:
                    tempStat = UserStatus.JANITOR;
                    break;
            }

            List<string> emails = ctx.Users.Where(x => x.UserStatus == tempStat).Select(x => x.Email).ToList();
            foreach (var item in emails)
            {
                if (item == null)
                    continue;

                SmtpClient client = new SmtpClient();

                SmtpMail letter = new SmtpMail("TryIt")
                {
                    From = senderEmail,
                    To = item,
                    Subject = "---COMPANY---",
                    TextBody = message
                };

                try
                {
                    client.SendMail(server, letter);
                }
                catch (Exception ex)
                {

                }
            }
        }
        public void SendMailToUser(int numberOfAppartment, string message)
        {
            throw new NotImplementedException();
        }
        public void SendMailToWorker(string status, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// LIFT CONTROL
        /// </summary>
        /// <param name="idLift"></param>
        public void TurnOnOffLift(int idLift)
        {
            var liftStatus = ctx.Lifts.Where(x => x.Id == idLift).Single();

            liftStatus.EquipmentStatus =
                liftStatus.EquipmentStatus == EquipmentStatus.WORK ? EquipmentStatus.NOTWORK : EquipmentStatus.WORK;

            ctx.Entry(liftStatus).State = System.Data.Entity.EntityState.Modified;

            try
            {
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("cannot submit changes" + ex.InnerException.ToString());
            }
        }
        public List<bool> GetAllLiftsStates()
        {
            List<bool> allLiftsStates = ctx.Lifts.Select(x => x.EquipmentStatus == EquipmentStatus.WORK).ToList();

            return allLiftsStates;
        }

        /// <summary>
        /// LIGHT CONTROL
        /// </summary>
        /// <param name="idLight"></param>
        public void TurnOnOffLight(int idLight)
        {
            var lightStatus = ctx.Lights.Where(x => x.Id == idLight).Single();

            lightStatus.EquipmentStatus = lightStatus.EquipmentStatus == EquipmentStatus.NOTWORK ? EquipmentStatus.WORK : EquipmentStatus.NOTWORK;
            ctx.Entry(lightStatus).State = System.Data.Entity.EntityState.Modified;

            try
            {
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("cannot submit changes" + ex.InnerException.ToString());
            }
        }
        public List<bool> GetAllFloorsLightsStates()
        {
            List<bool> floorsLightsStates = (from c in ctx.Lights
                           join p in ctx.Floors
                           on c.Hallway equals p.Hallway
                           select(c.EquipmentStatus != EquipmentStatus.WORK)).ToList();

            return floorsLightsStates;
        }
        public List<bool> GetAllEntrancesLights()
        {

            var entrancesLights = ctx.Lights.Where(x => x.EntranceId != null).Select(x => x.EquipmentStatus == EquipmentStatus.WORK).ToList();
            
            return entrancesLights;
        }

        /// <summary>
        /// CLEAN CONTROL
        /// </summary>
        /// <param name="idEntrance"></param>
        public void CleanEntrance(int idEntrance)
        {
            var entranceCleanStatus = ctx.Entrances.Where(x => x.Id == idEntrance).Single();

            entranceCleanStatus.StatusOfCleaning =
                entranceCleanStatus.StatusOfCleaning == StatusOfCleaning.CLEAN ? StatusOfCleaning.DURT : StatusOfCleaning.CLEAN;
            ctx.Entry(entranceCleanStatus).State = System.Data.Entity.EntityState.Modified;

            ctx.SaveChanges();
        }

        public List<bool> GetAllCleaningStatusOfEntrances()
        {
            List<bool> allEntranceCleaningStates = ctx.Entrances.Select(x => x.StatusOfCleaning == StatusOfCleaning.CLEAN).ToList();

            return allEntranceCleaningStates;
        }
        #endregion
    }
}
