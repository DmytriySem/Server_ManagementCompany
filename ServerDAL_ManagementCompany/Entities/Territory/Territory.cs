using ServerDAL_ManagementCompany.Entities.ManagementCompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.Territory
{
    public class Territory : PlaceAbstr
    {
        public ParkingTerritory ParkingTerritory { get; set; }
        public AdjoiningTerritory AdjoiningTerritory { get; set; }
        public GarbagePlace GarbagePlace { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        public Territory()
        {
            ParkingTerritory = new ParkingTerritory();
            AdjoiningTerritory = new AdjoiningTerritory();
        }
    }
}
