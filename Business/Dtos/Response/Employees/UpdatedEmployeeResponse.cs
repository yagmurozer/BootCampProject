namespace Business.Dtos.Response.Employees;

public class UpdatedEmployeeResponse
{
    public Guid Id { get; set; }
    public string Position { get; set; }
    public string Email { get; set; }
    public DateTime UpdatedDate { get; set; }
}
