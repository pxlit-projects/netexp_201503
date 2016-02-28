using BrewzDomain.Classes;
using System.Data.Entity;

namespace BrewzDomain.DataLayer
{
    public class BrewzContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Brewer> Brewers { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.UserId).HasColumnName("user_id");
            modelBuilder.Entity<User>().Property(u => u.FirstName).HasColumnName("first_name");
            modelBuilder.Entity<User>().Property(u => u.LastName).HasColumnName("last_name");

            modelBuilder.Entity<Review>().Property(r => r.ReviewId).HasColumnName("review_id");
            modelBuilder.Entity<Review>().Property(r => r.ReviewComment).HasColumnName("review_comment");
            modelBuilder.Entity<Review>().Property(r => r.ReviewDate).HasColumnName("review_date");
            modelBuilder.Entity<Review>().Property(r => r.ReviewScore).HasColumnName("review_score");

            modelBuilder.Entity<Address>().Property(a => a.AddressId).HasColumnName("address_id");
            modelBuilder.Entity<Address>().Property(a => a.HouseNumber).HasColumnName("house_number");
            modelBuilder.Entity<Address>().Property(a => a.PostalCode).HasColumnName("postal_code");

            modelBuilder.Entity<Communications>().Property(c => c.CommunicationsId).HasColumnName("communications_id");

            modelBuilder.Entity<Brewer>().Property(b => b.BrewerId).HasColumnName("brewer_id");
            modelBuilder.Entity<Brewer>().Property(b => b.DescriptionNl).HasColumnName("description_nl");
            modelBuilder.Entity<Brewer>().Property(b => b.DescriptionEn).HasColumnName("description_en");
            modelBuilder.Entity<Brewer>().Property(b => b.OpeningTimesNl).HasColumnName("opening_times_nl");
            modelBuilder.Entity<Brewer>().Property(b => b.OpeningTimesEn).HasColumnName("opening_times_en");
            modelBuilder.Entity<Brewer>().Property(b => b.IndividualsJoinGroupsNl).HasColumnName("individuals_join_groups_nl");
            modelBuilder.Entity<Brewer>().Property(b => b.IndividualsJoinGroupsEn).HasColumnName("individuals_join_groups_en");
            modelBuilder.Entity<Brewer>().Property(b => b.ImagesUrl).HasColumnName("images_url");
            modelBuilder.Entity<Brewer>().Property(b => b.VideoUrl).HasColumnName("video_url");
            modelBuilder.Entity<Brewer>().Property(b => b.TopFermentation).HasColumnName("top_fermentation");
            modelBuilder.Entity<Brewer>().Property(b => b.BottomFermentation).HasColumnName("bottom_fermentation");
            modelBuilder.Entity<Brewer>().Property(b => b.SpontaneousFermentation).HasColumnName("spontaneous_fermentation");
            modelBuilder.Entity<Brewer>().Property(b => b.MixedFermentation).HasColumnName("mixed_fermentation");
            
        }

    }

   
}
