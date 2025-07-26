
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Request.Employees;
using Business.Dtos.Response.Employees;
using Business.Rules;
using Entities;
using Repositories.Abstract;

namespace Business.Concretes;

public class EmployeeManager : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    private readonly EmployeeBusinessRules _businessRules;

    public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper, EmployeeBusinessRules businessRules)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public CreatedEmployeeResponse Add(CreateEmployeeRequest request)
    {
        var entity = _mapper.Map<Employee>(request);
        var created = _employeeRepository.Add(entity);
        return _mapper.Map<CreatedEmployeeResponse>(created);
    }

    public DeletedEmployeeResponse Delete(DeleteEmployeeRequest request)
    {
        var entity = _employeeRepository.Get(e => e.Id == request.Id);
        if (entity == null) throw new Exception("Employee not found");
        _employeeRepository.Delete(entity);
        return _mapper.Map<DeletedEmployeeResponse>(entity);
    }

    public GetEmployeeByIdResponse GetById(GetEmployeeByIdRequest request)
    {
        var entity = _employeeRepository.Get(e => e.Id == request.Id);
        if (entity == null) throw new Exception("Employee not found");
        return _mapper.Map<GetEmployeeByIdResponse>(entity);
    }

    public List<GetListEmployeeResponse> GetList()
    {
        var list = _employeeRepository.GetAll();
        return _mapper.Map<List<GetListEmployeeResponse>>(list);
    }

    public UpdatedEmployeeResponse Update(UpdateEmployeeRequest request)
    {
        var entity = _employeeRepository.Get(e => e.Id == request.Id);
        if (entity == null) throw new Exception("Employee not found");
        _mapper.Map(request, entity);
        var updated = _employeeRepository.Update(entity);
        return _mapper.Map<UpdatedEmployeeResponse>(updated);
    }
}
