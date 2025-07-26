

using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Request.BlackLists;
using Business.Dtos.Response.BlackLists;
using Business.Rules;
using Entities;
using Repositories.Abstract;

namespace Business.Concretes;

public class BlackListManager : IBlackListService
{
    private readonly IBlackListRepository _blackListRepository;
    private readonly IMapper _mapper;
    private readonly BlackListBusinessRules _businessRules;

    public BlackListManager(IBlackListRepository blackListRepository, IMapper mapper, BlackListBusinessRules businessRules)
    {
        _blackListRepository = blackListRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public CreatedBlackListResponse Add(CreateBlackListRequest request)
    {
        // Kuralları uygula
        _businessRules.CheckIfBlackListAlreadyExists(request.ApplicantId);
        _businessRules.CheckIfReasonProvided(request.Reason);

        // Maple ve ekle
        BlackList blackList = _mapper.Map<BlackList>(request);
        BlackList created = _blackListRepository.Add(blackList);

        return _mapper.Map<CreatedBlackListResponse>(created);
    }

    public DeletedBlackListResponse Delete(DeleteBlackListRequest request)
    {
        BlackList entity = _blackListRepository.Get(b => b.Id == request.Id);
        if (entity == null)
            throw new Exception("Blacklist item not found");

        _blackListRepository.Delete(entity);
        return _mapper.Map<DeletedBlackListResponse>(entity);
    }

    public GetBlackListByIdResponse GetById(GetBlackListByIdRequest request)
    {
        BlackList entity = _blackListRepository.Get(b => b.Id == request.Id);
        if (entity == null)
            throw new Exception("Blacklist item not found");

        return _mapper.Map<GetBlackListByIdResponse>(entity);
    }

    public List<GetListBlackListResponse> GetList()
    {
        List<BlackList> items = _blackListRepository.GetAll();
        return _mapper.Map<List<GetListBlackListResponse>>(items);
    }

    public UpdatedBlackListResponse Update(UpdateBlackListRequest request)
    {
        BlackList entity = _blackListRepository.Get(b => b.Id == request.Id);
        if (entity == null)
            throw new Exception("Blacklist item not found");

        _businessRules.CheckIfReasonProvided(request.Reason);

        _mapper.Map(request, entity);
        var updated = _blackListRepository.Update(entity);

        return _mapper.Map<UpdatedBlackListResponse>(updated);
    }
}