using ServerDAL_ManagementCompany.Entities;
using ServerDAL_ManagementCompany.Entities.ManagementCompany;
using ServerDAL_ManagementCompany.Entities.ManagementCompany.House;
using ServerDAL_ManagementCompany.Entities.Room;
using ServerDAL_ManagementCompany.Entities.Territory;
using ServerDAL_ManagementCompany.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Realizations
{
    public class BuildHouse : IBuildHouse
    {
        private CompanyContext ctx = new CompanyContext();

        private Company company = null;
        private CompanyData companyData = null;
        private House house = null;

        private Hallway hallway = null;
        private Appartment appartment = null;
        private Floor floor = null;
        private Entrance entrance = null;
        private User user = null;

        void IBuildHouse.BuildHouse()
        {
            byte[] passByte = Encoding.ASCII.GetBytes(HashMethods.HashMethods.GetHashString("qwer"));
            user = new User() { Login = "admin", Password = passByte, BirthDate = DateTime.Now, Email = "dmitriysemysiuk@gmail.com" };
            ctx.Users.Add(user);

            ///--------------------------------------HOUSE--------------------------------------
            for (int i = 0, k = 1; i < 3; i++)
            {
                entrance = new Entrance()
                {
                    Area = 50.00,
                    EntranceNumber = i + 1,
                    StatusOfCleaning = StatusOfCleaning.DURT,
                    Name = "ENTRANCE",
                    Cameras = null,
                    Lifts = null,
                    Intercom = null,
                    Lights = null
                };

                for (int l = 0, j = 1; l < 5; l++)
                {
                    hallway = new Hallway();
                    hallway.StatusOfCleaning = StatusOfCleaning.DURT;
                    hallway.Area = 10.45;
                    ctx.Hallways.Add(hallway);

                    appartment = new Appartment()
                    {
                        AppartmentNumber = k++,
                        Area = 70.50,
                        StatusOfPremises = StatusOfPremises.FREE,
                        NumberOfResidents = 0,
                        User = null,
                        Name = "APPARTMENT"
                    };
                    ctx.Appartments.Add(appartment);

                    floor = new Floor();
                    floor.NumberOfFloor = l + 1;
                    floor.Hallway = hallway;
                    floor.Appartments.Add(appartment);
                    entrance.Floors.Add(floor);

                    appartment = new Appartment()
                    {
                        AppartmentNumber = k++,
                        Area = 87.50,
                        StatusOfPremises = StatusOfPremises.FREE,
                        NumberOfResidents = 0,
                        User = null,
                        Name = "APPARTMENT"
                    };
                    ctx.Appartments.Add(appartment);
                    floor.Appartments.Add(appartment);

                    ctx.Floors.Add(floor);
                }

                ctx.Entrances.Add(entrance);
            }

            house = new House();
            house.Entrances.Add(entrance);
            ctx.Houses.Add(house);

            company = new Company();
            company.Houses.Add(house);
            ctx.Companies.Add(company);

            companyData = new CompanyData() { Email = "osbbcompany@gmail.com", Name = "CITY" };
            company.CompanyData = companyData;
            ctx.Companies.Add(company);

            ctx.SaveChanges();
        }
    }
}
