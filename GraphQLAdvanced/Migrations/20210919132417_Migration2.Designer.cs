// <auto-generated />
using System;
using GraphQLAdvanced.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GraphQLAdvanced.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210919132417_Migration2")]
    partial class Migration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("GraphQLAdvanced.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid")
                        .HasColumnName("ownerId");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("accounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8e9aaae3-280f-4170-875c-ea1d473d1df9"),
                            Description = "Cash account for our users",
                            OwnerId = new Guid("b048ec5c-2fab-4afe-83f2-aedaffe5c44c"),
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("e4662e74-fd5f-4b38-8b82-ff1e0981fec7"),
                            Description = "Savings account for our users",
                            OwnerId = new Guid("7cc88ce6-3418-42c4-b83d-bae1dc4819d1"),
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("bb491f40-e532-43c5-ba09-fc408848f83c"),
                            Description = "Income account for our users",
                            OwnerId = new Guid("7cc88ce6-3418-42c4-b83d-bae1dc4819d1"),
                            Type = 3
                        });
                });

            modelBuilder.Entity("GraphQLAdvanced.Entities.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("owners");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b048ec5c-2fab-4afe-83f2-aedaffe5c44c"),
                            Address = "John Doe's address",
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = new Guid("7cc88ce6-3418-42c4-b83d-bae1dc4819d1"),
                            Address = "Jane Doe's address",
                            Name = "Jane Doe"
                        });
                });

            modelBuilder.Entity("GraphQLAdvanced.Entities.Account", b =>
                {
                    b.HasOne("GraphQLAdvanced.Entities.Owner", "Owner")
                        .WithMany("Accounts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("GraphQLAdvanced.Entities.Owner", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
