using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careerly.Models;

namespace Careerly.Repositories
{
    public class AwardRepository : IAwardRepository
    {
        private readonly ModelsContext _context;
        
        public AwardRepository(ModelsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Award>> Get()
        {
            return await _context.award.ToListAsync();
        }
        public async Task<Award> Create(Award award)
        {
            _context.award.Add(award);
            _ = await _context.SaveChangesAsync();
            return award;
        }

        public async Task Delete(int id)
        {
            var awardToDelete = await _context.award.FindAsync(id);
            _context.award.Remove(awardToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Award> Get(int id)
        {
            return await _context.award.FindAsync(id);
        }

        public async Task Update(Award award)
        {
            _context.Entry(award).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
