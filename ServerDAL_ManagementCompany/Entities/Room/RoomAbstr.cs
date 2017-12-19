using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.Room
{
    public abstract class RoomAbstr
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
    }
}
