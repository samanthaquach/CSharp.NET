using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Wedding_Planner.Models;

namespace Wedding_Planner.Migrations
{
    [DbContext(typeof(WeddingContext))]
    [Migration("20171115041633_rsvp")]
    partial class rsvp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Wedding_Planner.Models.Planning", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Userid");

                    b.Property<string>("address")
                        .IsRequired();

                    b.Property<DateTime>("date");

                    b.Property<string>("wedderone")
                        .IsRequired();

                    b.Property<string>("weddertwo")
                        .IsRequired();

                    b.HasKey("id");

                    b.HasIndex("Userid");

                    b.ToTable("planning");
                });

            modelBuilder.Entity("Wedding_Planner.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("confirm")
                        .IsRequired();

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("firstname")
                        .IsRequired();

                    b.Property<string>("lastname")
                        .IsRequired();

                    b.Property<string>("password")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Wedding_Planner.Models.Planning", b =>
                {
                    b.HasOne("Wedding_Planner.Models.User", "User")
                        .WithMany("Planning")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
