using Models;
using System.Collections.Generic;

namespace DAL
{
    public class DbContext : IDbContext
    {
        public Dictionary<string, User> Users { get; set; }

        public Dictionary<string, CarWorkshop> Workshops { get; set; }

        public Dictionary<KeyValuePair<string,string>, Appointment> Appointments { get; set; }

        public DbContext()
        {
            Seed();
        }

        private void Seed()
        {
            Users.Add(
                "Roman", new User()
                {
                    City = "Lviv",
                    Country = "Ukraine",
                    Email = "qwerty@gmail.com",
                    PostalCode = 81000,
                    UserName = "Roman"
                });

            Users.Add(
              "Dariia", new User()
              {
                  City = "Kyiv",
                  Country = "Ukraine",
                  Email = "wasddd@gmail.com",
                  PostalCode = 79000,
                  UserName = "Dariia"
              });

            Workshops.Add("Car Repair",
                new CarWorkshop
                {
                    PostalCode = 81000,
                    Country = "Ukraine",
                    City = "Lviv",
                    CompanyName = "Car Repair",
                    CarTrademarks = new List<string>
                    {
                        "VW","BMW"
                    }
                });

            Workshops.Add("Automoto",
              new CarWorkshop
              {
                  PostalCode = 79000,
                  Country = "Ukraine",
                  City = "Kyiv",
                  CompanyName = "Automoto",
                  CarTrademarks = new List<string>
                    {
                        "VW","MB"
                    }
              });
        }
    }
}
