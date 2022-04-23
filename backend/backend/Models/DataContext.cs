using Microsoft.EntityFrameworkCore;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace backend.Models
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<SalesArticle> SalesArticles { get; set; } = null!;
        public DbSet<Location> Locations { get; set; } = null!;

        public DataContext(DbContextOptions<DataContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();


            seedLocations(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .Build().GetSection("ConnectionStrings")["ebay-backend"];

            optionsBuilder.UseNpgsql(connectionString)
                .UseLowerCaseNamingConvention();
            
        }

        private void seedLocations(ModelBuilder modelBuilder)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory() + "/assets/finlandCities.json");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string content = String.Empty;

            using (StreamReader r = new StreamReader(path, Encoding.GetEncoding(1252)))
            {
                content = r.ReadToEnd();
            }

            List<Location> locations = JsonConvert.DeserializeObject<List<Location>>(content)!;

            for (int i = 1; i < locations.Count; i++)
            {
                Location location = locations[i];
                location.Id = i;
                modelBuilder.Entity<Location>().HasData(location);
            }
        }
    }
}
