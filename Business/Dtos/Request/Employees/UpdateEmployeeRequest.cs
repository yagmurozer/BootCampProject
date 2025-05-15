namespace Business.Dtos.Request.Employees;

public class UpdateEmployeeRequest
{
    public Guid Id { get; set; }
    public string Position { get; set; }
    public string Email { get; set; }
}
