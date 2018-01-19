using ServerDAL_ManagementCompany.Entities.Room;
using ServerDAL_ManagementCompany.Entities.Territory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.Equipment
{
    public class Camera : EquipmentAbstr
    {
        public string IpAdress { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public double Resolution { get; set; }

        public int? EntranceId { get; set; }
        public Entrance Entrance { get; set; }

        public int? PlayGroundId { get; set; }
        public PlayGround PlayGround { get; set; }

        public int? HallwayId { get; set; }
        public Hallway Hallway { get; set; }

        public int? RestTerritoryId { get; set; }
        public RestTerritory RestTerritory { get; set; }

        public int? ParkingTerritoryId { get; set; }
        public ParkingTerritory ParkingTerritory { get; set; }
    }
}