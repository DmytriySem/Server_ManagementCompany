using ServerDAL_ManagementCompany.Entities.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.ManagementCompany.House
{
    public class House
    {
        public int Id { get; set; }
        public ICollection<Cellar> Cellars { get; set; }
        public ICollection<Entrance> Entrances{ get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        public House()
        {
            Cellars = new List<Cellar>();
            Entrances = new List<Entrance>();
        }
    }
}
