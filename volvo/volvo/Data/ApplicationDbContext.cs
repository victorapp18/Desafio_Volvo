using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using volvo.Models;

namespace volvo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<volvo.Models.Caminhao> Caminhao { get; set; }
        public DbSet<volvo.Models.Modelo> Modelo { get; set; }
    }
}
