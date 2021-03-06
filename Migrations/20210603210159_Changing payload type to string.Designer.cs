// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReBlaze.DataModel;

namespace ReBlaze.Migrations
{
    [DbContext(typeof(DataModelContext))]
    [Migration("20210603210159_Changing payload type to string")]
    partial class Changingpayloadtypetostring
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0-preview.4.21253.1");

            modelBuilder.Entity("ReBlaze.DataModel.Command", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ModelID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Payload")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("ModelID");

                    b.ToTable("Command");
                });

            modelBuilder.Entity("ReBlaze.DataModel.Device", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ModelID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Port")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("ModelID");

                    b.ToTable("Device");
                });

            modelBuilder.Entity("ReBlaze.DataModel.Model", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Model");
                });

            modelBuilder.Entity("ReBlaze.DataModel.Command", b =>
                {
                    b.HasOne("ReBlaze.DataModel.Model", "Model")
                        .WithMany("Commands")
                        .HasForeignKey("ModelID");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("ReBlaze.DataModel.Device", b =>
                {
                    b.HasOne("ReBlaze.DataModel.Model", "Model")
                        .WithMany("Devices")
                        .HasForeignKey("ModelID");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("ReBlaze.DataModel.Model", b =>
                {
                    b.Navigation("Commands");

                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
