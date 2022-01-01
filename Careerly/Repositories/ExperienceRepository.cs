using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careerly.Models;

namespace Careerly.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly ModelsContext _context;
        

        public ExperienceRepository(ModelsContext context)
        {
            _context = context;
        }
        public async Task<Experience> Create(Experience experience)
        {
            _context.experience.Add(experience);
            _ = await _context.SaveChangesAsync();
            return experience;
        }

        public async Task Delete(int id)
        {
            var experienceToDelete = await _context.experience.FindAsync(id);
            _context.experience.Remove(experienceToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Experience>> Get()
        {
            return await _context.experience.ToListAsync();
        }

        public async Task<Experience> Get(int id)
        {
            return await _context.experience.FindAsync(id);
        }

        public async Task Update(Experience experience)
        {
            _context.Entry(experience).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
