using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careerly.Models;

namespace Careerly.Repositories
{
    public interface IAwardRepository
    {
        Task<IEnumerable<Award>> Get();
        Task<Award> Get(int id);
        Task<Award> Create(Award award);
        Task Update(Award award);
        Task Delete(int award);
    }
}
