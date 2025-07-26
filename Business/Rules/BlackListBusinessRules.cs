

using Core.Exceptions.Types;
using Core.Rules;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework;

namespace Business.Rules;

public class BlackListBusinessRules: BaseBusinessRules
{
    private readonly IBlackListRepository _blackListRepository;

    public BlackListBusinessRules(IBlackListRepository blackListRepository)
    {
        _blackListRepository = blackListRepository;
    }

    public void CheckIfBlackListAlreadyExists(Guid applicantId)
    {
        var exists = _blackListRepository.Get(b => b.ApplicantId == applicantId);
        if (exists != null)
            throw new Exception("Aynı aday için birden fazla aktif kara liste kaydı olamaz.");
    }

    public void CheckIfReasonProvided(string reason)
    {
        if (string.IsNullOrWhiteSpace(reason))
            throw new Exception("Kara listeye alma sebebi boş bırakılamaz.");
    }
}
