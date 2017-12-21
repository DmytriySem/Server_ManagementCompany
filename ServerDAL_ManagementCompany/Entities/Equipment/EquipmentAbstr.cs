using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.Equipment
{
    public class EquipmentAbstr
    {
        public int Id { get; set; }
        public EquipmentStatus EquipmentStatus { get; set; }
    }
}
