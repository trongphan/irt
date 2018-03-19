using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ESIRT.Web.Models;
using ESIRT.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESIRT.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.ApplyConfiguration(new SiteConfig());
            builder.ApplyConfiguration(new LoggedEventConfig());
        }

        public DbSet<Site> Sites { get; set; }
        public DbSet<LoggedEvent> LoggedEvents { get; set; }
    }

    public class SiteConfig : IEntityTypeConfiguration<Site>
    {
        //public SiteConfig(EntityTypeBuilder<Site> builder)
        //{
        //    builder.Property(s => s.Name)
        //           .HasMaxLength(100);
                                
        //}

        public void Configure(EntityTypeBuilder<Site> builder)
        {
            builder.ToTable("Site");

            builder.Property(s => s.Name)
                  .HasMaxLength(100);

            builder.Property<int>("ABC")
                    .HasField("_Abc")
                    .IsRequired();

            builder.Property<DateTime>("CreatedDate")
                   .HasField("_createdDate");                   
        }
    }

    public class LoggedEventConfig : IEntityTypeConfiguration<LoggedEvent>
    {       
        public void Configure(EntityTypeBuilder<LoggedEvent> builder)
        {
            builder.ToTable("LoggedEvent");

            builder.Property(l => l.Action)
                  .HasMaxLength(100);

            builder.Property(l => l.AggregateId)                    
                    .IsRequired();            
        }
    }
}
