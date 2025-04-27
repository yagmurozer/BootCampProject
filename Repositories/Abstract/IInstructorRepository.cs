using Core.Repositories;
using Entities;

namespace Repositories.Abstract;

public interface IInstructorRepository : IRepository<Instructor, Guid>
{
}
