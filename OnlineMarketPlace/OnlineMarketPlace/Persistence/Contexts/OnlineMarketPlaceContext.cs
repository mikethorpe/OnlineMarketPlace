﻿using Microsoft.EntityFrameworkCore;
using OnlineMarketPlace.Domain.Models;
using System;

namespace OnlineMarketPlace.Persistence.Contexts
{
    public class OnlineMarketPlaceContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public OnlineMarketPlaceContext(DbContextOptions<OnlineMarketPlaceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            // Assumption => price does not exceed 999.99
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<Product>()
                .HasData(
                    new
                    {
                        Id = 1,
                        Name = "Lavender heart",
                        Price = 9.25f
                    },
                    new
                    {
                        Id = 2,
                        Name = "Personalised cufflinks",
                        Price = 45.00f
                    },
                    new
                    {
                        Id = 3,
                        Name = "Kids T-shirt",
                        Price = 19.95f
                    }
                );
        }
    }

}
