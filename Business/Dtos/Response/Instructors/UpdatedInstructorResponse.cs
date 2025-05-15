namespace Business.Dtos.Response.Instructors;

public class UpdatedInstructorResponse
{
    public Guid Id { get; set; }
    public string Expertise { get; set; }
    public string Email { get; set; }
    public DateTime UpdatedDate { get; set; }
}
