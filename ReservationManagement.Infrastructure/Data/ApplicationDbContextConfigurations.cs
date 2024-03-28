using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReservationManagement.Core.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManagement.Infrastructure.Data
{
    public class ApplicationDbContextConfigurations
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<Reservation>().ToTable("Reservations");

            // Add any additional entity configurations here
        }
    }
}
