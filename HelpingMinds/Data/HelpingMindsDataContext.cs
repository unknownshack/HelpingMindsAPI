using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HelpingMinds.Models;

    public class HelpingMindsDataContext : DbContext
    {
        public HelpingMindsDataContext (DbContextOptions<HelpingMindsDataContext> options)
            : base(options)
        {
        }

        public DbSet<HelpingMinds.Models.User> Users { get; set; }

        public DbSet<HelpingMinds.Models.Event> Events { get; set; }

        public DbSet<HelpingMinds.Models.Reminder> Reminder { get; set; }
    }
