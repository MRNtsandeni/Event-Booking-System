using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models
{

    public class Event
    {
        [Key]// used to show or identify the primary key
        public int EventID { get; set; }// read and write data from one place to another

        [Required]//basically "not null"
        public required string EventName { get; set; } = string.Empty;

        [Required]
        public required string Description { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan EventTime { get; set; }

        public string? ImageUrl { get; set; }//can be left empty 
        public int EventTypeID { get; set; }
        public EventType? EventType { get; set; }//can be left empty 
    }
}
//Kamil Mrzygód Azure for Developers Second Edition Implement rich Azure PaaS ecosystems using containers, serverless services, and storage solutions
//Gemini, 2026
//Implementing search functionality in asp net mvc - A guide by Computer Experts - https://youtu.be/DsRaOeTVr94?si=AeyWk9_kwAtUbI7b