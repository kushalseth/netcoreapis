using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Hmsapp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationOperator class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationOperator : IdentityUser
    {
        public ApplicationOperator() {
            //ApplicationClients = new ApplicationClient();
           // Professtionals = new Professtional();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationOperator> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            // Add custom user claims here
           
            userIdentity.AddClaim(new Claim("CreatedOn", Convert.ToString(this.CreatedOn)));
            userIdentity.AddClaim(new Claim(ClaimTypes.Email, Convert.ToString(this.Email)));
            return userIdentity;
        }
        

        public string RoleCD { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("ApplicationClientId")]
        public virtual ApplicationClient ApplicationClients { get; set; }
        public Guid ApplicationClientId { set; get; } 

        [ForeignKey("ProfesstionalId")]
        public virtual Professtional Professtionals { get; set; }
        public Guid ProfesstionalId { set; get; }

        //public Guid Id { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationOperator>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<ApplicationClient> ApplicationClients { get; set; }

        public DbSet<Professtional> Professtionals { get; set; }

        public DbSet<Appointments> Appointments { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<PracticeTimming> PracticeTimmings { get; set; }

        public DbSet<PracticeTimmingDay> PracticeTimmingDays { get; set; }

        // public DbSet<ApplicationOperator> ApplicationOperators { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationOperator>().Ignore(x => x.LockoutEnabled)
                .Ignore(x => x.LockoutEndDateUtc);
            modelBuilder.Entity<ApplicationOperator>().ToTable("ApplicationOperators");

            var applicationClient = modelBuilder.Entity<ApplicationClient>();
            applicationClient.ToTable("ApplicationClients");
            //applicationClient.HasKey(x => x.Id);

            var professtional = modelBuilder.Entity<Professtional>();
            professtional.ToTable("Professtionals");
            //professtional.HasKey(x => x.Id);

            var location = modelBuilder.Entity<Location>();
            location.ToTable("Locations");

            var practiceTimming = modelBuilder.Entity<PracticeTimming>();
            location.ToTable("PracticeTimmings");

            var day = modelBuilder.Entity<Day>();
            location.ToTable("Days");

            var practiceTimmingDays = modelBuilder.Entity<PracticeTimmingDay>();
            location.ToTable("PracticeTimmingDays");


            // user.HasKey(x => x.ApplicationClients.Id);
            //user.Property(x => x.OperatorName).IsRequired().HasMaxLength(256)
            //    .HasColumnAnnotation("Index", new IndexAnnotation(
            //        new IndexAttribute("OperatorNameIndex")));



            modelBuilder.Entity<IdentityRole>().ToTable("Role").HasKey(x => x.Id);
            modelBuilder.Entity<IdentityUserRole>().ToTable("ApplicationClientRole").HasKey(x => x.RoleId).HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityUserClaim>().ToTable("ApplicationClientClaim").HasKey(x => x.Id);
            modelBuilder.Entity<IdentityUserLogin>().ToTable("ApplicationClientLogin").HasKey(x => x.ProviderKey).HasKey(x => x.UserId).HasKey(x => x.LoginProvider);
            modelBuilder.Entity<Appointments>().ToTable("Appointment").HasKey(x => x.AppointmentId);
            modelBuilder.Entity<Location>().ToTable("Locations").HasKey(x => x.LocationId);
            modelBuilder.Entity<PracticeTimming>().ToTable("PracticeTimmings").HasKey(x => x.PracticeTimmingId);
            modelBuilder.Entity<Day>().ToTable("Days").HasKey(x => x.DayId);
            modelBuilder.Entity<PracticeTimmingDay>().ToTable("PracticeTimmingDays").HasKey(x => x.PracticeTimmingDayId);
            //modelBuilder.Entity<>
            //user.Has(x => x.ApplicationClients).WithRequired().HasForeignKey(x => x.);
            // base.OnModelCreating(modelBuilder);
        }
    }
}