using System;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data
{
	public class ApplicationDBcontext : DbContext
	{
        public ApplicationDBcontext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            _ = modelBuilder.Entity<Product>().ToTable("Products");

        }
        


    }
}

