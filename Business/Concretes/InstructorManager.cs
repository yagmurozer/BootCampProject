

using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Request.Instructors;
using Business.Dtos.Response.Instructors;
using Business.Rules;
using Entities;
using Repositories.Abstract;

namespace Business.Concretes;

public class InstructorManager : IInstructorService
{
    private readonly IInstructorRepository _instructorRepository;
    private readonly IMapper _mapper;
    private readonly InstructorBusinessRules _businessRules;

    public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper, InstructorBusinessRules businessRules)
    {
        _instructorRepository = instructorRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public CreatedInstructorResponse Add(CreateInstructorRequest request)
    {
        Instructor instructor = _mapper.Map<Instructor>(request);
        Instructor createdInstructor = _instructorRepository.Add(instructor);
        CreatedInstructorResponse response = _mapper.Map<CreatedInstructorResponse>(createdInstructor);
        return response;
    }

    public DeletedInstructorResponse Delete(DeleteInstructorRequest request)
    {
        Instructor instructor = _instructorRepository.Get(i => i.Id == request.Id);
        if (instructor == null)
            throw new Exception("Instructor not found");

        _instructorRepository.Delete(instructor);
        DeletedInstructorResponse response = _mapper.Map<DeletedInstructorResponse>(instructor);
        return response;
    }

    public GetInstructorByIdResponse GetById(GetInstructorByIdRequest request)
    {
        Instructor instructor = _instructorRepository.Get(i => i.Id == request.Id);
        if (instructor == null)
            throw new Exception("Instructor not found");

        GetInstructorByIdResponse response = _mapper.Map<GetInstructorByIdResponse>(instructor);
        return response;
    }

    public List<GetListInstructorResponse> GetList()
    {
        List<Instructor> instructors = _instructorRepository.GetAll();
        List<GetListInstructorResponse> responses = _mapper.Map<List<GetListInstructorResponse>>(instructors);
        return responses;
    }

    public UpdatedInstructorResponse Update(UpdateInstructorRequest request)
    {
        Instructor existingInstructor = _instructorRepository.Get(i => i.Id == request.Id);
        if (existingInstructor == null)
            throw new Exception("Instructor not found");

        _mapper.Map(request, existingInstructor);
        Instructor updatedInstructor = _instructorRepository.Update(existingInstructor);
        UpdatedInstructorResponse response = _mapper.Map<UpdatedInstructorResponse>(updatedInstructor);
        return response;
    }

}
