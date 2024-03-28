using ReservationManagement.Core.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReservationManagement.Core.Entities.Business
{
    public class ReservationViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Reservation Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Reservation Date")]
        [ValidDate(ErrorMessage = "Please enter a valid date for Reservation Date")]
        public DateTime ReservationDate { get; set; }

        [Required(ErrorMessage = "Number of Guests is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of Guests must be greater than 0")]
        [Display(Name = "Number of Guests")]
        public int NumberOfGuests { get; set; }

        [Required(ErrorMessage = "Client Name is required")]
        [StringLength(100, ErrorMessage = "Client Name cannot exceed 100 characters")]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; } = string.Empty;
    }
}
