using ServerDAL_ManagementCompany.Entities.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.Territory
{
    public class ParkingTerritory : PlaceAbstr
    {
        public ICollection<GarbagePlace> GarbagePlaces { get; set; }
        public ICollection<ParkingPlace> ParkingPlaces { get; set; }
        public ICollection<Light> Lights { get; set; }
        public ICollection<Camera> Cameras { get; set; }
        public ParkingTerritory()
        {
            GarbagePlaces = new List<GarbagePlace>();
            ParkingPlaces = new List<ParkingPlace>();
            Lights = new List<Light>();
            Cameras = new List<Camera>();
        }
    }
}
