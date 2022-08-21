using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingMinds.Models
{
    public class Reminder
    {
        [Key]
        public int reminderId { get; set; }
        public int? eventId { get; set; }

        public DateTime? reminderDate { get; set; }
        public int? priority { get; set; }
        public int? repeat { get; set; }

        public int? numOfTimeRepeat { get; set; }
        public string? uuid { get; set; }
        public bool? completed { get; set; }
        public int? userId { get; set; }
        public bool? actualRepeat { get; set; }
        public string? purpose { get; set; }
        public bool? isonoroff { get; set; }
        public string nonEventNote { get; set; }
    }
}
