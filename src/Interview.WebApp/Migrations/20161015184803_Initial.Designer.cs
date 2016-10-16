using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Interview.WebApp.Data;

namespace Interview.WebApp.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20161015184803_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("Interview.WebApp.Model.Todo", b =>
                {
                    b.Property<int>("TodoId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Completed");

                    b.Property<DateTime?>("CompletedOn");

                    b.Property<DateTime?>("DueDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("TodoId");

                    b.ToTable("Todos");
                });
        }
    }
}
