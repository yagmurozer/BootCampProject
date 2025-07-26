
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Request.Applicants;
using Business.Dtos.Response.Applicants;
using Business.Rules;
using Core.Exceptions.Types;
using Entities;
using Repositories.Abstract;

namespace Business.Concretes;

public class ApplicantManager : IApplicantService
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly IMapper _mapper; //Automapper için mapper nesnesi oluşturduk
    private readonly ApplicantBusinessRules _applicantBusinessRules; //kuralların dahil oluşu


    public ApplicantManager(IApplicantRepository applicantRepository, IMapper mapper, ApplicantBusinessRules applicantBusinessRules)
    {
        _applicantRepository = applicantRepository;
        _mapper = mapper; //constructora dahil edilmeli
        _applicantBusinessRules = applicantBusinessRules;
    }



    public CreatedApplicantResponse Add(CreateApplicantRequest request)
    {
        // Business kuralları kontrolü
        _applicantBusinessRules.CheckIfApplicantAlreadyExists(request.NationalIdentity);
        // Eğer yeni başvuranın Kara Liste’de olup olmadığını kontrol etmek istiyorsan 
        // ama başvuranın Id’si yoksa, bu kontrolü başka yerde yapman gerekebilir.

        Applicant applicant = _mapper.Map<Applicant>(request);
        Applicant createdApplicant = _applicantRepository.Add(applicant);
        CreatedApplicantResponse response = _mapper.Map<CreatedApplicantResponse>(createdApplicant);

        return response;
    }

    public DeletedApplicantResponse Delete(DeleteApplicantRequest request)
    {
        _applicantBusinessRules.CheckIfApplicantExists(request.Id);

        Applicant applicant = _applicantRepository.Get(a => a.Id == request.Id);

        _applicantRepository.Delete(applicant);

        DeletedApplicantResponse response = _mapper.Map<DeletedApplicantResponse>(applicant);
        return response;
    }

    public GetApplicantByIdResponse GetById(GetApplicantByIdRequest request)
    {
        _applicantBusinessRules.CheckIfApplicantExists(request.Id);

        Applicant applicant = _applicantRepository.Get(a => a.Id == request.Id);

        GetApplicantByIdResponse response = _mapper.Map<GetApplicantByIdResponse>(applicant);
        return response;
    }

    public List<GetListApplicantResponse> GetList()
    {
        List<Applicant> applicants = _applicantRepository.GetAll();
        List<GetListApplicantResponse> responses = _mapper.Map<List<GetListApplicantResponse>>(applicants);

        return responses;
    }

    public UpdatedApplicantResponse Update(UpdateApplicantRequest request)
    {
        _applicantBusinessRules.CheckIfApplicantExists(request.Id);

        Applicant existingApplicant = _applicantRepository.Get(a => a.Id == request.Id);

        _mapper.Map(request, existingApplicant);

        Applicant updatedApplicant = _applicantRepository.Update(existingApplicant);

        UpdatedApplicantResponse response = _mapper.Map<UpdatedApplicantResponse>(updatedApplicant);

        return response;
    }
}


