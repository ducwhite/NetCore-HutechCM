using ClubManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HCM.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Managers> Managers { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Clubs> Clubs { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<Schedules> Schedules { get; set; }

    }
}
