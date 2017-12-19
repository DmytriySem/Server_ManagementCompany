using ServerBLL_ManagementCompany.Interfaces;
using ServerDAL_ManagementCompany.Interfaces;
using ServerDAL_ManagementCompany.Realizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBLL_ManagementCompany.Realizations
{
    public class CreateHouse : ICreateHouse
    {
        IBuildHouse create = new BuildHouse();
        public void BuildHouse()
        {
            create.BuildHouse();
        }
    }
}
