namespace BookingSystem.Models
{
    public class BookingSummary
    {
        public int BookingID { get; set; }
        public string? EventName { get; set; }
        public string? VenueName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? BookingStatus { get; set; }
        public int EventTypeID { get; set; } 
        public string EventTypeName { get; set; }
    }
}

//Kamil Mrzygód Azure for Developers Second Edition Implement rich Azure PaaS ecosystems using containers, serverless services, and storage solutions
//Gemini,2026

