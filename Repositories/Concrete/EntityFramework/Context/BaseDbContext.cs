using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Repositories.Concrete.EntityFramework.Context;

public class BaseDbContext : DbContext
{ // databasedeki allanları burada mapliyoruz
    protected IConfiguration Configuration { get; set; } // programda kullandık
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<Bootcamp> Bootcamps { get; set; }
    public DbSet<BlackList> BlackLists { get; set; }

    public BaseDbContext(DbContextOptions<BaseDbContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    //Döngü veritabanındaki tüm ilişkileri (foreign key) gezer ve bir parent kayıt silinirse, ona bağlı olan child kayıtlar da otomatik olarak silinmesini sağlar
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        foreach (var relationShip in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationShip.DeleteBehavior = DeleteBehavior.Cascade;
        }
    }

}
