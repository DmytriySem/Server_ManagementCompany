﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.Territory
{
    public class Territory : PlaceAbstr
    {
        public ParkingTerritory ParkingTerritory { get; set; }
        public AdjoiningTerritory AdjoiningTerritory { get; set; }
        public Territory()
        {
            ParkingTerritory = new ParkingTerritory();
            AdjoiningTerritory = new AdjoiningTerritory();
        }
    }
}
