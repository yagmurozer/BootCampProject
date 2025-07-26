using Core.Repositories;
using Entities;
using System.Linq.Expressions;

namespace Repositories.Abstract;

public interface IApplicationRepository : IRepository<Application,Guid>
{


}
