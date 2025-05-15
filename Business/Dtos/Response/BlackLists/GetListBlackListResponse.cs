
namespace Business.Dtos.Response.BlackLists;

public class GetListBlackListResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
