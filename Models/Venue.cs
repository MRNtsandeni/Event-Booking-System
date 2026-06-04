using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models
{
    public class Venue
    {
        [Key]// used to show or identify the primary key 
        public int VenueID { get; set; } // read and write data from one place to another

        [Required]//basically "not null"
        public required string VenueName { get; set; }

        [Required]
        public required string Location { get; set; }

        public int Capacity { get; set; }

      
        public string? ImageUrl { get; set; }
    }
}

//Kamil Mrzygód Azure for Developers Second Edition Implement rich Azure PaaS ecosystems using containers, serverless services, and storage solutions
