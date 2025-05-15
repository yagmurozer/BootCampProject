

using Business.Abstracts;
using Business.Dtos.Request.Applications;
using Business.Dtos.Response.Applications;
using Entities;
using Repositories.Abstract;

namespace Business.Concretes;

public class ApplicationManager : IApplicationService
{
    private readonly IApplicantRepository applicantRepository;

    public ApplicationManager(IApplicantRepository applicantRepository)
    {
        this.applicantRepository = applicantRepository;
    }

    public CreatedApplicationResponse Add(CreateApplicationRequest request)
    {
        throw new NotImplementedException();
    }

    public DeletedApplicationResponse Delete(DeleteApplicationRequest request)
    {
        throw new NotImplementedException();
    }

    public GetApplicationByIdResponse GetById(GetApplicationByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public List<GetListApplicationResponse> GetList()
    {
        throw new NotImplementedException();
    }

    public UpdatedApplicationResponse Update(UpdateApplicationRequest request)
    {
        throw new NotImplementedException();
    }
}
