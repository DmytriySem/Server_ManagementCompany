using ServerDAL_ManagementCompany.Entities.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.Equipment
{
    public class Lift : EquipmentAbstr
    {
        public int CarryingCapacity { get; set; }

        public int? EntranceId { get; set; }
        public Entrance Entrance{ get; set; }
    }
}
