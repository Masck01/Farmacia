using System;
using System.Collections.Generic;
using System.Text;
using FarmaciaAvellaneda.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaAvellaneda.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FarmaciaAvellaneda.Models.Empleado> Empleado { get; set; }
    }
}
