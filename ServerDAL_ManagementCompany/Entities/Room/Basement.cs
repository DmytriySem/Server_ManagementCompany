using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.Room
{
    public class Basement : RoomAbstr
    {
        public int BasementNumber { get; set; }
        public StatusOfPremises StatusOfPremises { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
