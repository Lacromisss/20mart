using ConsoleApp66.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp66.Data.Dal
{
    internal class FootballDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-HEG2GJ6\SQLEXPRESS;Database=CentilmennnMustikkk;Trusted_Connection=True");

        }
        public DbSet<Stadion> Stadions { get; set; }    
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
