using System;
using System.Collections.Generic;

namespace EventEase.Models;

public partial class EventL
{
    public int EventId { get; set; }

    public int? VenueId { get; set; }

    public string EventName { get; set; } = null!;

    public DateTime EventDate { get; set; }

    public string? EventDescription { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Venue? Venue { get; set; }
}
