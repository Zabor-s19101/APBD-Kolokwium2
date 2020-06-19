using System;

namespace Kolokwium2.Models {
    public class Artist_Event {
        public int IdEvent { get; set; }
        public virtual Event IdEventNavigation { get; set; }
        public int IdArtist { get; set; }
        public virtual Artist IdArtistNavigation { get; set; }
        public DateTime PerformanceDate { get; set; }
    }
}