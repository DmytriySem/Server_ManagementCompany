using ServerDAL_ManagementCompany.Entities.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.ManagementCompany
{
    public class Cellar
    {
        public int Id { get; set; }
        public int CellarNumber { get; set; }
        public ICollection<Basement> Basements { get; set; }
        public Hallway Hallway { get; set; }

        public int? HouseId { get; set; }
        public House.House House { get; set; }

        public Cellar()
        {
            Basements = new List<Basement>();
        }
    }
}
