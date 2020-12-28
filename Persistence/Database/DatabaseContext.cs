using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Models
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .LogTo(Console.WriteLine);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Created)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Modified)
                .HasComputedColumnSql("getdate()");

            modelBuilder.Entity<User>()
                .Property(u => u.Created)
                .HasDefaultValueSql("getdate()");

            // deal with ICollection<string> (create a single string from them for storage)
            var splitStringConverter =
                new ValueConverter<ICollection<string>, string>(
                    v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .ToList());

            modelBuilder.Entity<Vehicle>()
                .Property(nameof(Vehicle.AdditionalProperties))
                .HasConversion(splitStringConverter);

            modelBuilder.Entity<Vehicle>()
                .Property(nameof(Vehicle.Images))
                .HasConversion(splitStringConverter);

            modelBuilder.Entity<Vehicle>()
                .Property(nameof(Vehicle.Defects))
                .HasConversion(splitStringConverter);

            var valueComparer = new ValueComparer<ICollection<string>>(
                (c1, c2) => ReferenceEquals(c1, c2),
                c => c.GetHashCode());

            modelBuilder
                .Entity<Vehicle>()
                .Property(nameof(Vehicle.AdditionalProperties))
                .Metadata
                .SetValueComparer(valueComparer);

            modelBuilder
                .Entity<Vehicle>()
                .Property(nameof(Vehicle.Images))
                .Metadata
                .SetValueComparer(valueComparer);

            modelBuilder
                .Entity<Vehicle>()
                .Property(nameof(Vehicle.Defects))
                .Metadata
                .SetValueComparer(valueComparer);

            // ads liked by users
            modelBuilder
                .Entity<Vehicle>()
                .HasMany(v => v.LikedBy)
                .WithMany(u => u.LikedAds)
                .UsingEntity(j => j.ToTable("UserLikedAds"));


            // ads uploaded by user

            // Setting DeleteBehaviour to Cascade (which would delete user uploaded vehicles)
            // results in error when adding DB constraint on SQL Server
            // (because UserLikedAds table rows can be deleted from 2 paths
            // (User -> Vehicle -> UserLikedAds OR User -> (UserLikedAds, Vehicle))
            // So DeleteBehaviour here is set to SetNull and user uploaded
            // vehicles have to be deleted manually
            modelBuilder.Entity<User>()
                .HasMany(u => u.UploadedAds)
                .WithOne(v => v.Uploader)
                .OnDelete(DeleteBehavior.SetNull);

            // vehicle models
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.VehicleModel)
                .WithMany(m => m.Vehicles)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
