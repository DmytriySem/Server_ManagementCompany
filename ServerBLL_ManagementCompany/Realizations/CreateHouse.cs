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
        private IBuildHouse create = null;
        public CreateHouse(string connStr)
        {
            create = new BuildHouse(connStr);
        }
        public void BuildHouse()
        {
            create.BuildHouse();
        }
    }
}
