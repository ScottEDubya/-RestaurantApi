﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantApi.Data;

namespace RestaurantApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180820200335_DropIngredientsTable")]
    partial class DropIngredientsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("RestaurantApi.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Calories");

                    b.Property<int?>("Carbohydrates");

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("Protein");

                    b.Property<int?>("Sugar");

                    b.HasKey("Id");

                    b.ToTable("Meals");
                });
#pragma warning restore 612, 618
        }
    }
}