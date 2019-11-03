using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Articles>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Person>().HasQueryFilter(x => !x.IsDeleted);
        }

        public DbSet<Articles> Articles { get; set; }

        public DbSet<Person> Persons { get; set; }
        public DbSet<ApiUsers> ApiUsers { get; set; }
            
    }
}
