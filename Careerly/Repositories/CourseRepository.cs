using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careerly.Models;

namespace Careerly.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ModelsContext _context;
        
        public CourseRepository(ModelsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> Get()
        {
            return await _context.course.ToListAsync();
        }
        public async Task<Course> Create(Course course)
        {
            _context.course.Add(course);
            _ = await _context.SaveChangesAsync();
            return course;
        }

        public async Task Delete(int id)
        {
            var courseToDelete = await _context.course.FindAsync(id);
            _context.course.Remove(courseToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Course> Get(int id)
        {
            return await _context.course.FindAsync(id);
        }

        public async Task Update(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
