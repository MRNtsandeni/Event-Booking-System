using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.ViewModels
{
    public class BookingViewModel
    {
        public int BookingID { get; set; }

        //telling browser that it only needs hour and miutes not seconds
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]//Gemini, 2026
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public int SelectedVenueID { get; set; }
        public int SelectedEventID { get; set; }
        public int SelectedEventTypeID { get; set; }
     

        // Used to populate the dropdowns using SelectList
        public IEnumerable<SelectListItem>? Venues { get; set; }
        public IEnumerable<SelectListItem>? Events { get; set; }
        public IEnumerable<SelectListItem>? EventTypes { get; set; }

    }

}
//Kamil Mrzygód Azure for Developers Second Edition Implement rich Azure PaaS ecosystems using containers, serverless services, and storage solutions
//Gemini, 2026