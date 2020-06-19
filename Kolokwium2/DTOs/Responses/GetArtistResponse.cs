using System.Collections;

namespace Kolokwium2.DTOs.Responses {
    public class GetArtistResponse {
        public int IdArtist { get; set; }
        public string Nickname { get; set; }
        public IList Events { get; set; }
    }
}