using ServerDAL_ManagementCompany.Entities.Equipment;
using ServerDAL_ManagementCompany.Entities.Territory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.Room
{
    public class Hallway : RoomAbstr
    {
        public ICollection<Camera> Cameras { get; set; }
        public ICollection<Light> Lights { get; set; }
        public StatusOfCleaning StatusOfCleaning { get; set; }
        public Hallway()
        {
            Cameras = new List<Camera>();
            Lights = new List<Light>();
        }
    }
}
