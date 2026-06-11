using ASP.NET10_Docker_K8s.Model;
using ASP.NET10_Docker_K8s.Repositories;
using ASP.NET10_Docker_K8s.Service.Interface;

namespace ASP.NET10_Docker_K8s.Service.Implementation
{
    public class PersonServices : IPersonServices
    {
        private readonly IPersonRepository _repository;

        public PersonServices(IPersonRepository repository)
        {
            _repository = repository;
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}
