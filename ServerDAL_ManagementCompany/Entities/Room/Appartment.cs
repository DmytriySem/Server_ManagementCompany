using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.Room
{
    public class Appartment : RoomAbstr
    {
        public int AppartmentNumber { get; set; }
        public int NumberOfResidents { get; set; }
        public StatusOfPremises StatusOfPremises { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int? FloorId { get; set; }
        public Floor Floor { get; set; }
    }
}
