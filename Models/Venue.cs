using System;
using System.Collections.Generic;

namespace EventEase.Models;

public partial class Venue
{
    public int VenueId { get; set; }

    public string VenueName { get; set; } = null!;

    public string VenueLocation { get; set; } = null!;

    public int Capacity { get; set; }

    public string ImageUrl { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<EventL> EventLs { get; set; } = new List<EventL>();

    public Venue()
    {
        ImageUrl = "https://s3.amazonaws.com/content.eventease.com/images/logo-square-white.jpg"; // Default image URL
    }
}
