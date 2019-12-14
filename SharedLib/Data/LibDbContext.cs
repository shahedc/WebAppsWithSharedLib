using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib.Data
{
    public class LibDbContext : IdentityDbContext
    {
        public LibDbContext(DbContextOptions<LibDbContext> options)
            : base(options)
        {
        }

        protected LibDbContext()
        {

        }

        public DbSet<CinematicItem> CinematicItems { get; set; }

    }
}
