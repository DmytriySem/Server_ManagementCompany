using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.Territory
{
    public abstract class PlaceAbstr
    {
        public int Id { get; set; }
        public double Area { get; set; }
        public string Name { get; set; }
        public StatusOfCleaning StatusOfCleaning{ get; set; }
    }
}
