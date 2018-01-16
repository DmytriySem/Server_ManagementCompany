﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService_ManagementCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        #region USER VALIDATE METHODS
        [OperationContract]
        bool IsLoginValid(string login);

        [OperationContract]
        int GetUserIdIfPasswordValid(string hashPassChall);

        [OperationContract]
        bool IsEmailValid(string email);

        [OperationContract]
        string GetRandomStringFromServer(string login);

        [OperationContract]
        void RecoverPassword(string email);

        #endregion

        #region CREATE COMPANY

        [OperationContract]
        void CreateHouse();

        #endregion

        #region WORKING METHODS

        [OperationContract]
        DTOUser GetUserByNumberOfAppartment(int numOfAppartment);

        [OperationContract]
        void TurnOnOffLight(int idLight);

        [OperationContract]
        void TurnOnOffLift(int idLift);

        [OperationContract]
        List<bool> GetAllFloorsLightsStates();

        [OperationContract]
        List<bool> GetAllEntrancesLights();

        [OperationContract]
        List<bool> GetAllLiftsStates();

        [OperationContract]
        void CleanEntrance(int idEntrance);

        [OperationContract]
        void SendMailsToAllUsers(int userStatus, string message);

        #endregion
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class DTOUser
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public byte[] Password { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
        [DataMember]
        public int UserStatus { get; set; }
    }
}
