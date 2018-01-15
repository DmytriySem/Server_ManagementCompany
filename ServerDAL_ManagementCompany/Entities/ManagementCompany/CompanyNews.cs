using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.ManagementCompany
{
    public class CompanyNews
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public DateTime Date { get; set; }
        public virtual CompanyData CompanyData { get; set; }
    }
}
