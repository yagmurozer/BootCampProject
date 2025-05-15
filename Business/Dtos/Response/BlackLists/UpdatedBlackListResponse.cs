namespace Business.Dtos.Response.BlackLists;

public class UpdatedBlackListResponse
{
    public Guid Id { get; set; }
    public string Reason { get; set; }
    public DateTime UpdatedDate { get; set; }
}
