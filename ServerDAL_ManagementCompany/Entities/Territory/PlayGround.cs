using ServerDAL_ManagementCompany.Entities.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.Territory
{
    public class PlayGround : PlaceAbstr
    {
        public ICollection<Light> Lights { get; set; }
        public ICollection<Camera> Cameras { get; set; }

        public PlayGround()
        {
            Lights = new List<Light>();
            Cameras = new List<Camera>();
        }
    }
}
