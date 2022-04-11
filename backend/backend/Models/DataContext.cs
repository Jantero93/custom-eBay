using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace backend.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();

            var path = Path.Combine(Directory.GetCurrentDirectory() + "/assets/finlandCities.json");
            string json = System.IO.File.ReadAllText(path, System.Text.Encoding.Default);
            List<Location> locations = JsonConvert.DeserializeObject<List<Location>>(json);
   
            for (int i = 1; i < locations.Count; i++)
            {
                Location location = locations[i];
                location.Id = i;
                modelBuilder.Entity<Location>().HasData(location);
            }
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<SalesArticle> SalesArticles { get; set; } = null!;

        public DbSet<Location> Locations { get; set; } = null!;
    }
}
