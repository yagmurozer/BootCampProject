

using Business.Abstracts;
using Entities;
using Repositories.Abstract;

namespace Business.Concretes;

public class InstructorManager : IInstructorService
{
    private readonly IInstructorRepository _instructorRepository;

    public InstructorManager(IInstructorRepository instructorRepository)
    {
        _instructorRepository = instructorRepository;
    }

    public void Add(Instructor instructor)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Instructor Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<Instructor> GetAll()
    {
        throw new NotImplementedException();
    }

    public Instructor GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public void Update(Instructor ınstructor)
    {
        throw new NotImplementedException();
    }
}
