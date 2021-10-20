using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexRatingSystem.PublishedLanguage.Events
{
    public class RatingUpdated : INotification
    {
        public decimal Rating { get; set; }
    }
}
