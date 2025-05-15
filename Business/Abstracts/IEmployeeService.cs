
using Business.Dtos.Request.Employees;
using Business.Dtos.Response.Employees;
using Entities;

namespace Business.Abstracts;

public interface IEmployeeService 
{
    CreatedEmployeeResponse Add(CreateEmployeeRequest request);
    List<GetListEmployeeResponse> GetList();
    GetEmployeeByIdResponse GetById(GetEmployeeByIdRequest request);
    UpdatedEmployeeResponse Update(UpdateEmployeeRequest request);
    DeletedEmployeeResponse Delete(DeleteEmployeeRequest request);
}
