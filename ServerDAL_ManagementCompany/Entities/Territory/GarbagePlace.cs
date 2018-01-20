using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.Territory
{
    public class GarbagePlace : PlaceAbstr
    {
        public int GarbageNumber { get; set; }

        public int? TerritoryId { get; set; }
        public Territory Territory { get; set; }

        public int? ParkingTerritoryId { get; set; }
        public ParkingTerritory ParkingTerritory { get; set; }

        public int? PlayGroundId { get; set; }
        public PlayGround PlayGround { get; set; }

        public int? RestTerritoryId { get; set; }
        public RestTerritory RestTerritory { get; set; }
    }
}
