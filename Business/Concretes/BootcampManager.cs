

using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Request.Bootcamps;
using Business.Dtos.Response.Bootcamps;
using Business.Rules;
using Entities;
using Repositories.Abstract;

namespace Business.Concretes
{
    public class BootcampManager : IBootcampService
    {
        private readonly IBootcampRepository _bootcampRepository;
        private readonly IMapper _mapper;
        private readonly BootcampBusinessRules _businessRules;

        public BootcampManager(IBootcampRepository bootcampRepository, IMapper mapper, BootcampBusinessRules businessRules)
        {
            _bootcampRepository = bootcampRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public CreatedBootcampResponse Add(CreateBootcampRequest request)
        {
            // Kurallar
            _businessRules.CheckIfBootcampNameExists(request.Name);
            _businessRules.CheckStartDateBeforeEndDate(request.StartDate, request.EndDate);
            _businessRules.CheckIfInstructorExists(request.InstructorId);

            var entity = _mapper.Map<Bootcamp>(request);
            var created = _bootcampRepository.Add(entity);
            return _mapper.Map<CreatedBootcampResponse>(created);
        }

        public DeletedBootcampResponse Delete(DeleteBootcampRequest request)
        {
            var entity = _bootcampRepository.Get(b => b.Id == request.Id);
            if (entity == null)
                throw new Exception("Bootcamp not found");

            _bootcampRepository.Delete(entity);
            return _mapper.Map<DeletedBootcampResponse>(entity);
        }

        public GetBootcampByIdResponse GetById(GetBootcampByIdRequest request)
        {
            var entity = _bootcampRepository.Get(b => b.Id == request.Id);
            if (entity == null)
                throw new Exception("Bootcamp not found");

            return _mapper.Map<GetBootcampByIdResponse>(entity);
        }

        public List<GetListBootcampResponse> GetList()
        {
            var list = _bootcampRepository.GetAll();
            return _mapper.Map<List<GetListBootcampResponse>>(list);
        }

        public UpdatedBootcampResponse Update(UpdateBootcampRequest request)
        {
            var entity = _bootcampRepository.Get(b => b.Id == request.Id);
            if (entity == null)
                throw new Exception("Bootcamp not found");

            // Kurallar
            _businessRules.CheckStartDateBeforeEndDate(request.StartDate, request.EndDate);
            _businessRules.CheckIfInstructorExists(request.InstructorId);

            _mapper.Map(request, entity);
            var updated = _bootcampRepository.Update(entity);
            return _mapper.Map<UpdatedBootcampResponse>(updated);
        }
    }
}
