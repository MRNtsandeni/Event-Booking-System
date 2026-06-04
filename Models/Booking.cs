using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        public int VenueID { get; set; }
        public virtual Venue? Venue { get; set; }

        public int EventID { get; set; }
        public virtual Event? Event { get; set; }

        // Ensure this is the ONLY definition of EventTypeID
        public int EventTypeID { get; set; }
        public virtual EventType? EventType { get; set; }

        public string BookingStatus { get; set; } = "Confirmed";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

//Kamil Mrzygód Azure for Developers Second Edition Implement rich Azure PaaS ecosystems using containers, serverless services, and storage solutions
