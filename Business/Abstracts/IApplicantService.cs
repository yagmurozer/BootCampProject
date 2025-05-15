
using Business.Dtos.Request.Applicants;
using Business.Dtos.Response.Applicants;
using Entities;

namespace Business.Abstracts;

public interface IApplicantService
{
/*    void Add(Applicant applicant);
    List<Applicant> GetAll();
    Applicant GetByName(string name);
    void Update(Applicant applicant);
    void Delete(int id); */

    //request response pattern
    CreatedApplicantResponse Add(CreateApplicantRequest request);
    List<GetListApplicantResponse> GetList();
    GetApplicantByIdResponse GetById(GetApplicantByIdRequest request);
    UpdatedApplicantResponse Update(UpdateApplicantRequest request);
    DeletedApplicantResponse Delete(DeleteApplicantRequest request);


}
