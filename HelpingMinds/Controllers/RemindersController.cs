using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpingMinds.Models;
using System.Net;

namespace HelpingMinds
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemindersController : ControllerBase
    {
        private readonly HelpingMindsDataContext _context;

        public RemindersController(HelpingMindsDataContext context)
        {
            _context = context;
        }

        // GET: api/Reminders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reminder>>> GetReminder()
        {
            return await _context.Reminder.ToListAsync();
        }

        // GET: api/Reminders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reminder>> GetReminder(int id)
        {
            var reminder = await _context.Reminder.FindAsync(id);

            if (reminder == null)
            {
                return NotFound();
            }

            return reminder;
        }

        // PUT: api/Reminders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReminder(int id, Reminder reminder)
        {
            if (id != reminder.reminderId)
            {
                return BadRequest();
            }

            _context.Entry(reminder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReminderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        
        [HttpPost("del/{uuid}")]
        public IActionResult delReminder(string uuid)
        {
            if (String.IsNullOrEmpty(uuid))
            {
                return new ContentResult
                {
                    Content = $"Error: String is empty or null",
                    ContentType = "text/plain",
                    // change to whatever status code you want to send out
                    StatusCode = (int?)HttpStatusCode.BadRequest
                };
            }
            var reminder = _context.Reminder.Where(x => x.uuid == uuid).FirstOrDefault();
            if (reminder == null)
            {
                return new ContentResult
                {
                    Content = $"Error: UUID is null",
                    ContentType = "text/plain",
                    // change to whatever status code you want to send out
                    StatusCode = (int?)HttpStatusCode.BadRequest
                };
            }

            _context.Reminder.Remove(reminder);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("comp/{uuid}")]
        public IActionResult completeReminder(string uuid)
        {
            var reminder = _context.Reminder.Where(x => x.uuid == uuid).FirstOrDefault();
            if (reminder == null | String.IsNullOrEmpty(uuid))
            {
                return new ContentResult
                {
                    Content = $"Error: String is empty or null | cannot find the uuid",
                    ContentType = "text/plain",
                    // change to whatever status code you want to send out
                    StatusCode = (int?)HttpStatusCode.BadRequest
                };
            }

            reminder.completed = true;
            _context.SaveChanges();
            return Ok();
        }


        // POST: api/Reminders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reminder>> PostReminder(Reminder reminder)
        {
            _context.Reminder.Add(reminder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReminder", new { id = reminder.reminderId }, reminder);
        }

        // DELETE: api/Reminders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReminder(int id)
        {
            var reminder = await _context.Reminder.FindAsync(id);
            if (reminder == null)
            {
                return NotFound();
            }

            _context.Reminder.Remove(reminder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("eventId/{id}")]
        public List<Reminder> GetReminderByEventId(int id)
        {
            return _context.Reminder.Where(x => x.eventId == id).ToList();
        }

    private bool ReminderExists(int id)
        {
            return _context.Reminder.Any(e => e.reminderId == id);
        }
    }
}
