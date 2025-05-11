using System;
using System.Collections.Generic;

namespace EventEase.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int? VenueId { get; set; }

    public int? EventId { get; set; }

    public DateTime BookingDate { get; set; }

    public virtual EventL? Event { get; set; }

    public virtual Venue? Venue { get; set; }
}
