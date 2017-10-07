using horse_haven_dotnet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace horse_haven_dotnet
{
    public class WebAPIDataContext : DbContext
    {
        public WebAPIDataContext(DbContextOptions<WebAPIDataContext> options)
        : base(options)
        {
        }
        public DbSet<Boarding> Boardings { get; set; }
        public DbSet<BoardingType> BoardingTypes { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Horse> Horses { get; set; }
        public DbSet<HorseStatus> HorseStatuses { get; set; }
        public DbSet<HorseWeight> HorseWeights { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
    }
}
