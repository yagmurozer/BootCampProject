﻿
namespace Business.Dtos.Response.Instructor;

public class GetListInstructorResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
