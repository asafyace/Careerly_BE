using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careerly.Models;

namespace Careerly.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> Get();
        Task<Course> Get(int id);
        Task<Course> Create(Course course);
        Task Update(Course course);
        Task Delete(int course);
    }
}
