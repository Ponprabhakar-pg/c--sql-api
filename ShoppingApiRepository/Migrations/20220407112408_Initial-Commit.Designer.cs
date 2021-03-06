// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingApiRepository;

namespace ShoppingApiRepository.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    [Migration("20220407112408_Initial-Commit")]
    partial class InitialCommit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ShoppingApiRepository.SqlEntity.EntityProductModal", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
