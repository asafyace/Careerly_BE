using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careerly.Models;

namespace Careerly.Repositories
{
    public class EducationRepository : IEducationRepository
    {
        private readonly ModelsContext _context;
        
        public EducationRepository(ModelsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Education>> Get()
        {
            return await _context.education.ToListAsync();
        }
        public async Task<Education> Create(Education education)
        {
            _context.education.Add(education);
            _ = await _context.SaveChangesAsync();
            return education;
        }

        public async Task Delete(int id)
        {
            var educationToDelete = await _context.education.FindAsync(id);
            _context.education.Remove(educationToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Education> Get(int id)
        {
            return await _context.education.FindAsync(id);
        }

        public async Task Update(Education education)
        {
            _context.Entry(education).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
