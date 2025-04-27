using Core.Entities;

namespace Entities;

public class Employee : User
{
    public string Position { get; set; }

    public Employee(string position)
    {
        Position = position;
    }

    public Employee() { }
}
