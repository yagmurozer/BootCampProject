namespace Business.Dtos.Response.Employees;

public class GetEmployeeByIdResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
}