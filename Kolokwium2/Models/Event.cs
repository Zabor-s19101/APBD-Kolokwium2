using System;
using System.Collections.Generic;

namespace Kolokwium2.Models {
    public class Event {
        public int IdEvent { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Artist_Event> ArtistEvents { get; set; }
        public ICollection<Event_Organiser> EventOrganisers { get; set; }
    }
}