

using Business.Abstracts;
using Business.Dtos.Request.Instructors;
using Business.Dtos.Response.Instructors;
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

    public CreatedInstructorResponse Add(CreateInstructorRequest request)
    {
        throw new NotImplementedException();
    }

    public DeletedInstructorResponse Delete(DeleteInstructorRequest request)
    {
        throw new NotImplementedException();
    }

    public GetInstructorByIdResponse GetById(GetInstructorByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public List<GetListInstructorResponse> GetList()
    {
        throw new NotImplementedException();
    }

    public UpdatedInstructorResponse Update(UpdateInstructorRequest request)
    {
        throw new NotImplementedException();
    }
}
