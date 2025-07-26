namespace Business.Dtos.Request.Instructors;

public class UpdateInstructorRequest
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string CompanyName { get; set; } 
}
