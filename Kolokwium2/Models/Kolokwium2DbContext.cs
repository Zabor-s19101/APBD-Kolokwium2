using System;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Models {
    public class Kolokwium2DbContext : DbContext {
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Organiser> Organiser { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Artist_Event> Artist_Event { get; set; }
        public DbSet<Event_Organiser> Event_Organiser { get; set; }

        protected Kolokwium2DbContext() {
        }

        public Kolokwium2DbContext(DbContextOptions options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artist>(builder => {
                builder.HasKey(e => e.IdArtist);
                builder.Property(e => e.IdArtist).ValueGeneratedOnAdd();
                builder.Property(e => e.Nickname).HasMaxLength(30).IsRequired();
                builder.HasData(
                    new Artist { IdArtist = 1, Nickname = "Zabor" },
                    new Artist { IdArtist = 2, Nickname = "Adaś" },
                    new Artist { IdArtist = 3, Nickname = "Krzychu" },
                    new Artist { IdArtist = 4, Nickname = "Ela" },
                    new Artist { IdArtist = 5, Nickname = "Eminem" }
                );
            });

            modelBuilder.Entity<Event>(builder => {
                builder.HasKey(e => e.IdEvent);
                builder.Property(e => e.IdEvent).ValueGeneratedOnAdd();
                builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
                builder.Property(e => e.StartDate).IsRequired();
                builder.Property(e => e.EndDate).IsRequired();
                builder.HasData(
                    new Event { IdEvent = 1, Name = "Połowinki", StartDate = DateTime.Parse("2020-06-19"), EndDate = DateTime.Parse("2020-06-19") },
                    new Event { IdEvent = 2, Name = "Woodstock", StartDate = DateTime.Parse("2021-03-19"), EndDate = DateTime.Parse("2021-06-19") },
                    new Event { IdEvent = 3, Name = "Wixapol", StartDate = DateTime.Parse("2019-06-01"), EndDate = DateTime.Parse("2019-06-19") },
                    new Event { IdEvent = 4, Name = "Skrra", StartDate = DateTime.Parse("2020-07-19"), EndDate = DateTime.Parse("2020-08-19") },
                    new Event { IdEvent = 5, Name = "Impreza", StartDate = DateTime.Parse("2020-07-19"), EndDate = DateTime.Parse("2020-08-19") }
                );
            });

            modelBuilder.Entity<Artist_Event>(builder => {
                builder.HasKey(e => new { e.IdEvent, e.IdArtist });
                builder.Property(e => e.PerformanceDate).IsRequired();
                builder.HasOne(e => e.IdEventNavigation)
                    .WithMany(ae => ae.ArtistEvents)
                    .HasForeignKey(e => e.IdEvent).IsRequired();
                builder.HasOne(a => a.IdArtistNavigation)
                    .WithMany(ae => ae.ArtistEvents)
                    .HasForeignKey(a => a.IdArtist).IsRequired();
                builder.HasData(
                    new Artist_Event { IdEvent = 3, IdArtist = 5, PerformanceDate = DateTime.Parse("2019-06-01") },
                    new Artist_Event { IdEvent = 4, IdArtist = 5, PerformanceDate = DateTime.Parse("2020-07-19") },
                    new Artist_Event { IdEvent = 5, IdArtist = 3, PerformanceDate = DateTime.Parse("2020-07-19") },
                    new Artist_Event { IdEvent = 5, IdArtist = 2, PerformanceDate = DateTime.Parse("2020-07-19") },
                    new Artist_Event { IdEvent = 1, IdArtist = 1, PerformanceDate = DateTime.Parse("2020-06-19") }
                );
            });

            modelBuilder.Entity<Organiser>(builder => {
                builder.HasKey(e => e.IdOrganiser);
                builder.Property(e => e.IdOrganiser).ValueGeneratedOnAdd();
                builder.Property(e => e.Name).HasMaxLength(30).IsRequired();
                builder.HasData(
                    new Organiser { IdOrganiser = 1, Name = "MTV" },
                    new Organiser { IdOrganiser = 2, Name = "Szkoła" },
                    new Organiser { IdOrganiser = 3, Name = "TVP" },
                    new Organiser { IdOrganiser = 4, Name = "TVN" },
                    new Organiser { IdOrganiser = 5, Name = "Wixapol" }
                );
            });

            modelBuilder.Entity<Event_Organiser>(builder => {
                builder.HasKey(e => new { e.IdEvent, e.IdOrganiser });
                builder.HasOne(e => e.IdEventNavigation)
                    .WithMany(eo => eo.EventOrganisers)
                    .HasForeignKey(e => e.IdEvent).IsRequired();
                builder.HasOne(o => o.IdOrganiserNavigation)
                    .WithMany(eo => eo.EventOrganisers)
                    .HasForeignKey(o => o.IdOrganiser).IsRequired();
                builder.HasData(
                    new Event_Organiser { IdEvent = 1, IdOrganiser = 2 },
                    new Event_Organiser { IdEvent = 2, IdOrganiser = 1 },
                    new Event_Organiser { IdEvent = 3, IdOrganiser = 5 },
                    new Event_Organiser { IdEvent = 4, IdOrganiser = 4 },
                    new Event_Organiser { IdEvent = 1, IdOrganiser = 3 }
                );
            });
        }
    }
}