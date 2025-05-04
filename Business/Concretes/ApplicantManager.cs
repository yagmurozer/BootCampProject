
using Business.Abstracts;
using Entities;
using Repositories.Abstract;

namespace Business.Concretes;

public class ApplicantManager : IApplicantService
{
    private readonly IApplicantRepository _applicantRepository;

    public ApplicantManager(IApplicantRepository applicantRepository)
    {
        _applicantRepository = applicantRepository;
    }

    public void Add(Applicant applicant)
    {
        _applicantRepository.Add(applicant);
    }

    public void Delete(int id)
    {
        
    }

    public Applicant Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<Applicant> GetAll()
    {
        throw new NotImplementedException();
    }

    public Applicant GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public void Update(Applicant applicant)
    {
        throw new NotImplementedException();
    }
}


