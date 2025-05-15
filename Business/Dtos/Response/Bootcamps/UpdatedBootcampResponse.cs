namespace Business.Dtos.Response.Bootcamps;

public class UpdatedBootcampResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
