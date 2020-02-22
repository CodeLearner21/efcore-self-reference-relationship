using Microsoft.EntityFrameworkCore;
using SelfRefExtityExample.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfRefExtityExample.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Invitation> Invitations { get; set; }


        public ApiContext(DbContextOptions<ApiContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invitation>()
                .HasOne(inv => inv.FromMember)
                .WithMany(p => p.ToInvitations)
                .HasForeignKey(inv => inv.FromId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Invitation>()
                .HasOne(inv => inv.ToMember)
                .WithMany(p => p.FromInviations)
                .HasForeignKey(inv => inv.ToId);
        }
    }
}
