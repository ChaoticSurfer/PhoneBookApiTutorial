using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private readonly PhoneBookDbContext _context;

        public PhoneBookController(PhoneBookDbContext context)
        {
            _context = context;
        }

        // GET: api/PhoneRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneRecord>>> GetPhoneRecords()
        {
            return await _context.PhoneRecords.ToListAsync();
        }

        // GET: api/PhoneRecords/{name}
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<PhoneRecord>>> GetPhoneRecordByName(string name)
        {
            var phoneRecords = await _context.PhoneRecords
                .Where(p => p.Name == name)
                .ToListAsync();

            if (phoneRecords == null || phoneRecords.Count == 0)
            {
                return NotFound();
            }

            return phoneRecords;
        }

        // POST: api/PhoneRecords
        [HttpPost]
        public async Task<ActionResult<PhoneRecord>> PostPhoneRecord(PhoneRecord phoneRecord)
        {
            _context.PhoneRecords.Add(phoneRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPhoneRecords), new { id = phoneRecord.Id }, phoneRecord);
        }

        // DELETE: api/PhoneRecords/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneRecord(int id)
        {
            var phoneRecord = await _context.PhoneRecords.FindAsync(id);
            if (phoneRecord == null)
            {
                return NotFound();
            }

            _context.PhoneRecords.Remove(phoneRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
