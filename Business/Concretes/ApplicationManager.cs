

using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Request.Applications;
using Business.Dtos.Response.Applicants;
using Business.Dtos.Response.Applications;
using Business.Rules;
using Entities;
using Entities.Enum;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework;

namespace Business.Concretes;

public class ApplicationManager : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IMapper _mapper;
    private readonly ApplicationBusinessRules _businessRules;

    public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper, ApplicationBusinessRules businessRules)
    {
        _applicationRepository = applicationRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public CreatedApplicationResponse Add(CreateApplicationRequest request)
    {
        // 1. Başvuru yapan kişinin aynı bootcamp için daha önce başvuru yapıp yapmadığını kontrol et
        _businessRules.CheckIfAlreadyApplied(request.ApplicantId, request.BootcampId);

        // 2. Başvuru yapılan bootcamp’in aktif olup olmadığını kontrol et
        _businessRules.CheckIfBootcampIsActive(request.BootcampId);

        // 3. Başvuran kişinin kara listede olup olmadığını kontrol et
        _businessRules.CheckIfApplicantBlacklisted(request.ApplicantId);

        Application application = _mapper.Map<Application>(request);
        Application createdApplication = _applicationRepository.Add(application);
        CreatedApplicationResponse response = _mapper.Map<CreatedApplicationResponse>(createdApplication);

        return response;
    }

    public DeletedApplicationResponse Delete(DeleteApplicationRequest request)
    {
        Application application = _applicationRepository.Get(a => a.Id == request.Id);

        if (application == null)
            throw new Exception("Application not found");

        _applicationRepository.Delete(application);

        DeletedApplicationResponse response = _mapper.Map<DeletedApplicationResponse>(application);
        return response;
    }

    public GetApplicationByIdResponse GetById(GetApplicationByIdRequest request)
    {
        Application application = _applicationRepository.Get(a => a.Id == request.Id);

        if (application == null)
            throw new Exception("Application not found");

        GetApplicationByIdResponse response = _mapper.Map<GetApplicationByIdResponse>(application);
        return response;
    }

    public List<GetListApplicationResponse> GetList()
    {
        List<Application> applications = _applicationRepository.GetAll();
        List<GetListApplicationResponse> responses = _mapper.Map<List<GetListApplicationResponse>>(applications);
        return responses;
    }

    public UpdatedApplicationResponse Update(UpdateApplicationRequest request)
    {
        Application existingApplication = _applicationRepository.Get(a => a.Id == request.Id);

        if (existingApplication == null)
            throw new Exception("Application not found");

        var newStatus = Enum.Parse<ApplicationState>(request.Status);

        _businessRules.CheckStatusTransition(existingApplication.ApplicationState, newStatus);

        _mapper.Map(request, existingApplication);

        Application updatedApplication = _applicationRepository.Update(existingApplication);

        UpdatedApplicationResponse response = _mapper.Map<UpdatedApplicationResponse>(updatedApplication);
        return response;
    }
}
