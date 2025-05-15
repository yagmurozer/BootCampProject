namespace Business.Dtos.Request.Applications;

public class UpdateApplicationRequest
{
    public Guid Id { get; set; }
    public string Status { get; set; }
}
