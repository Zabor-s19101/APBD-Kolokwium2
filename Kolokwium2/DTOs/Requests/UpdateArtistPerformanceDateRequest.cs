using System;

namespace Kolokwium2.DTOs.Requests {
    public class UpdateArtistPerformanceDateRequest {
        public int IdArtist { get; set; }
        public int IdEvent { get; set; }
        public DateTime PerformanceDate { get; set; }
    }
}