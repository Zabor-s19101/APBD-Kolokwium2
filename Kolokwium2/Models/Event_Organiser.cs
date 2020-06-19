namespace Kolokwium2.Models {
    public class Event_Organiser {
        public int IdEvent { get; set; }
        public virtual Event IdEventNavigation { get; set; }
        public int IdOrganiser { get; set; }
        public virtual Organiser IdOrganiserNavigation { get; set; }
    }
}