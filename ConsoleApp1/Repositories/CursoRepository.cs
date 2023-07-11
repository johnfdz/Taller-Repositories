using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;

namespace ConsoleApp1.Repositories
{
    public class CursoRepository
    {
        public readonly SchoolContext _context = new SchoolContext();

        public async Task guardarCurso(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }
    }
}
