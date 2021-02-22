using Entities.Concrete;
using Entities.Concrute;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFremavork
{
    //Context : Db deki Tablolar İle Class ları Birbirine Bağlamak 
    public class RentACarContext : DbContext
    {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer
                    (
                        @"Server= (localdb)\MSSQLLocalDB;
                        Database=RentACar;
                        Trusted_Connection=true"
                    );
            }
        //Entities in the database are mapped to Entities in the entity class
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Communications> Communications { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Purchases> Purchases { get; set; }
        public DbSet<Rent> Rent { get; set; }
        public DbSet<Sales> Sales { get; set; }


    }
}
