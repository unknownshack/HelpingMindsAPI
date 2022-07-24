using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingMinds.Models
{
    public class Event
    {
        [Key]
        public int eventId { get; set; }
        public string eventName { get; set; }
        public DateTime eventDate { get; set; }
    }
}
