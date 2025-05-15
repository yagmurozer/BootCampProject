namespace Business.Dtos.Response.Applications;

public class UpdatedApplicationResponse
{
    public Guid Id { get; set; }
    public string Status { get; set; }
    public DateTime UpdatedDate { get; set; }
}
