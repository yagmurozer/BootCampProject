
using Business.Dtos.Request.Applicants;
using Business.Dtos.Request.Applications;
using Business.Dtos.Response.Applicants;
using Business.Dtos.Response.Applications;
using Entities;

namespace Business.Abstracts;

public interface IApplicationService 
{
    CreatedApplicationResponse Add(CreateApplicationRequest request);
    List<GetListApplicationResponse> GetList();
    GetApplicationByIdResponse GetById(GetApplicationByIdRequest request);
    UpdatedApplicationResponse Update(UpdateApplicationRequest request);
    DeletedApplicationResponse Delete(DeleteApplicationRequest request);

}
