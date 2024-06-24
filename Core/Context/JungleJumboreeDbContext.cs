using Core.Entites;
using Core.Entites.OrderEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Core.Context
{
    public class JungleJumboreeDbContext : IdentityDbContext<Users, IdentityRole,string>
    {
        public JungleJumboreeDbContext(DbContextOptions<JungleJumboreeDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }


        public DbSet<Order> Orders { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<TripsEvents> TripsEvents { get; set; }

        public DbSet<Requests> Requests { get; set; }

        public DbSet<NewStaff> NewStaff { get; set; }
        public DbSet<Location>Locations{ get; set; }

        public DbSet<CrewLocation> CrewLocations { get; set; }
        public DbSet<CrewSkills> CrewSkills { get; set; }
        public DbSet<Crew> Crews { get; set; }

        public DbSet<ChildMedicalConditions>ChildMedicalConditions { get; set; }
        public DbSet<ChildCamp>ChildCamps{ get; set; }
        public DbSet<ChildAllergis>ChildAllergis { get; set; }
        public DbSet<Child> Child {  get; set; }
       
        public DbSet<Camp>Camps { get; set; }


        public DbSet<BirthdayParty>BirthdayParty{get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<CrewLocation>()
            .HasOne(cl => cl.Location)
            .WithMany(l => l.CrewLocations)
            .HasForeignKey(cl => cl.LocationId)
            .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction
            modelBuilder.Entity<Camp>()
           .HasOne(c => c.Location)
           .WithOne(l => l.Camp)
           .HasForeignKey<Camp>(c => c.LocationId)
           .OnDelete(DeleteBehavior.NoAction);

            // Crew and Camp one-to-many relationship
            modelBuilder.Entity<Crew>()
                .HasOne(cr => cr.Camp)
                .WithMany(c => c.Crews)
                .HasForeignKey(cr => cr.CampId)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete

            modelBuilder.Entity<CrewLocation>()
                .HasOne(cl => cl.Crew)
                .WithMany(c => c.CrewLocations)
                .HasForeignKey(cl => cl.SSN)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Users>().HasOne(user => user.NewStaff).WithOne(s => s.User).HasForeignKey(typeof(NewStaff), "UserId");
            
            modelBuilder.Entity<Office>().HasBaseType<Location>();
            modelBuilder.Entity<School>().HasBaseType<Location>();

            modelBuilder.Entity<FullTimer>().HasBaseType<Crew>();
            modelBuilder.Entity<Freelance>().HasBaseType<Crew>();

            modelBuilder.Entity<Users>().OwnsOne(user => user.DOB, dob =>
            {
                dob.Property(d => d.Day).HasColumnName("DateOfBirth_Day");
                dob.Property(d => d.Month).HasColumnName("DateOfBirth_Month");
                dob.Property(d => d.Year).HasColumnName("DateOfBirth_Year");

                dob.WithOwner();
            });
            modelBuilder.Entity<Child>().OwnsOne(user => user.DOB, dob =>
            {
                dob.Property(d => d.Day).HasColumnName("DateOfBirth_Day");
                dob.Property(d => d.Month).HasColumnName("DateOfBirth_Month");
                dob.Property(d => d.Year).HasColumnName("DateOfBirth_Year");

                dob.WithOwner();
            });
            modelBuilder.Entity<NewStaff>().OwnsOne(user => user.DOB, dob =>
            {
                dob.Property(d => d.Day).HasColumnName("DateOfBirth_Day");
                dob.Property(d => d.Month).HasColumnName("DateOfBirth_Month");
                dob.Property(d => d.Year).HasColumnName("DateOfBirth_Year");

                dob.WithOwner();
            });

            
            modelBuilder.Entity<ChildCamp>().HasKey(x => new
            {
                x.CampId,
                x.ChildId
            });


            modelBuilder.Entity<ChildAllergis>().HasKey(x => new
            {
                x.ChildId,
                x.Allergies
            });

            modelBuilder.Entity<ChildMedicalConditions>().HasKey(x => new
            {
                x.ChildId,
                x.MedicalConditions
            });

            modelBuilder.Entity<CrewSkills>().HasKey(x => new
            {
                x.SSN,
                x.Skills
            });

            modelBuilder.Entity<NewStaff>().HasKey(x => new
            {
                x.UserId,
                x.RequestId
            });

            modelBuilder.Entity<CrewLocation>().HasKey(x => new
            {
                x.SSN,
                x.LocationId
            });

            modelBuilder.Entity<TripsEvents>().HasKey(x => new
            {
                x.UserId,
                x.RequestId
            });








            base.OnModelCreating(modelBuilder);
        }
    } 
}

 

