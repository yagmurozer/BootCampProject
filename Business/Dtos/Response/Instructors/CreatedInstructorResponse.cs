

namespace Business.Dtos.Response.Instructors;

public class CreatedInstructorResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Expertise { get; set; }
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; }
}
