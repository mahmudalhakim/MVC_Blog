using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Blog.Models;

namespace Blog.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20161225145307_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blog.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryTypeId");

                    b.Property<string>("Headline")
                        .HasMaxLength(50);

                    b.Property<DateTime>("PostDate");

                    b.Property<string>("PostMessage")
                        .HasMaxLength(2000);

                    b.HasKey("Id");

                    b.HasIndex("CategoryTypeId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Blog.Models.PostCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.HasKey("Id");

                    b.ToTable("PostCategories");
                });

            modelBuilder.Entity("Blog.Models.Post", b =>
                {
                    b.HasOne("Blog.Models.PostCategory", "CategoryType")
                        .WithMany()
                        .HasForeignKey("CategoryTypeId");
                });
        }
    }
}
