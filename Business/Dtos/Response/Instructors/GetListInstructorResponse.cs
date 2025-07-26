
namespace Business.Dtos.Response.Instructors;

public class GetListInstructorResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedDate { get; set; }
}
