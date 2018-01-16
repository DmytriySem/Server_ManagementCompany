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

            switch (userStatus) ///дописать!!!!!!!!!!!!!!!!!!!!!!!!!!!
            {
                case 0:

                    break;
                case 1:
                    tempStat = UserStatus.USER;
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
            List<bool> allLiftsStates = (ctx.Lifts.Select(x => x.EquipmentStatus).ToList()).Select(x=>Convert.ToBoolean(x)).ToList();

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
        public List<bool> GetAllFloorsLightsStates() //get all floors states
        {
            //var selectedUsers = users.SelectMany(u => u.Languages,
            //                (u, l) => new { User = u, Lang = l })
            //              .Where(u => u.Lang == "английский" && u.User.Age < 28)
            //              .Select(u => u.User);


            //!!!!!!!!!!!!!!!!!var res = ctx.Lights.Select(x => x).Re // Select(x=>x. )


            List<bool> allLightsStates = ((ctx.Floors.Select(z => z.Hallway).ToList())
                .Select(x => x.Lights).ToList()).Select(x => Convert.ToBoolean(x)).ToList();


            //Select(x => x.Lights).Where(x => Convert.ToBoolean(x)).ToList();

            return allLightsStates;
        }
        public List<bool> GetAllEntrancesLights() //get all floors states
        {
            var sdf = ctx.Entrances.Select(x => x.Lights).ToList();
            

            List<EquipmentStatus> allLightsStates = ctx.Lights.Select(x => x.EquipmentStatus).ToList();
            List<bool> res = allLightsStates.Select(x => Convert.ToBoolean(x)).ToList();
            return res;
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
            List<bool> allEntranceCleaningStates = (ctx.Entrances.Select(x => x.StatusOfCleaning).ToList()).Select(x => Convert.ToBoolean(x)).ToList();

            return allEntranceCleaningStates;
        }
        #endregion
    }
}
