﻿// <auto-generated />
using System;
using ASPNETCoreHeroku.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ASPNETCoreHeroku.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class ClientContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ASPNETCoreHeroku.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("PostalCode");

                    b.Property<string>("ProfileImage");

                    b.Property<string>("Province");

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("ASPNETCoreHeroku.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Artist");

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("EventName");

                    b.Property<string>("Location");

                    b.HasKey("TicketId");

                    b.HasIndex("ClientId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("ASPNETCoreHeroku.Models.Ticket", b =>
                {
                    b.HasOne("ASPNETCoreHeroku.Models.Client", "Client")
                        .WithMany("Tickets")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
