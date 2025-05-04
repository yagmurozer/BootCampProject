

using Business.Abstracts;
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

        public void Add(Bootcamp bootcamp)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Bootcamp Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Bootcamp> GetAll()
        {
            throw new NotImplementedException();
        }

        public Bootcamp GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Bootcamp bootcamp)
        {
            throw new NotImplementedException();
        }
    }
}
