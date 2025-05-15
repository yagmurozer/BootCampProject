

namespace Business.Dtos.Response.BlackLists;

public class CreatedBlackListResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Reason { get; set; }

}
