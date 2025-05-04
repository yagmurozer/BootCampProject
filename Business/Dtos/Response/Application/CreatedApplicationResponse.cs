

namespace Business.Dtos.Response.Application;

public class CreatedApplicationResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
}
