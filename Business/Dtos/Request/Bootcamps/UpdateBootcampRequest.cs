namespace Business.Dtos.Request.Bootcamps;

public class UpdateBootcampRequest
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public DateTime EndDate { get; set; }
}
