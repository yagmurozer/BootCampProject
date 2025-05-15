
using Business.Dtos.Request.Instructors;
using Business.Dtos.Response.Instructors;
using Entities;

namespace Business.Abstracts;

public interface IInstructorService 
{
    CreatedInstructorResponse Add(CreateInstructorRequest request);
    List<GetListInstructorResponse> GetList();
    GetInstructorByIdResponse GetById(GetInstructorByIdRequest request);
    UpdatedInstructorResponse Update(UpdateInstructorRequest request);
    DeletedInstructorResponse Delete(DeleteInstructorRequest request);

}
