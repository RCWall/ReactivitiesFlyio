using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    // 'DataContext' class extends DbContext, configuring the Entity Framework data model.
    // Includes 'Activities' DbSet for CRUD operations on 'Activity' entities.
    // DbContextOptions in the constructor enable configuration via dependency injection.
    public class DataContext : IdentityDbContext<AppUser>
    {
        // Initializes the DataContext with configuration options provided to the base DbContext class.
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        // 'Activities' property of type DbSet<Activity> to interact with 'Activity' entities in the database.
        // An 'entity' in Entity Framework represents a row in a database table, mapped to a class in your application for CRUD operations.
        // Enabled by Entity Framework Core for CRUD operations on the 'Activities' table.

        public DbSet<Activity> Activities { get; set; }

        public DbSet<ActivityAttendee> ActivityAttendees { get; set; }

        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<ActivityAttendee>(x => x.HasKey(aa => new {aa.AppUserId, aa.ActivityId}));

            builder.Entity<ActivityAttendee>()
                .HasOne(u => u.AppUser)
                .WithMany(a => a.Activities)
                .HasForeignKey(aa => aa.AppUserId);
            
            builder.Entity<ActivityAttendee>()
                .HasOne(u => u.Activity)
                .WithMany(a => a.Attendees)
                .HasForeignKey(aa => aa.ActivityId);
        }
    }
}