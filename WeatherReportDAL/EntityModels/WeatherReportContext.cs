using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WeatherReportModel;

namespace WeatherReportDAL.EntityModels
{
    public class WeatherReportContext : DbContext
    {
        public DbSet<WeatherReport> WeatherReports { get; set; }
        public DbSet<City> Cities { get; set; }
        public WeatherReportContext(DbContextOptions<WeatherReportContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherReport>(entity =>
            {
                entity.Property(e => e.Coordinates).HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Coordinates>(v));

                entity.Property(e => e.WeatherData).HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<WeatherData>(v));

                entity.Property(e => e.WeatherDescription).HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<WeatherDescription>(v));
                entity.HasMany(e => e.Cities).WithMany(y => y.WeatherReports).UsingEntity(c => c.ToTable("CitiesReports"));
            });
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Cod).HasMaxLength(255);
            });
        }
    }
}
