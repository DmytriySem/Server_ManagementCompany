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

        public int? ParkingTerritoryId { get; set; }
        public ParkingTerritory ParkingTerritory { get; set; }
    }
}
