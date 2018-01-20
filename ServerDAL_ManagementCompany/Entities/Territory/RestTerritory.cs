using ServerDAL_ManagementCompany.Entities.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.Territory
{
    public class RestTerritory : PlaceAbstr
    {
        public ICollection<Light> Lights { get; set; }
        public ICollection<Camera> Cameras { get; set; }
        public ICollection<GarbagePlace> GarbagePlaces { get; set; }

        public RestTerritory()
        {
            Lights = new List<Light>();
            Cameras = new List<Camera>();
            GarbagePlaces = new List<GarbagePlace>();
        }
    }
}
