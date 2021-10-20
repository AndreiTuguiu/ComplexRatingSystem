using System;
using System.Collections.Generic;

#nullable disable

namespace ComplexRatingSystem.Models
{
    public partial class ConferenceRating
    {
        public int ExternalId { get; set; }
        public decimal Avgrating { get; set; }
    }
}
