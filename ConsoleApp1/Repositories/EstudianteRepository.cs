using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Repositories
{
    public class EstudianteRepository
    {
        private readonly SchoolContext _context= new SchoolContext();

        
        public async Task guardarEstudiante(Student student)
        {
                       
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
 
        }

        public async Task<Student> buscarEstudiante(int id)
        {
            var student = await _context.Students.FindAsync(id);
            return student;
        }

        public async Task<List<Student>> buscarEstudiantes()
        {
            var students = await _context.Students.ToListAsync();
            return students;
        }

        public async Task modificarEstudiante(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task eliminarEstudiante(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
