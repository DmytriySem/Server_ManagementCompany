using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.ManagementCompany
{
    public class CompanyData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> Phones { get; set; }
        public virtual Company Company { get; set; }
        public List<CompanyNews> CompanyNews { get; set; }
    }
}
