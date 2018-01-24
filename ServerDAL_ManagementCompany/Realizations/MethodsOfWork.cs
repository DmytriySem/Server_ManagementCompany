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
using ServerDAL_ManagementCompany.Entities.Room;

namespace ServerDAL_ManagementCompany.Realizations
{
    public class MethodsOfWork : IMethodsOfWork
    {
        private CompanyContext ctx = null;
        private string senderEmail = "dmitriysemysiuk17@gmail.com";//ctx.CompanyDatas.Select(x => x.Email).First();
        private string senderPass = "helloworld18";

        public MethodsOfWork(string connStr)
        {
            ctx = new CompanyContext(connStr);
        }

        #region ADMIN
        /// <summary>
        /// NEWS
        /// </summary>
        /// <param name="image"></param>
        public List<byte[]> GetAllNews()
        {
            List<byte[]> allNews = ctx.CompanyNews.Select(x => x.Image).ToList();

            return allNews;
        }

        public void AddImageNewsToDB(byte[] image, int companyId)
        {
            ctx.CompanyNews.Add(
                new CompanyNews()
                {
                    CompanyData = ctx.CompanyDatas.Where(x => x.Id == companyId).Select(x => x).Single(),
                    Date = DateTime.Now,
                    Image = image
                }
                );

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
        public void TurnOnOffHallwayLight(int idHallway)
        {
            var lightStatus = ctx.Lights.Where(x => x.HallwayId == idHallway).Single();

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
        public void TurnOnOffEntranceLight(int idEntrance)
        {
            var entranceLightStatus = ctx.Lights.Where(x => x.EntranceId == idEntrance).Single();

            entranceLightStatus.EquipmentStatus = entranceLightStatus.EquipmentStatus == EquipmentStatus.NOTWORK ? EquipmentStatus.WORK : EquipmentStatus.NOTWORK;
            ctx.Entry(entranceLightStatus).State = System.Data.Entity.EntityState.Modified;

            ctx.SaveChanges();
        }
        public List<bool> GetAllFloorsLightsStates()
        {
            List<bool> floorsLightsStates = (from c in ctx.Lights
                                             join p in ctx.Floors
                                             on c.Hallway equals p.Hallway
                                             select (c.EquipmentStatus != EquipmentStatus.WORK)).ToList();

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

        //-----------------------------------------------------------------

        public void CleanPlayGround(int playGroundId)
        {
            var cleanPlayGround = ctx.PlayGrounds.Where(x => x.Id == playGroundId).Single();
            cleanPlayGround.StatusOfCleaning =
                cleanPlayGround.StatusOfCleaning == StatusOfCleaning.CLEAN ? StatusOfCleaning.DURT : StatusOfCleaning.CLEAN;
            ctx.Entry(cleanPlayGround).State = System.Data.Entity.EntityState.Modified;

            ctx.SaveChanges();
        }
        public bool GetPlayGroundCleaningStatus(int playGroundId)
        {
            return ctx.PlayGrounds.Where(x => x.Id == playGroundId)
                .Select(x => x.StatusOfCleaning == StatusOfCleaning.CLEAN).Single();
        }
        public List<bool> GetPlayGroundGarbagePlacesStatuses(int playGroundId)
        {
            List<bool> playGroundGarbagePlaces = 
                ctx.GarbagePlaces.Where(x => x.PlayGroundId == playGroundId)
                .Select(x => x.StatusOfCleaning == StatusOfCleaning.CLEAN).ToList();

            return playGroundGarbagePlaces;
        }

        //-----------------------------------------------------------------

        public void CleanRestTerritory(int restTerritoryId)
        {
            var cleanRestTerritory = ctx.RestTerritories.Where(x => x.Id == restTerritoryId).Single();
            cleanRestTerritory.StatusOfCleaning =
                cleanRestTerritory.StatusOfCleaning == StatusOfCleaning.CLEAN ? StatusOfCleaning.DURT : StatusOfCleaning.CLEAN;
            ctx.Entry(cleanRestTerritory).State = System.Data.Entity.EntityState.Modified;

            ctx.SaveChanges();
        }
        public bool GetRestTerritoryCleaningStatus(int restTerritoryId)
        {
            return ctx.RestTerritories.Where(x => x.Id == restTerritoryId)
                .Select(x => x.StatusOfCleaning == StatusOfCleaning.CLEAN).Single();
        }
        public List<bool> GetRestTerritoryGarbagePlacesStatuses(int restTerritoryId)
        {
            List<bool> restTerritoryGarbagePlaces = 
                ctx.GarbagePlaces.Where(x => x.RestTerritoryId == restTerritoryId)
                .Select(x => x.StatusOfCleaning == StatusOfCleaning.CLEAN).ToList();

            return restTerritoryGarbagePlaces;
        }

        //--------------------------------------------------------------------------

        public void CleanTerritory(int territoryId)
        {
            var cleanTerritory = ctx.Territories.Where(x => x.Id == territoryId).Single();
            cleanTerritory.StatusOfCleaning =
                cleanTerritory.StatusOfCleaning == StatusOfCleaning.CLEAN ? StatusOfCleaning.DURT : StatusOfCleaning.CLEAN;
            ctx.Entry(cleanTerritory).State = System.Data.Entity.EntityState.Modified;

            ctx.SaveChanges();
        }
        public bool GetTerritoryCleaningStatus(int territoryId)
        {
            return ctx.Territories.Where(x => x.Id == territoryId)
                .Select(x => x.StatusOfCleaning == StatusOfCleaning.CLEAN).Single();
        }
        public bool GetTerritoryGarbagePlaceStatus(int territoryId)
        {
            return ctx.GarbagePlaces.Where(x => x.TerritoryId == territoryId)
                .Select(x => x.StatusOfCleaning == StatusOfCleaning.CLEAN).Single();
        }

        public UserDTO GetUserByNumberOfParkingPlace(int numOfParking)
        {
            User user = ctx.ParkingPlaces.Where(x => x.ParkingNumber == numOfParking).Select(x => x.User).First();
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

        //-------------------------------------------------------------------------------

        public bool GetParkingTerritoryCleaningStatus(int parkingTerritoryId)
        {
            return ctx.ParkingTerritories.Select(x => x.StatusOfCleaning == StatusOfCleaning.CLEAN).Single();
        }
        public void CleanParkingTerritory(int parkingTerritoryId)
        {
            var cleanParkingTerritory = ctx.ParkingTerritories.Where(x => x.Id == parkingTerritoryId).Single();
            cleanParkingTerritory.StatusOfCleaning =
                cleanParkingTerritory.StatusOfCleaning == StatusOfCleaning.CLEAN ? StatusOfCleaning.DURT : StatusOfCleaning.CLEAN;
            ctx.Entry(cleanParkingTerritory).State = System.Data.Entity.EntityState.Modified;

            ctx.SaveChanges();
        }
        public List<bool> GetParkingPlacesCleaningStatuses(int parkingTerritoryId)
        {
            return ctx.ParkingPlaces.Where(x => x.ParkingTerritoryId == parkingTerritoryId)
                .Select(x => x.StatusOfCleaning == StatusOfCleaning.CLEAN).ToList();
        }
        public void CleanParkingPlace(int parkingNumber)
        {
            var cleanParkingPlace = ctx.ParkingPlaces.Where(x => x.Id == parkingNumber).Single();
            cleanParkingPlace.StatusOfCleaning =
                cleanParkingPlace.StatusOfCleaning == StatusOfCleaning.CLEAN ? StatusOfCleaning.DURT : StatusOfCleaning.CLEAN;
            ctx.Entry(cleanParkingPlace).State = System.Data.Entity.EntityState.Modified;

            ctx.SaveChanges();
        }
        public List<bool> GetAllParkingTerritoryLightStates(int parkingTerritoryId)
        {
            return ctx.Lights.Where(x => x.ParkingTerritoryId == parkingTerritoryId)
                .Select(x => x.EquipmentStatus == EquipmentStatus.WORK).ToList();
        }
        public List<int> GetAllParkingPlacesStatusesOfPremises(int parkingTerritoryId)
        {
            List<int> allParkingPlacesStatusOfPremises =
                ctx.ParkingPlaces.Where(x => x.ParkingTerritoryId == parkingTerritoryId)
                .Select(x => (int)x.StatusOfPremises).ToList();

            return allParkingPlacesStatusOfPremises;
        }
        public void ChangeParkingPlaceStatusOfPremises(int parkingPlaceId, int statusOfPremises)
        {
            var changeParkingStatus = ctx.ParkingPlaces.Where(x => x.Id == parkingPlaceId).Single();
            changeParkingStatus.StatusOfPremises = (StatusOfPremises)statusOfPremises;
            ctx.Entry(changeParkingStatus).State = System.Data.Entity.EntityState.Modified;

            ctx.SaveChanges();
        }

        public void SendMailToUserByNumberOfAppartment(int numberOfAppartment, string message)
        {
            SmtpServer server = new SmtpServer("smtp.gmail.com", 465);
            server.ConnectType = SmtpConnectType.ConnectSSLAuto;
            server.User = senderEmail;
            server.Password = senderPass;

            string userEmail = (from c in ctx.Users
                               join p in ctx.Appartments
                               on c.Id equals p.UserId
                               select c.Email).Single();

            if (userEmail != null)
            {
                SmtpClient client = new SmtpClient();

                SmtpMail letter = new SmtpMail("TryIt")
                {
                    From = senderEmail,
                    To = userEmail,
                    Subject = "---COMPANY---",
                    TextBody = message
                };

                client.SendMail(server, letter);
            }

        }

        public void SendMailToUserByNumberOfParking(int numberOfParking, string message)
        {
            SmtpServer server = new SmtpServer("smtp.gmail.com", 465);
            server.ConnectType = SmtpConnectType.ConnectSSLAuto;
            server.User = senderEmail;
            server.Password = senderPass;

            string userEmail = (from c in ctx.Users
                                join p in ctx.ParkingPlaces
                                on c.Id equals p.UserId
                                select c.Email).Single();

            if (userEmail != null)
            {
                SmtpClient client = new SmtpClient();

                SmtpMail letter = new SmtpMail("TryIt")
                {
                    From = senderEmail,
                    To = userEmail,
                    Subject = "---COMPANY---",
                    TextBody = message
                };

                client.SendMail(server, letter);
            }
        }


        #endregion

        //#region 
    }
}
