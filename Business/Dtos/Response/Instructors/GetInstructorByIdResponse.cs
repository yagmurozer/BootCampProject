namespace Business.Dtos.Response.Instructors;

public class GetInstructorByIdResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Expertise { get; set; }
}
