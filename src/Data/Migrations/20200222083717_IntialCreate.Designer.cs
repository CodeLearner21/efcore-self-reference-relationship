﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SelfRefExtityExample.Data;

namespace SelfRefExtityExample.Data.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20200222083717_IntialCreate")]
    partial class IntialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SelfRefExtityExample.Data.Entities.Invitation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("FromId");

                    b.Property<Guid>("ToId");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("Invitations");
                });

            modelBuilder.Entity("SelfRefExtityExample.Data.Entities.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("SelfRefExtityExample.Data.Entities.Invitation", b =>
                {
                    b.HasOne("SelfRefExtityExample.Data.Entities.Member", "FromMember")
                        .WithMany("ToInvitations")
                        .HasForeignKey("FromId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SelfRefExtityExample.Data.Entities.Member", "ToMember")
                        .WithMany("FromInviations")
                        .HasForeignKey("ToId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
