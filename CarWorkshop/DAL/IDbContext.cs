using Models;
using System.Collections.Generic;

namespace DAL
{
    public  interface IDbContext
    {
        Dictionary<string, User> Users { get; set; }

        Dictionary<string, CarWorkshop> Workshops { get; set; }

        Dictionary<KeyValuePair<string, string>, Appointment> Appointments { get; set; }
    }
}
