namespace Business.Dtos.Response.Bootcamps;

public class GetBootcampByIdResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}