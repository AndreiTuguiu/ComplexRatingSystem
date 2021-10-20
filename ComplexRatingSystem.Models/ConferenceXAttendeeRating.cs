using System;
using System.Collections.Generic;

#nullable disable

namespace ComplexRatingSystem.Models
{
    public partial class ConferenceXattendeeRating
    {
        public int ExternalId { get; set; }
        public int UserId { get; set; }
        public string Category { get; set; }
        public decimal Rating { get; set; }
    }
}
