using System.Linq;
using Kolokwium2.DTOs.Requests;
using Kolokwium2.DTOs.Responses;
using Kolokwium2.Exceptions;
using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Services {
    public class EfDbService : IDbService {
        private readonly Kolokwium2DbContext _context;

        public EfDbService(Kolokwium2DbContext context) {
            _context = context;
        }

        public GetArtistResponse GetArtist(int id) {
            var artist = _context.Artist
                .Include(a => a.ArtistEvents)
                .SingleOrDefault(a => a.IdArtist == id);
            if (artist == null) {
                throw new SomethingNotExists("Nie ma takiego artysty");
            }
            return new GetArtistResponse {
                IdArtist = artist.IdArtist,
                Nickname = artist.Nickname,
                Events = artist.ArtistEvents.Join(_context.Event, ae => ae.IdEvent, e => e.IdEvent, (ae, e) => new {
                    ae.PerformanceDate,
                    e.Name,
                    e.StartDate,
                    e.EndDate
                }).OrderByDescending(e => e.StartDate).ToList() // i really forgot at first about sort
            };
        }

        public void UpdateArtistPerformanceDate(int idArtist, int idEvent, UpdateArtistPerformanceDateRequest request) {
            var artist = _context.Artist
                .Include(a => a.ArtistEvents)
                .SingleOrDefault(a => a.IdArtist == idArtist);
            if (artist != null) {
                foreach (var ae in artist.ArtistEvents) {
                    var e = artist.ArtistEvents.Single(aee => aee.IdEvent == idEvent);
                    if (e == null) {
                        throw new SomethingNotExists("Taki event nie istnieje");
                    } else {
                        //TODO... not enough time
                    }
                }
            } else {
                throw new SomethingNotExists("Taki artysta nie istnieje!");
            }
        }
    }
}