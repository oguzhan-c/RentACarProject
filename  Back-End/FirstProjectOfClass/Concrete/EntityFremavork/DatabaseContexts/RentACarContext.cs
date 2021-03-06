﻿using Entities.Concrete;
using Entities.Concrute;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrute;

namespace DataAccess.Concrete.EntityFremavork.DatabaseContexts
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
        public DbSet<Car> Cars { get; set; }
        public DbSet<Communication> Communications { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Rent> Rent { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
    }
}
