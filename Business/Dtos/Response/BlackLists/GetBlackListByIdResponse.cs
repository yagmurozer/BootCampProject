namespace Business.Dtos.Response.BlackLists;

public class GetBlackListByIdResponse
{
    public Guid Id { get; set; }
    public string Reason { get; set; }
    public DateTime CreatedDate { get; set; }
}