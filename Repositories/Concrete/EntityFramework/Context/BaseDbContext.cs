using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repositories.Concrete.EntityFramework.Context;

public class BaseDbContext : DbContext
{ // databasedeki allanları burada mapliyoruz
    protected IConfiguration Configuration { get; set; }
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Instructor> Instructors { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }
}
