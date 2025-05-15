

using Business.Abstracts;
using Business.Dtos.Request.Bootcamps;
using Business.Dtos.Response.Bootcamps;
using Entities;
using Repositories.Abstract;

namespace Business.Concretes
{
    public class BootcampManager :IBootcampService
    {
        private readonly IBootcampRepository bootcampRepository;

        public BootcampManager(IBootcampRepository bootcampRepository)
        {
            this.bootcampRepository = bootcampRepository;
        }

        public CreatedBootcampResponse Add(CreateBootcampRequest request)
        {
            throw new NotImplementedException();
        }

        public DeletedBootcampResponse Delete(DeleteBootcampRequest request)
        {
            throw new NotImplementedException();
        }

        public GetBootcampByIdResponse GetById(GetBootcampByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public List<GetListBootcampResponse> GetList()
        {
            throw new NotImplementedException();
        }

        public UpdatedBootcampResponse Update(UpdateBootcampRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
