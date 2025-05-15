
namespace Business.Dtos.Request.Applications;

public class CreateApplicationRequest
{
    public Guid ApplicantId { get; set; }
    public Guid BootcampId { get; set; }
    public string Status { get; set; }
}
