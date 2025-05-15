

namespace Business.Dtos.Response.Employees;

public class CreatedEmployeeResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; }
}
