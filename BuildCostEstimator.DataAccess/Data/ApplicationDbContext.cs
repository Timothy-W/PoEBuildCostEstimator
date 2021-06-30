using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BuildCostEstimator.Models;

namespace BuildCostEstimator.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<PastebinLink> PastebinLinks { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemSet> ItemSets { get; set; }
        public DbSet<Build> Builds { get; set; }
        public DbSet<ItemSetRelationship> ItemSetRelationships { get; set; }

        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Do we need this?
            base.OnModelCreating(builder);

            // Set up primary key with new ItemSetRelationship class
            builder.Entity<ItemSetRelationship>().HasKey(c => new { c.ItemId, c.ItemSetId });


            //Manually configure relationships
            //builder.Entity<ItemSetRelationship>()
            //    .HasOne(x => x.ItemSet)
            //    .WithMany(x => x.ItemSetRelationships)
            //    .HasForeignKey(x => x.ItemSetId);
            //
            //builder.Entity<ItemSetRelationship>()
            //    .HasOne(x => x.Item)
            //    .WithMany(x => x.ItemSetRelationships)
            //    .HasForeignKey(x => x.ItemId);


        }

    }
}
