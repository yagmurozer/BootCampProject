
using Business.Dtos.Request.Bootcamps;
using Business.Dtos.Response.Bootcamps;
using Entities;

namespace Business.Abstracts;

public interface IBootcampService
{
    CreatedBootcampResponse Add(CreateBootcampRequest request);
    List<GetListBootcampResponse> GetList();
    GetBootcampByIdResponse GetById(GetBootcampByIdRequest request);
    UpdatedBootcampResponse Update(UpdateBootcampRequest request);
    DeletedBootcampResponse Delete(DeleteBootcampRequest request);
}
