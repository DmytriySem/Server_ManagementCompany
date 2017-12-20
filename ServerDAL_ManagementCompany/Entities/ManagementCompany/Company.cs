using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities.ManagementCompany
{
    public class Company
    {
        public int Id { get; set; }
        
        public CompanyData CompanyData { get; set; }

        public ICollection<House.House> Houses{ get; set; }
        public ICollection<Territory.Territory> Territories { get; set; }
        public ICollection<User> Users{ get; set; }

        public Company()
        {
            Houses = new List<House.House>();
            Territories = new List<Territory.Territory>();
            Users = new List<User>();
        }
    }
}
