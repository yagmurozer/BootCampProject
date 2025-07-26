

using Core.Exceptions.Types;
using Core.Rules;
using Repositories.Abstract;
using Entities.Enum;


namespace Business.Rules;

public class BootcampBusinessRules:BaseBusinessRules
{
    private readonly IBootcampRepository _bootcampRepository;
    private readonly IInstructorRepository _instructorRepository;

    public BootcampBusinessRules(IBootcampRepository bootcampRepository, IInstructorRepository instructorRepository)
    {
        _bootcampRepository = bootcampRepository;
        _instructorRepository = instructorRepository;
    }

    public void CheckStartDateBeforeEndDate(DateTime start, DateTime end)
    {
        if (start >= end)
            throw new Exception("Başlangıç tarihi bitiş tarihinden önce olmalıdır.");
    }

    public void CheckIfBootcampNameExists(string name)
    {
        var exists = _bootcampRepository.Get(b => b.Name == name);
        if (exists != null)
            throw new Exception("Aynı isimde bir bootcamp daha önce açılmış.");
    }

    public void CheckIfInstructorExists(Guid instructorId)
    {
        var exists = _instructorRepository.Get(i => i.Id == instructorId);
        if (exists == null)
            throw new Exception("Eğitmen sistemde kayıtlı değil.");
    }

    public void CheckIfBootcampIsOpen(Guid bootcampId)
    {
        var bootcamp = _bootcampRepository.Get(b => b.Id == bootcampId);

        if (bootcamp == null || bootcamp.BootcampState == BootcampState.CANCELLED)
            throw new Exception($"Bootcamp durumu '{bootcamp.BootcampState}' olduğu için başvuru alınamaz.");
    }
}
