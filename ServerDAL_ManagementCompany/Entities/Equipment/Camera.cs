using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.Equipment
{
    public class Camera : EquipmentAbstr
    {
        public string IpAdress { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public double Resolution { get; set; }
    }
}
