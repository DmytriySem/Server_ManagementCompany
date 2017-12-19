using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.Territory
{
    public class Territory : PlaceAbstr
    {
        public PlayGround PlayGround { get; set; }
        public RestTerritory RestTerritory { get; set; }

        public ICollection<GarbagePlace> GarbagePlaces { get; set; }
        public ICollection<ParkingPlace> ParkingPlaces { get; set; }

        public Territory()
        {
            GarbagePlaces = new List<GarbagePlace>();
            ParkingPlaces = new List<ParkingPlace>();
        }
    }
}
