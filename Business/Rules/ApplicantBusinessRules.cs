

using Core.Exceptions.Types;
using Core.Rules;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework;

namespace Business.Rules;

public class ApplicantBusinessRules : BaseBusinessRules
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly IBlackListRepository _blackListRepository;

    public ApplicantBusinessRules(IApplicantRepository applicantRepository, IBlackListRepository blackListRepository)
    {
        _applicantRepository = applicantRepository;
        _blackListRepository = blackListRepository;
    }

    public void CheckIfApplicantAlreadyExists(string nationalIdentity)
    {
        var exists = _applicantRepository.Get(a => a.NationalIdentity == nationalIdentity);
        if (exists != null)
            throw new Exception("Aynı TC Kimlik No ile birden fazla başvuru yapılamaz.");
    }

    public void CheckIfBlacklisted(Guid applicantId)
    {
        var isBlacklisted = _blackListRepository.Get(b => b.ApplicantId == applicantId);
        if (isBlacklisted != null)
            throw new Exception("Kara listeye alınan bir başvuru sahibi yeni başvuru yapamaz.");
    }

    public void CheckIfApplicantExists(Guid applicantId)
    {
        var exists = _applicantRepository.Get(a => a.Id == applicantId);
        if (exists == null)
            throw new Exception("Sistemde kayıtlı olmayan bir başvuru sahibi ile işlem yapılamaz.");
    }
}
