using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Paynet_Test_API;

namespace Paynet_Test_API
{
    [Route("Subjects")]
    [ApiController]
    public class SchoolSubjectsController : ControllerBase
    {
        private readonly SchoolContext _context = Program.db;

        // GET: api/SchoolSubjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolSubject>>> GetSchoolSubjects()
        {
            return await _context.SchoolSubjects.ToListAsync();
        }

        // GET: api/SchoolSubjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolSubject>> GetSchoolSubject(int id)
        {
            var schoolSubject = await _context.SchoolSubjects.FindAsync(id);

            if (schoolSubject == null)
            {
                return NotFound();
            }

            return schoolSubject;
        }

        // PUT: Subjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchoolSubject(int id, SchoolSubject schoolSubject)
        {
            if (id != schoolSubject.SubjectId)
            {
                return BadRequest();
            }

            _context.Entry(schoolSubject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolSubjectExists(id))
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

        // POST: api/SchoolSubjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SchoolSubject>> PostSchoolSubject(SchoolSubject schoolSubject)
        {
            _context.SchoolSubjects.Add(schoolSubject);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SchoolSubjectExists(schoolSubject.SubjectId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSchoolSubject", new { id = schoolSubject.SubjectId }, schoolSubject);
        }

        // DELETE: api/SchoolSubjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchoolSubject(int id)
        {
            var schoolSubject = await _context.SchoolSubjects.FindAsync(id);
            if (schoolSubject == null)
            {
                return NotFound();
            }

            _context.SchoolSubjects.Remove(schoolSubject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SchoolSubjectExists(int id)
        {
            return _context.SchoolSubjects.Any(e => e.SubjectId == id);
        }
    }
}
