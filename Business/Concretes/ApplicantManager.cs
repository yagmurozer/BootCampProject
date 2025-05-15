
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Request.Applicants;
using Business.Dtos.Response.Applicants;
using Entities;
using Repositories.Abstract;

namespace Business.Concretes;

public class ApplicantManager : IApplicantService
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly IMapper _mapper; //Automapper için mapper nesnesi oluşturduk

    public ApplicantManager(IApplicantRepository applicantRepository, IMapper mapper)
    {
        _applicantRepository = applicantRepository;
        _mapper = mapper; //constructora dahil edilmeli
    }



    public CreatedApplicantResponse Add(CreateApplicantRequest request)
    {
        {
            // Manual Mapping
            //Applicant applicant = new Applicant //süslü parantezle içerisine dahil olundu
            //{
            //    FirstName = request.FirstName,
            //    LastName = request.LastName,
            //    UserName = request.UserName,
            //    DateOfBirth = request.DateOfBirth,
            //    Email = request.Email,
            //    Password = request.Password,
            //    NationalIdentity = request.NationalIdentity

            //};
            //Applicant addedApplicant = _applicantRepository.Add(applicant); 
            //// verinin eklendiğinden emin olmak için add fonk ile ekleme kullanılır
            //return new CreatedApplicantResponse
            //{
            //    Id = addedApplicant.Id,
            //    FirstName = addedApplicant.FirstName,
            //    LastName = addedApplicant.LastName,
            //    UserName = addedApplicant.UserName,
            //    DateOfBirth = addedApplicant.DateOfBirth,
            //    Email = addedApplicant.Email,
            //    Password = addedApplicant.Password,
            //    NationalIdentity = addedApplicant.NationalIdentity,
            //    CreatedDate = addedApplicant.CreatedDate
            //};
        }

        //AutoMapper
        Applicant applicant = _mapper.Map<Applicant>(request);// applicant ile requesti mappliyor
        Applicant createdApplicant = _applicantRepository.Add(applicant); //db ye ekledi
        CreatedApplicantResponse response = _mapper.Map<CreatedApplicantResponse>(createdApplicant); //eklenen veriyi response ile mappleyip geri döndürdü
        return response;

    }

    public DeletedApplicantResponse Delete(DeleteApplicantRequest request)
    {
        // İlgili kaydı veritabanından al
        Applicant applicant = _applicantRepository.Get(a => a.Id == request.Id);

        if (applicant == null)
            throw new Exception("Applicant not found");

        // Kaydı sil
        _applicantRepository.Delete(applicant);

        // Silinen kaydı DeletedApplicantResponse'a map'le
        DeletedApplicantResponse response = _mapper.Map<DeletedApplicantResponse>(applicant);
        return response;
    }

    public GetApplicantByIdResponse GetById(GetApplicantByIdRequest request)
    {
        // Veritabanından ID'ye göre kayıt çek
        Applicant applicant = _applicantRepository.Get(a => a.Id == request.Id);

        if (applicant == null)
            throw new Exception("Applicant not found");

        // AutoMapper ile dönüşüm yap
        GetApplicantByIdResponse response = _mapper.Map<GetApplicantByIdResponse>(applicant);
        return response;
    }

    public List<GetListApplicantResponse> GetList()
    {
        {
            //    List<Applicant> applicants = _applicantRepository.GetAll();
            //    List<GetListApplicantResponse> responses = new List<GetListApplicantResponse>();
            //    foreach (var applicant in applicants)
            //    {
            //        responses.Add(new GetListApplicantResponse
            //        {
            //            Id = applicant.Id,
            //            FirstName = applicant.FirstName,
            //            LastName = applicant.LastName,
            //            UserName = applicant.UserName,
            //            DateOfBirth = applicant.DateOfBirth,
            //            Email = applicant.Email,
            //            Password = applicant.Password,
            //            NationalIdentity = applicant.NationalIdentity,
            //            CreatedDate = applicant.CreatedDate,
            //            UpdatedDate = applicant.UpdatedDate
            //        });
            //    }
            //    return responses;
        }
        //AutoMapper
        List<Applicant> applicant = _applicantRepository.GetAll();
        List<GetListApplicantResponse> responses = _mapper.Map<List<GetListApplicantResponse>>(applicant); // 
        return responses;
    }

    public UpdatedApplicantResponse Update(UpdateApplicantRequest request)
    {
        // Güncellenecek eski kaydı bul
        Applicant existingApplicant = _applicantRepository.Get(a => a.Id == request.Id);

        if (existingApplicant == null)
            throw new Exception("Applicant not found");

        // Request'teki verileri mevcut entity'e uygula
        _mapper.Map(request, existingApplicant); // bu Map(source, destination) overload'ıdır

        // DB'de güncelle
        Applicant updatedApplicant = _applicantRepository.Update(existingApplicant);

        // Geri response DTO'suna map'le
        UpdatedApplicantResponse response = _mapper.Map<UpdatedApplicantResponse>(updatedApplicant);
        return response;
    }
}


