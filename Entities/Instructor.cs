using Core.Entities;

namespace Entities;

public class Instructor : User
{
    public string CompanyName { get; set; }

    public Instructor(string companyName)
    {
        CompanyName = companyName;
    }

    public Instructor() { }
}
