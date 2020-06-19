using Kolokwium2.DTOs.Requests;
using Kolokwium2.DTOs.Responses;

namespace Kolokwium2.Services {
    public interface IDbService {
        GetArtistResponse GetArtist(int id);
        void UpdateArtistPerformanceDate(int idArtist, int idEvent, UpdateArtistPerformanceDateRequest request);
    }
}