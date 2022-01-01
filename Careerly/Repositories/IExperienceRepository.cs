using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careerly.Models;

namespace Careerly.Repositories
{
    public interface IExperienceRepository
    {
        Task<IEnumerable<Experience>> Get();
        Task<Experience> Get(int id);
        Task<Experience> Create(Experience experience);
        Task Update(Experience experience);
        Task Delete(int experience);
    }
}
