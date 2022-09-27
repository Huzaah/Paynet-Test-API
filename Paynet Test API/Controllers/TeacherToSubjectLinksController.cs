using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Paynet_Test_API;

namespace Paynet_Test_API.Controllers
{
    [Route("Links")]
    [ApiController]
    public class TeacherToSubjectLinksController : ControllerBase
    {
        private readonly SchoolContext _context = Program.db;

        // GET: TeacherToSubjectLinks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherToSubjectLink>>> GetTeacherToSubjectLinks()
        {
            return await _context.TeacherToSubjectLinks.ToListAsync();
        }

        // GET: TeacherToSubjectLinks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherToSubjectLink>> GetTeacherToSubjectLink(int id)
        {
            var teacherToSubjectLink = await _context.TeacherToSubjectLinks.FindAsync(id);

            if (teacherToSubjectLink == null)
            {
                return NotFound();
            }

            return teacherToSubjectLink;
        }

        // PUT: TeacherToSubjectLinks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacherToSubjectLink(int id, TeacherToSubjectLink teacherToSubjectLink)
        {
            if (id != teacherToSubjectLink.LinkId)
            {
                return BadRequest();
            }

            _context.Entry(teacherToSubjectLink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherToSubjectLinkExists(id))
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

        // POST: TeacherToSubjectLinks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeacherToSubjectLink>> PostTeacherToSubjectLink(TeacherToSubjectLink teacherToSubjectLink)
        {
            _context.TeacherToSubjectLinks.Add(teacherToSubjectLink);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TeacherToSubjectLinkExists(teacherToSubjectLink.LinkId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTeacherToSubjectLink", new { id = teacherToSubjectLink.LinkId }, teacherToSubjectLink);
        }

        // DELETE: TeacherToSubjectLinks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacherToSubjectLink(int id)
        {
            var teacherToSubjectLink = await _context.TeacherToSubjectLinks.FindAsync(id);
            if (teacherToSubjectLink == null)
            {
                return NotFound();
            }

            _context.TeacherToSubjectLinks.Remove(teacherToSubjectLink);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeacherToSubjectLinkExists(int id)
        {
            return _context.TeacherToSubjectLinks.Any(e => e.LinkId == id);
        }
    }
}
