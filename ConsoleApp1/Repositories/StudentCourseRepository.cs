using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;

namespace ConsoleApp1.Repositories
{
    public class StudentCourseRepository
    {
        public readonly SchoolContext _context = new SchoolContext();

        public async Task guardarStudentCourse(StudentCourse studentCourse)
        {
            _context.StudentCourses.Add(studentCourse);
            await _context.SaveChangesAsync();
        }
    }
}
