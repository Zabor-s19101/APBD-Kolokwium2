using System.Collections.Generic;

namespace Kolokwium2.Models {
    public class Artist {
        public int IdArtist { get; set; }
        public string Nickname { get; set; }
        public ICollection<Artist_Event> ArtistEvents { get; set; }
    }
}