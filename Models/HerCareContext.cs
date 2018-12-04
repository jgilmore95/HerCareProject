using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace her_care.Models
{
    public class HerCareContext : DbContext
    {
        public HerCareContext(DbContextOptions<HerCareContext> options) : base(options)
        { }

        public DbSet<Test> Tests { get; set; }
    }
}