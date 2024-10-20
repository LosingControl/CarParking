using System;
using System.Collections.Generic;
using CarParking.Models;
using Microsoft.EntityFrameworkCore;

namespace CarParking.DataBase.Context;

public partial class ParkingDbContext : DbContext
{
    public ParkingDbContext()
    {
    }

    public ParkingDbContext(DbContextOptions<ParkingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarParkingPlaceRelation> CarParkingPlaceRelations { get; set; }

    public virtual DbSet<ParkingPlace> ParkingPlaces { get; set; }

    public virtual DbSet<UserDatum> UserData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Car_pkey");

            entity.ToTable("Car");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CarName).HasColumnName("car_name");
            entity.Property(e => e.CarNumber).HasColumnName("car_number");
            entity.Property(e => e.ParkingPlaceId).HasColumnName("Parking_place_id");
            entity.Property(e => e.PtsNumber).HasColumnName("PTS_number");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.ParkingPlace).WithMany(p => p.Cars)
                .HasForeignKey(d => d.ParkingPlaceId)
                .HasConstraintName("parking_place_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Cars)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_fkey");
        });

        modelBuilder.Entity<CarParkingPlaceRelation>(entity =>
        {
            entity.HasKey(e => new { e.CarId, e.PlaceId }).HasName("Car_Parking_place_relation_pkey");

            entity.ToTable("Car_Parking_place_relation");

            entity.Property(e => e.CarId).HasColumnName("car_id");
            entity.Property(e => e.PlaceId).HasColumnName("place_id");
        });

        modelBuilder.Entity<ParkingPlace>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Parking_space_pkey");

            entity.ToTable("Parking_place");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Floor).HasColumnName("floor");
            entity.Property(e => e.PlaceNumber).HasColumnName("place_number");
            entity.Property(e => e.ReservationDate).HasColumnName("reservation_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.ParkingPlaces)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_fkey");
        });

        modelBuilder.Entity<UserDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_data_pkey");

            entity.ToTable("User_data");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.MiddleName).HasColumnName("middle_name");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PassportId).HasColumnName("passport_id");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
