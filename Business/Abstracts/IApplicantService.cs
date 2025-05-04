
using Business.Dtos.Request.Applicant;
using Business.Dtos.Response.Applicant;
using Core.Business;
using Entities;

namespace Business.Abstracts;

public interface IApplicantService : IBaseService<Applicant>
{
/*    void Add(Applicant applicant);
    List<Applicant> GetAll();
    Applicant GetByName(string name);
    void Update(Applicant applicant);
    void Delete(int id); */

    //request response pattern
    CreatedApplicantResponse Add(CreateApplicantRequest request);
    List<GetListApplicantResponse> GetList();
}
