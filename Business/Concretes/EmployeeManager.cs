
using Business.Abstracts;
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

    public void Add(Employee employee)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Employee Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<Employee> GetAll()
    {
        throw new NotImplementedException();
    }

    public Employee GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public void Update(Employee employee)
    {
        throw new NotImplementedException();
    }
}
