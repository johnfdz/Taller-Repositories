using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Repositories
{
    public class StudentAddressRepository
    {
        public readonly SchoolContext _context = new SchoolContext();

        public async Task guardarStudentAddress(StudentAddress studentAddress)
        {
            _context.StudentAddresses.Add(studentAddress);
            await _context.SaveChangesAsync();
        }

        public async Task<StudentAddress> buscarStudentAddress(int id)
        {
            var studentAddress = await _context.StudentAddresses
                .FindAsync(id);
            return studentAddress;
        }

        public async Task<List<StudentAddress>> buscarStudentAddresses()
        {
            var studentAddresses = await _context.StudentAddresses
                .Include(x => x.Student)
                .ToListAsync();
            return studentAddresses;
        }
    }
}
