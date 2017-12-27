namespace ServerDAL_ManagementCompany
{
    using Entities;
    using Entities.Territory;
    using System;
    using System.Data.Entity;
    using System.Linq;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Entities.Equipment;
    using Entities.Room;
    using Entities.ManagementCompany;
    using Entities.ManagementCompany.House;

    public class CompanyContext : DbContext
    {
        // Your context has been configured to use a 'CompanyContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ServerDAL_ManagementCompany.CompanyContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CompanyContext' 
        // connection string in the application configuration file.
        public CompanyContext(string connStringName)
            : base(connStringName)
            // : base("name=CompanyContext")
        {   
            //Database.SetInitializer(new DropCreateDatabaseAlways<CompanyContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CompanyContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasOptional(s => s.CompanyData) // Mark Address property optional in Student entity
                .WithRequired(ad => ad.Company);
            //    //modelBuilder.Entity<Appartment>()
            //    //    .HasRequired(c => c.User)
            //    //    .WithRequiredPrincipal(c => c.Appartments);
            //    //modelBuilder.Entity<UserData>()
            //    //    .HasRequired(c => c.User)
            //    //    .WithRequiredPrincipal(c => c.UserData);
            //    //modelBuilder.Entity<OwnershipAndRent>()
            //    //    .HasRequired(c => c.User)
            //    //    .WithRequiredPrincipal(c => c.OwnershipAndRent);
        }

            // Add a DbSet for each entity type that you want to include in your model. For more information 
            // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.


            //-----------------------ManagementCompany-----------------
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<Cellar> Cellars { get; set; }
        public virtual DbSet<CompanyData> CompanyDatas { get; set; }

        //-----------------------UserAccount-----------------
        public virtual DbSet<User> Users { get; set; }

        //-----------------------Territory-----------------
        public virtual DbSet<Territory> Territories { get; set; }
        public virtual DbSet<GarbagePlace> GarbagePlaces { get; set; }
        public virtual DbSet<ParkingPlace> ParkingPlaces { get; set; }
        public virtual DbSet<PlayGround> PlayGrounds { get; set; }
        public virtual DbSet<RestTerritory> RestTerritories { get; set; }

        //-----------------------Equipment-----------------
        public virtual DbSet<Camera> Cameras { get; set; }
        public virtual DbSet<Intercom> Intercoms { get; set; }
        public virtual DbSet<Lift> Lifts { get; set; }
        public virtual DbSet<Light> Lights { get; set; }


        //-----------------------Room-----------------
        public virtual DbSet<Appartment> Appartments { get; set; }
        public virtual DbSet<Basement> Basements { get; set; }
        public virtual DbSet<Entrance> Entrances { get; set; }
        public virtual DbSet<Floor> Floors { get; set; }
        public virtual DbSet<Hallway> Hallways { get; set; }
    }
}