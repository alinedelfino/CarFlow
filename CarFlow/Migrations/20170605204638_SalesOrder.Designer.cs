using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CarFlow.Models;

namespace CarFlow.Migrations
{
    [DbContext(typeof(CarFlowContext))]
    [Migration("20170605204638_SalesOrder")]
    partial class SalesOrder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarFlow.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDay");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Telephone");

                    b.HasKey("ID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CarFlow.Models.SalesAdvisor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDay");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<decimal>("Sallary");

                    b.Property<string>("Telephone");

                    b.HasKey("ID");

                    b.ToTable("SalesAdvisor");
                });

            modelBuilder.Entity("CarFlow.Models.SalesOrder", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<string>("ProductName");

                    b.Property<DateTime>("SaleDate");

                    b.Property<decimal>("SalePrice");

                    b.Property<int>("SalesAdvisorId");

                    b.HasKey("ID");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SalesAdvisorId");

                    b.ToTable("SalesOrder");
                });

            modelBuilder.Entity("CarFlow.Models.SalesOrder", b =>
                {
                    b.HasOne("CarFlow.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarFlow.Models.SalesAdvisor", "SalesAdvisor")
                        .WithMany("SalesOrders")
                        .HasForeignKey("SalesAdvisorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
