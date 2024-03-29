﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KinoPlus.Services.Database;

public partial class KinoplusContext : DbContext
{
    public KinoplusContext()
    {
    }

    public KinoplusContext(DbContextOptions<KinoplusContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Hall> Halls { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<LocationHall> LocationHalls { get; set; }

    public virtual DbSet<LocationProjectionType> LocationProjectionTypes { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieActor> MovieActors { get; set; }

    public virtual DbSet<MovieCategory> MovieCategories { get; set; }

    public virtual DbSet<MovieGenre> MovieGenres { get; set; }

    public virtual DbSet<MovieReaction> MovieReactions { get; set; }

    public virtual DbSet<MovieStatus> MovieStatuses { get; set; }

    public virtual DbSet<Projection> Projections { get; set; }

    public virtual DbSet<ProjectionType> ProjectionTypes { get; set; }

    public virtual DbSet<RecurringProjection> RecurringProjections { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<WeekDay> WeekDays { get; set; }

    public virtual DbSet<Year> Years { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.ToTable("Actor");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("City");

            entity.HasIndex(e => e.CountryId, "IX_City_CountryId");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_City_Country");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("Genre");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Hall>(entity =>
        {
            entity.ToTable("Hall");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.ToTable("Image");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("Location");

            entity.HasIndex(e => e.CityId, "IX_Location_CityId");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.City).WithMany(p => p.Locations)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Location_City");
        });

        modelBuilder.Entity<LocationHall>(entity =>
        {
            entity.ToTable("LocationHall");

            entity.HasIndex(e => e.HallId, "IX_LocationHall_HallId");

            entity.HasIndex(e => e.LocationId, "IX_LocationHall_LocationId");

            entity.HasOne(d => d.Hall).WithMany(p => p.LocationHalls)
                .HasForeignKey(d => d.HallId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LocationHall_Hall");

            entity.HasOne(d => d.Location).WithMany(p => p.LocationHalls)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LocationHall_Location");
        });

        modelBuilder.Entity<LocationProjectionType>(entity =>
        {
            entity.ToTable("LocationProjectionType");

            entity.HasIndex(e => new { e.LocationId, e.ProjectionTypeId }, "IX_LocationProjectionType").IsUnique();

            entity.HasIndex(e => e.ProjectionTypeId, "IX_LocationProjectionType_ProjectionTypeId");

            entity.HasOne(d => d.Location).WithMany(p => p.LocationProjectionTypes)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LocationProjectionType_Location");

            entity.HasOne(d => d.ProjectionType).WithMany(p => p.LocationProjectionTypes)
                .HasForeignKey(d => d.ProjectionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LocationProjectionType_ProjectionType");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.ToTable("Movie");

            entity.HasIndex(e => e.ImageId, "IX_Movie_ImageId");

            entity.HasIndex(e => e.MovieStatusId, "IX_Movie_MovieStatusId");

            entity.HasIndex(e => e.YearId, "IX_Movie_YearId");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.TrailerUrl).HasMaxLength(200);

            entity.HasOne(d => d.Image).WithMany(p => p.Movies)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("FK_Movie_Image");

            entity.HasOne(d => d.MovieStatus).WithMany(p => p.Movies)
                .HasForeignKey(d => d.MovieStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movie_MovieStatus");

            entity.HasOne(d => d.Year).WithMany(p => p.Movies)
                .HasForeignKey(d => d.YearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movie_Year");
        });

        modelBuilder.Entity<MovieActor>(entity =>
        {
            entity.ToTable("MovieActor");

            entity.HasIndex(e => e.ActorId, "IX_MovieActor_ActorId");

            entity.HasIndex(e => e.MovieId, "IX_MovieActor_MovieId");

            entity.HasOne(d => d.Actor).WithMany(p => p.MovieActors)
                .HasForeignKey(d => d.ActorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovieActor_Actor");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieActors)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovieActor_Movie");
        });

        modelBuilder.Entity<MovieCategory>(entity =>
        {
            entity.ToTable("MovieCategory");

            entity.HasIndex(e => e.CategoryId, "IX_MovieCategory_CategoryId");

            entity.HasIndex(e => e.MovieId, "IX_MovieCategory_MovieId");

            entity.HasOne(d => d.Category).WithMany(p => p.MovieCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovieCategory_Category");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieCategories)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovieCategory_Movie");
        });

        modelBuilder.Entity<MovieGenre>(entity =>
        {
            entity.ToTable("MovieGenre");

            entity.HasIndex(e => e.GenreId, "IX_MovieGenre_GenreId");

            entity.HasIndex(e => e.MovieId, "IX_MovieGenre_MovieId");

            entity.HasOne(d => d.Genre).WithMany(p => p.MovieGenres)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovieGenre_Genre");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieGenres)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovieGenre_Movie");
        });

        modelBuilder.Entity<MovieReaction>(entity =>
        {
            entity.ToTable("MovieReaction");

            entity.HasIndex(e => e.MovieId, "IX_MovieReaction_MovieId");

            entity.HasIndex(e => e.UserId, "IX_MovieReaction_UserId");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieReactions)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovieReaction_Movie");

            entity.HasOne(d => d.User).WithMany(p => p.MovieReactions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovieReaction_User");
        });

        modelBuilder.Entity<MovieStatus>(entity =>
        {
            entity.ToTable("MovieStatus");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Projection>(entity =>
        {
            entity.ToTable("Projection");

            entity.HasIndex(e => e.HallId, "IX_Projection_HallId");

            entity.HasIndex(e => e.LocationId, "IX_Projection_LocationId");

            entity.HasIndex(e => e.MovieId, "IX_Projection_MovieId");

            entity.HasIndex(e => e.ProjectionTypeId, "IX_Projection_ProjectionTypeId");

            entity.HasIndex(e => e.RecurringProjectionId, "IX_Projection_RecurringProjectionId");

            entity.Property(e => e.EndsAt).HasColumnType("smalldatetime");
            entity.Property(e => e.Price).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.StartsAt).HasColumnType("smalldatetime");

            entity.HasOne(d => d.Hall).WithMany(p => p.Projections)
                .HasForeignKey(d => d.HallId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Projection_Hall");

            entity.HasOne(d => d.Location).WithMany(p => p.Projections)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Projection_Location");

            entity.HasOne(d => d.Movie).WithMany(p => p.Projections)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Projection_Movie");

            entity.HasOne(d => d.ProjectionType).WithMany(p => p.Projections)
                .HasForeignKey(d => d.ProjectionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Projection_ProjectionType");

            entity.HasOne(d => d.RecurringProjection).WithMany(p => p.Projections)
                .HasForeignKey(d => d.RecurringProjectionId)
                .HasConstraintName("FK_Projection_RecurringProjection");
        });

        modelBuilder.Entity<ProjectionType>(entity =>
        {
            entity.ToTable("ProjectionType");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<RecurringProjection>(entity =>
        {
            entity.ToTable("RecurringProjection");

            entity.HasIndex(e => e.WeekDayId, "IX_RecurringProjection_WeekDayId");

            entity.Property(e => e.EndingDate).HasColumnType("date");
            entity.Property(e => e.StartingDate).HasColumnType("date");

            entity.HasOne(d => d.WeekDay).WithMany(p => p.RecurringProjections)
                .HasForeignKey(d => d.WeekDayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecurringProjection_WeekDay");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.ToTable("Seat");

            entity.Property(e => e.Row)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.ToTable("Ticket");

            entity.HasIndex(e => e.ProjectionId, "IX_Ticket_ProjectionId");

            entity.HasIndex(e => e.SeatId, "IX_Ticket_SeatId");

            entity.HasIndex(e => e.UserId, "IX_Ticket_UserId");

            entity.Property(e => e.DateOfPurchase).HasColumnType("datetime");

            entity.HasOne(d => d.Projection).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ProjectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Projection");

            entity.HasOne(d => d.Seat).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.SeatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Seat");

            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.ImageId, "IX_User_ImageId");

            entity.HasIndex(e => e.LocationId, "IX_User_LocationId");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(200);
            entity.Property(e => e.PasswordSalt).HasMaxLength(200);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Image).WithMany(p => p.Users)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("FK_User_Image");

            entity.HasOne(d => d.Location).WithMany(p => p.Users)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_User_Location");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.ToTable("UserRole");

            entity.HasIndex(e => e.RoleId, "IX_UserRole_RoleId");

            entity.HasIndex(e => e.UserId, "IX_UserRole_UserId");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRole_Role");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRole_User");
        });

        modelBuilder.Entity<WeekDay>(entity =>
        {
            entity.ToTable("WeekDay");

            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Year>(entity =>
        {
            entity.ToTable("Year");

            entity.Property(e => e.Name).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
