using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careerly.Models;

namespace Careerly.Repositories
{
    public interface IEducationRepository
    {
        Task<IEnumerable<Education>> Get();
        Task<Education> Get(int id);
        Task<Education> Create(Education education);
        Task Update(Education education);
        Task Delete(int education);
    }
}
