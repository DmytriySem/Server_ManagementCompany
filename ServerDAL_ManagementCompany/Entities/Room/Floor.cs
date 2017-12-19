using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.Room
{
    public class Floor
    {
        public int Id { get; set; }
        public virtual ICollection<Appartment> Appartments { get; set; }
        public Hallway Hallway { get; set; }
        public int NumberOfFloor { get; set; }

        public Floor()
        {
            Appartments = new List<Appartment>();
        }
    }
}
