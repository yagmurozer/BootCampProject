
namespace Business.Dtos.Response.Applications;

public class GetListApplicationResponse
{
    public Guid Id { get; set; }
    public Guid ApplicantId { get; set; }
    public Guid BootcampId { get; set; }
    public string Status { get; set; }
    public DateTime CreatedDate { get; set; }
}
