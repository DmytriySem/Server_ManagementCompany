using ServerDAL_ManagementCompany.Entities;
using ServerDAL_ManagementCompany.Entities.Equipment;
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
        private ParkingTerritory parkingTerritory = null;
        private const int numberOfParkingPlaces = 24;
        private PlayGround playGround = null;
        private AdjoiningTerritory adjoiningTerritory = null;

        //private Camera camera = null;

        void IBuildHouse.BuildHouse()
        {
            house = new House();

            for (int i = 0, k = 1; i < numberOfEntrances; i++)
            {
                Camera camera = new Camera() { IpAdress = "0.0.0.0", Login = "empty", Password = "none", Resolution = 2.0, EquipmentStatus = EquipmentStatus.NOTWORK };
                Lift lift = new Lift() { CarryingCapacity = 200, EquipmentStatus = EquipmentStatus.WORK };
                Intercom intercom = new Intercom() { EquipmentStatus = EquipmentStatus.WORK };
                Light light = new Light() { Power = 100, EquipmentStatus = EquipmentStatus.WORK };

                entrance = new Entrance()
                {
                    Area = 50.00,
                    EntranceNumber = i + 1,
                    StatusOfCleaning = StatusOfCleaning.DURT,
                    Cameras = new List<Camera>() { camera },
                    Lifts = new List<Lift>() { lift },
                    Intercom = intercom,
                    Lights = new List<Light>() { light }
                };

                for (int j = 0; j < numberOfFloorsInEntrance; j++)
                {
                    hallway = new Hallway() { Area = 10.45, StatusOfCleaning = StatusOfCleaning.DURT };
                    hallway.Lights.Add(new Light() { Power = 40, EquipmentStatus = EquipmentStatus.WORK });
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


            ///---------------------------------------------------------------------------------------------
            ///Cellar///
            ///---------------------------------------------------------------------------------------------
            for (int i = 0, k = 1; i < numberOfCellars; i++)
            {
                hallway = new Hallway()
                {
                    Area = 18.60,
                    StatusOfCleaning = StatusOfCleaning.DURT,
                    Lights = new List<Light>()
                    {
                        new Light() {Power = 50, EquipmentStatus = EquipmentStatus.WORK }
                    },
                    Cameras = new List<Camera>()
                    {
                        new Camera()
                        {
                            IpAdress = "0.0.0.0",
                            Login = "empty",
                            Password = "none",
                            Resolution = 2.0,
                            EquipmentStatus = EquipmentStatus.NOTWORK
                        }
                    }
                };
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



            ///---------------------------------------------------------------------------------------------
            ///Parking Territory///
            ///---------------------------------------------------------------------------------------------
            parkingTerritory = new ParkingTerritory() { Area = 360, StatusOfCleaning = StatusOfCleaning.DURT };

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
                parkingTerritory.ParkingPlaces.Add(parkingPlace);
            }

            for (int i = 0; i < numberOfGarbagePlaces; i++)
            {
                garbagePlace = new GarbagePlace()
                {
                    Area = 5.00,
                    GarbageNumber = i + 1,
                    StatusOfCleaning = StatusOfCleaning.DURT
                };
                ctx.GarbagePlaces.Add(garbagePlace);
                parkingTerritory.GarbagePlaces.Add(garbagePlace);
            }

            for (int i = 0; i < 2; i++)
            {
                Camera camera = new Camera()
                {
                    IpAdress = "0.0.0.0",
                    Login = "empty",
                    Password = "none",
                    Resolution = 2.0,
                    EquipmentStatus = EquipmentStatus.NOTWORK
                };
                ctx.Cameras.Add(camera);
                parkingTerritory.Cameras.Add(camera);
            }

            for (int i = 0; i < 2; i++)
            {
                Light light = new Light() { Power = 150, EquipmentStatus = EquipmentStatus.WORK };
                ctx.Lights.Add(light);
                parkingTerritory.Lights.Add(light);
            }

            ///---------------------------------------------------------------------------------------------
            ///Play Ground///
            ///---------------------------------------------------------------------------------------------
            playGround = new PlayGround()
            {
                Area = 200,
                StatusOfCleaning = StatusOfCleaning.DURT,
                Cameras = new List<Camera>
                {
                    new Camera()
                    {
                        IpAdress = "0.0.0.0",
                        Login = "empty",
                        Password = "none",
                        Resolution = 2.0,
                        EquipmentStatus = EquipmentStatus.NOTWORK
                    }
                },
                Lights = new List<Light>
                {
                    new Light() { Power = 100, EquipmentStatus = EquipmentStatus.NOTWORK }
                }
            };
            ctx.PlayGrounds.Add(playGround);

            ///---------------------------------------------------------------------------------------------
            ///Rest Territory///
            ///---------------------------------------------------------------------------------------------
            restTerritory = new RestTerritory()
            {
                Area = 350,
                StatusOfCleaning = StatusOfCleaning.DURT,
                Cameras = new List<Camera>()
                {
                    new Camera()
                    {
                        IpAdress = "0.0.0.0",
                        Login = "empty",
                        Password = "none",
                        Resolution = 2.0,
                        EquipmentStatus = EquipmentStatus.NOTWORK
                    }
                },
                Lights = new List<Light>()
                {
                    new Light() { Power = 100, EquipmentStatus = EquipmentStatus.NOTWORK }
                }
            };
            ctx.RestTerritories.Add(restTerritory);

            ///---------------------------------------------------------------------------------------------
            ///Adjoining Territory///
            ///---------------------------------------------------------------------------------------------
            adjoiningTerritory = new AdjoiningTerritory()
            {
                Area = 800,
                StatusOfCleaning = StatusOfCleaning.DURT,
                PlayGround = playGround,
                RestTerritory = restTerritory
            };
            ctx.AdjoiningTerritory.Add(adjoiningTerritory);


            ///---------------------------------------------------------------------------------------------
            ///Territory///
            ///---------------------------------------------------------------------------------------------
            territory = new Territory()
            {
                Area = 1350,
                ParkingTerritory = parkingTerritory,
                AdjoiningTerritory = adjoiningTerritory,
                StatusOfCleaning = StatusOfCleaning.DURT
            };
            ctx.Territories.Add(territory);



            ///---------------------------------------------------------------------------------------------
            ///Company Data///
            ///---------------------------------------------------------------------------------------------
            companyData = new CompanyData()
            {
                Name = "Managemrnt Company Ltd",
                Email = "osbbcompany@gmail.com",
                Phones = new List<string>() { "063-12-12-665", "093-56-89-895" }
            };


            ///---------------------------------------------------------------------------------------------
            ///Company///
            ///---------------------------------------------------------------------------------------------
            company = new Company() { CompanyData = companyData };
            company.Houses.Add(house);
            company.Territories.Add(territory);
            ctx.Companies.Add(company);

            byte[] passByte = Encoding.ASCII.GetBytes(HashMethods.HashMethods.GetHashString("qwer"));
            user = new User()
            {
                Login = "admin",
                Password = passByte,
                FirstName = "Mykola",
                LastName = "Petro",
                Phone = "066-564-51-23",
                BirthDate = DateTime.Now,
                Email = "dmitriysemysiuk@gmail.com",
                UserStatus = UserStatus.ADMIN
            };
            ctx.Users.Add(user);
            company.Users.Add(user);

            passByte = Encoding.ASCII.GetBytes(HashMethods.HashMethods.GetHashString("qwer"));
            user = new User()
            {
                Login = "director",
                Password = passByte,
                FirstName = "Vasyl",
                LastName = "Ivan",
                Phone = "050-452-88-56",
                BirthDate = DateTime.Now,
                Email = "dmitriysemysiuk17@gmail.com",
                UserStatus = UserStatus.DIRECTOR
            };
            ctx.Users.Add(user);
            company.Users.Add(user);

            passByte = Encoding.ASCII.GetBytes(HashMethods.HashMethods.GetHashString("qwer"));
            user = new User()
            {
                Login = "accountant",
                Password = passByte,
                FirstName = "Lena",
                LastName = "Anya",
                Phone = "050-636-31-23",
                BirthDate = DateTime.Now,
                //Email = "dmitriysemysiuk@gmail.com",
                UserStatus = UserStatus.ACCOUNTANT
            };
            ctx.Users.Add(user);
            company.Users.Add(user);

            passByte = Encoding.ASCII.GetBytes(HashMethods.HashMethods.GetHashString("asdf"));
            user = new User()
            {
                Login = "janitor1",
                Password = passByte,
                FirstName = "Ivan",
                LastName = "Petro",
                Phone = "098-459-87-41",
                BirthDate = DateTime.Now,
                //Email = "dmitriysemysiuk@gmail.com",
                UserStatus = UserStatus.JANITOR
            };
            ctx.Users.Add(user);
            company.Users.Add(user);

            passByte = Encoding.ASCII.GetBytes(HashMethods.HashMethods.GetHashString("asdf"));
            user = new User()
            {
                Login = "janitor2",
                Password = passByte,
                FirstName = "Valja",
                LastName = "Nika",
                Phone = "067-254-56-89",
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