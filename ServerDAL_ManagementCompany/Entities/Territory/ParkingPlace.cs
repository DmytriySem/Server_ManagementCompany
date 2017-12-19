using ServerDAL_ManagementCompany.Entities.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.Territory
{
    public class ParkingPlace : PlaceAbstr
    {
        public int ParkingNumber { get; set; }
        public StatusOfPremises StatusOfPremises{ get; set; }
        public User User { get; set; }
    }
}
