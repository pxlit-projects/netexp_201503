using BrewzDomain.Classes;
using System.Data.Entity;

namespace BrewzDomain.DataLayer
{
    public class BrewzContext:DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Brewer> brewers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.userId).HasColumnName("user_id");
            modelBuilder.Entity<User>().Property(u => u.firstName).HasColumnName("first_name");
            modelBuilder.Entity<User>().Property(u => u.lastName).HasColumnName("last_name");

            modelBuilder.Entity<Review>().Property(r => r.reviewId).HasColumnName("review_id");
            modelBuilder.Entity<Review>().Property(r => r.reviewComment).HasColumnName("review_comment");
            modelBuilder.Entity<Review>().Property(r => r.reviewDate).HasColumnName("review_date");
            modelBuilder.Entity<Review>().Property(r => r.reviewScore).HasColumnName("review_score");

            modelBuilder.Entity<Address>().Property(a => a.addressId).HasColumnName("address_id");
            modelBuilder.Entity<Address>().Property(a => a.houseNumber).HasColumnName("house_number");
            modelBuilder.Entity<Address>().Property(a => a.postalCode).HasColumnName("postal_code");

            modelBuilder.Entity<Communications>().Property(c => c.communicationsId).HasColumnName("communications_id");

            modelBuilder.Entity<Brewer>().Property(b => b.brewerId).HasColumnName("brewer_id");
            modelBuilder.Entity<Brewer>().Property(b => b.descriptionNl).HasColumnName("description_nl");
            modelBuilder.Entity<Brewer>().Property(b => b.descriptionEn).HasColumnName("description_en");
            modelBuilder.Entity<Brewer>().Property(b => b.openingTimesNl).HasColumnName("opening_times_nl");
            modelBuilder.Entity<Brewer>().Property(b => b.openingTimesEn).HasColumnName("opening_times_en");
            modelBuilder.Entity<Brewer>().Property(b => b.individualsJoinGroupsNl).HasColumnName("individuals_join_groups_nl");
            modelBuilder.Entity<Brewer>().Property(b => b.individualsJoinGroupsEn).HasColumnName("individuals_join_groups_en");
            modelBuilder.Entity<Brewer>().Property(b => b.imagesUrl).HasColumnName("images_url");
            modelBuilder.Entity<Brewer>().Property(b => b.videoUrl).HasColumnName("video_url");
            modelBuilder.Entity<Brewer>().Property(b => b.topFermentation).HasColumnName("top_fermentation");
            modelBuilder.Entity<Brewer>().Property(b => b.bottomFermentation).HasColumnName("bottom_fermentation");
            modelBuilder.Entity<Brewer>().Property(b => b.spontaneousFermentation).HasColumnName("spontaneous_fermentation");
            modelBuilder.Entity<Brewer>().Property(b => b.mixedFermentation).HasColumnName("mixed_fermentation");
            
        }

        public System.Data.Entity.DbSet<BrewzDomain.Classes.Review> Reviews { get; set; }
    }

   
}
