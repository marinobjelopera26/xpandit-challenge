using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using XpandIT.Challenge.DataLayer.Entities;

namespace XpandIT.Challenge.DataLayer
{
    public class XpandITDbContext : IdentityDbContext
    {
        public XpandITDbContext(DbContextOptions<XpandITDbContext> options)
            : base(options)
        {
        }

        public DbSet<CBK_PhoneNumberType>? PhoneNumberTypes { get; set; }
        public DbSet<PhoneNumber>? PhoneNumbers { get; set; }
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<ContactPhoneNumber>? ContactPhoneNumbers { get; set; }
        public DbSet<ContactGroup>? ContactGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CBK_PhoneNumberType>().ToTable("CBK_PhoneNumberType");
            builder.Entity<PhoneNumber>().ToTable("PhoneNumber");
            builder.Entity<PhoneNumber>();
 
            builder.Entity<Contact>().ToTable("Contact");

            builder.Entity<ContactPhoneNumber>()
                .ToTable("ContactPhoneNumber")
                .HasKey(x => new { x.ContactId, x.PhoneNumberId });

            builder.Entity<ContactPhoneNumber>()
                .HasOne(x => x.Contact)
                .WithMany(x => x.PhoneNumbers)
                .HasForeignKey(x => x.ContactId);

            builder.Entity<ContactPhoneNumber>()
                .HasOne(x => x.PhoneNumber)
                .WithMany(x => x.Contacts)
                .HasForeignKey(x => x.PhoneNumberId);

            builder.Entity<ContactGroup>().ToTable("ContactGroup");

            builder.Entity<ContactGroupContact>()
                .ToTable("ContactGroupContact")
                .HasKey(x => new { x.ContactGroupId, x.ContactId });

            builder.Entity<ContactGroupContact>()
                .HasOne(x => x.ContactGroup)
                .WithMany(x => x.Contacts)
                .HasForeignKey(x => x.ContactGroupId);

            builder.Entity<ContactGroupContact>()
                .HasOne(x => x.Contact)
                .WithMany(x => x.ContactGroups)
                .HasForeignKey(x => x.ContactId);
        }
    }
}
