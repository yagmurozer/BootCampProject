

using Business.Abstracts;
using Entities;
using Repositories.Abstract;

namespace Business.Concretes;

public class ApplicationManager : IApplicationService
{
    private readonly IApplicantRepository applicantRepository;

    public ApplicationManager(IApplicantRepository applicantRepository)
    {
        this.applicantRepository = applicantRepository;
    }

    public void Add(Application application)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Application Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<Application> GetAll()
    {
        throw new NotImplementedException();
    }

    public Application GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public void Update(Application application)
    {
        throw new NotImplementedException();
    }
}
