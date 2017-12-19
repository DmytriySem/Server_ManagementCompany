using ServerDAL_ManagementCompany.Entities.Room;
using ServerDAL_ManagementCompany.Entities.Territory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDAL_ManagementCompany.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }
        public byte[] Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<Appartment> Appartments { get; set; }
        public ICollection<Basement> Basements { get; set; }
        public ICollection<ParkingPlace> ParkingPlaces { get; set; }

        public UserStatus UserStatus { get; set; }

        public User()
        {
            Appartments = new List<Appartment>();
            Basements = new List<Basement>();
            ParkingPlaces = new List<ParkingPlace>();
        }
    }
}
