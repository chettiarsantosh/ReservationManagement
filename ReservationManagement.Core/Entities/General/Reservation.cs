using ReservationManagement.Core.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManagement.Core.Entities.General
{
    [Table("Reservations")]
    public class Reservation : Base<int>
    {

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required]
        public int NumberOfGuests { get; set; }

        [Required]
        public string ClientName { get; set; } = string.Empty;
    }
}
