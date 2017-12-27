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
        private CompanyContext ctx = null;

        public BuildHouse(string connStr)
        {
            ctx = new CompanyContext(connStr);
        }

        private Company company = null;
        private CompanyData companyData = null;

        private User user = null;

        private House house = null;

        private Entrance entrance = null;
        private const int numberOfEntrances = 3;
        private Floor floor = null;
        private const int numberOfFloorsInEntrance = 5;
        private Hallway hallway = null;
        private Appartment appartment = null;
        private const int numberOfAppartmentsOnTheFloor = 2;

        private Cellar cellar = null;
        private const int numberOfCellars = 3;
        private Basement basement = null;
        private const int numberOfBasementsInCellar = 7;

        private Territory territory = null;
        private GarbagePlace garbagePlace = null;
        private const int numberOfGarbagePlaces = 6;
        private RestTerritory restTerritory = null;
        private ParkingPlace parkingPlace = null;
        private const int numberOfParkingPlaces = 24;
        private PlayGround playGround = null;

        void IBuildHouse.BuildHouse()
        {
            house = new House();

            for (int i = 0, k = 1; i < numberOfEntrances; i++)
            {
                entrance = new Entrance()
                {
                    Area = 50.00,
                    EntranceNumber = i + 1,
                    StatusOfCleaning = StatusOfCleaning.DURT,
                    Cameras = null,
                    Lifts = null,
                    Intercom = null,
                    Lights = null
                };

                for (int j = 0; j < numberOfFloorsInEntrance; j++)
                {
                    hallway = new Hallway() { Area = 10.45, StatusOfCleaning = StatusOfCleaning.DURT };
                    ctx.Hallways.Add(hallway);

                    appartment = new Appartment()
                    {
                        AppartmentNumber = k++,
                        Area = 70.50,
                        StatusOfPremises = StatusOfPremises.FREE,
                        NumberOfResidents = 0,
                        User = null
                    };
                    ctx.Appartments.Add(appartment);

                    floor = new Floor();
                    floor.NumberOfFloor = j + 1;
                    floor.Hallway = hallway;
                    floor.Appartments.Add(appartment);
                    entrance.Floors.Add(floor);

                    appartment = new Appartment()
                    {
                        AppartmentNumber = k++,
                        Area = 87.50,
                        StatusOfPremises = StatusOfPremises.FREE,
                        NumberOfResidents = 0,
                        User = null
                    };
                    ctx.Appartments.Add(appartment);
                    floor.Appartments.Add(appartment);

                    ctx.Floors.Add(floor);
                }

                ctx.Entrances.Add(entrance);
                house.Entrances.Add(entrance);
            }

            for (int i = 0, k = 1; i < numberOfCellars; i++)
            {
                hallway = new Hallway() { Area = 18.60, StatusOfCleaning = StatusOfCleaning.DURT };
                ctx.Hallways.Add(hallway);

                cellar = new Cellar() { CellarNumber = i + 1, Hallway = hallway };

                for (int j = 0; j < numberOfBasementsInCellar; j++)
                {
                    basement = new Basement()
                    {
                        Area = 20.00,
                        BasementNumber = k++,
                        StatusOfPremises = StatusOfPremises.FREE,
                        User = null
                    };
                    ctx.Basements.Add(basement);
                    cellar.Basements.Add(basement);
                }
                ctx.Cellars.Add(cellar);

                house.Cellars.Add(cellar);
            }            

            territory = new Territory();

            for (int i = 0; i < numberOfGarbagePlaces; i++)
            {
                garbagePlace = new GarbagePlace()
                {
                    Area = 5.00,
                    GarbageNumber = i + 1,
                    StatusOfCleaning = StatusOfCleaning.DURT
                };
                ctx.GarbagePlaces.Add(garbagePlace);
                territory.GarbagePlaces.Add(garbagePlace);
            }

            for (int i = 0; i < numberOfParkingPlaces; i++)
            {
                parkingPlace = new ParkingPlace()
                {
                    Area = 15.00,
                    ParkingNumber = i + 1,
                    StatusOfCleaning = StatusOfCleaning.DURT,
                    StatusOfPremises = StatusOfPremises.FREE,
                    User = null
                };
                ctx.ParkingPlaces.Add(parkingPlace);
                territory.ParkingPlaces.Add(parkingPlace);
            }

            playGround = new PlayGround()
            {
                Area = 30.00,
                Cameras = null,
                Lights = null,
                StatusOfCleaning = StatusOfCleaning.DURT
            };
            ctx.PlayGrounds.Add(playGround);
            territory.PlayGround = playGround;

            restTerritory = new RestTerritory()
            {
                Area = 200.00,
                Cameras = null,
                Lights = null,
                StatusOfCleaning = StatusOfCleaning.DURT
            };
            ctx.RestTerritories.Add(restTerritory);
            territory.RestTerritory = restTerritory;


            companyData = new CompanyData()
            {
                Name = "Managemrnt Company Ltd",
                Email = "osbbcompany@gmail.com",
                Phones = new List<string>() { "063-12-12-665", "093-56-89-895" }
            };

            company = new Company() { CompanyData = companyData };
            company.Houses.Add(house);
            company.Territories.Add(territory);
            ctx.Companies.Add(company);

            byte[] passByte = Encoding.ASCII.GetBytes(HashMethods.HashMethods.GetHashString("qwer"));
            user = new User()
            {
                Login = "admin",
                Password = passByte,
                BirthDate = DateTime.Now,
                Email = "dmitriysemysiuk@gmail.com",
                UserStatus = UserStatus.ADMIN
            };
            ctx.Users.Add(user);
            company.Users.Add(user);

            passByte = Encoding.ASCII.GetBytes(HashMethods.HashMethods.GetHashString("qwer"));
            user = new User()
            {
                Login = "user1",
                Password = passByte,
                BirthDate = DateTime.Now,
                Email = "dmitriysemysiuk17@gmail.com",
                UserStatus = UserStatus.USER
            };
            ctx.Users.Add(user);
            company.Users.Add(user);

            passByte = Encoding.ASCII.GetBytes(HashMethods.HashMethods.GetHashString("qwer"));
            user = new User()
            {
                Login = "user2",
                Password = passByte,
                BirthDate = DateTime.Now,
                //Email = "dmitriysemysiuk@gmail.com",
                UserStatus = UserStatus.USER
            };
            ctx.Users.Add(user);
            company.Users.Add(user);

            passByte = Encoding.ASCII.GetBytes(HashMethods.HashMethods.GetHashString("asdf"));
            user = new User()
            {
                Login = "user3",
                Password = passByte,
                BirthDate = DateTime.Now,
                //Email = "dmitriysemysiuk@gmail.com",
                UserStatus = UserStatus.USER
            };
            ctx.Users.Add(user);
            company.Users.Add(user);

            passByte = Encoding.ASCII.GetBytes(HashMethods.HashMethods.GetHashString("qwer"));
            user = new User()
            {
                Login = "jan",
                Password = passByte,
                BirthDate = DateTime.Now,
                //Email = "dmitriysemysiuk@gmail.com",
                UserStatus = UserStatus.JANITOR
            };
            ctx.Users.Add(user);
            company.Users.Add(user);

            ctx.SaveChanges();
        }
    }
}