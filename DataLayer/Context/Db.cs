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

        public DbSet<Articles> Articles { get; set; }

        public DbSet<Person> Persons { get; set; }
            
    }
}
