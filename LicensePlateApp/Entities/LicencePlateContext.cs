using LicensePlateApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensePlateApp.Entities
{
    public class LicencePlateContext : DbContext
    {
        public LicencePlateContext(DbContextOptions<LicencePlateContext> options) : base(options)
        {
        }
        public DbSet<LicencePlate> LicencePlates { get; set; }
    }
}
