using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.Territory
{
    public class AdjoiningTerritory : PlaceAbstr
    {
        public PlayGround PlayGround { get; set; }
        public RestTerritory RestTerritory { get; set; }
        public AdjoiningTerritory()
        {
            PlayGround = new PlayGround();
            RestTerritory = new RestTerritory();
        }
    }
}
