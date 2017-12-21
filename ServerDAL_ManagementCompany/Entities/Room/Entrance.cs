using ServerDAL_ManagementCompany.Entities.Equipment;
using ServerDAL_ManagementCompany.Entities.Territory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.Room
{
    public class Entrance : RoomAbstr
    {
        public ICollection<Camera> Cameras { get; set; }
        public int EntranceNumber { get; set; }
        public ICollection<Lift> Lifts { get; set; }
        public ICollection<Light> Lights { get; set; }
        public Intercom Intercom { get; set; }
        public ICollection<Floor> Floors { get; set; }
        public StatusOfCleaning StatusOfCleaning { get; set; }
        public Entrance()
        {
            Cameras = new List<Camera>();
            Lifts = new List<Lift>();
            Lights = new List<Light>();
            Floors = new List<Floor>();
        }
    }
}
