using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Paynet_Test_API
{
    [Route("Teachers")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly SchoolContext _context = Program.db;

        [HttpGet]
        public IEnumerable<Teacher> Get()
        {
            return _context.Teachers;
        }

        [HttpGet("{id}")]
        public Teacher Get(int id)
        {
            var ret = _context.Teachers.FirstOrDefault(t => t.TeacherId == id);
            return ret;
        }

        [HttpPost]
        public IActionResult Post(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Post), new { id = teacher.TeacherId }, teacher);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Teacher teacher)
        {
            try
            {
                var query = _context.Teachers.Where(t => t.TeacherId == teacher.TeacherId);

                foreach(Teacher t in query)
                {
                    t.TeacherName = teacher.TeacherName;
                    t.TeacherLname = teacher.TeacherLname;
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound();
            }
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var teachToRemove = _context.Teachers.Where(t => t.TeacherId == id).FirstOrDefault();
            _context.Remove(teachToRemove);
            _context.SaveChanges();
        }
    }
}
