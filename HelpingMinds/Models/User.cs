using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingMinds.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }

    }
}
