
using Business.Abstracts;
using Business.Dtos.Request.Employees;
using Business.Dtos.Response.Employees;
using Entities;
using Repositories.Abstract;

namespace Business.Concretes;

public class EmployeeManager : IEmployeeService
{
    private readonly IEmployeeRepository employeeRepository;

    public EmployeeManager(IEmployeeRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
    }

    public CreatedEmployeeResponse Add(CreateEmployeeRequest request)
    {
        throw new NotImplementedException();
    }

    public DeletedEmployeeResponse Delete(DeleteEmployeeRequest request)
    {
        throw new NotImplementedException();
    }

    public GetEmployeeByIdResponse GetById(GetEmployeeByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public List<GetListEmployeeResponse> GetList()
    {
        throw new NotImplementedException();
    }

    public UpdatedEmployeeResponse Update(UpdateEmployeeRequest request)
    {
        throw new NotImplementedException();
    }
}
