using ASP.NET10_Docker_K8s.Data.Converter.Implementation;
using ASP.NET10_Docker_K8s.Data.DTO;
using ASP.NET10_Docker_K8s.Model;
using ASP.NET10_Docker_K8s.Repositories;
using ASP.NET10_Docker_K8s.Service.Interface;

namespace ASP.NET10_Docker_K8s.Service.Implementation
{
    public class PersonServices : IPersonServices
    {
        private readonly IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonServices(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public List<PersonDTO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public PersonDTO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PersonDTO Create(PersonDTO person)
        {
            var entity = _converter.Parse(person);
            return _converter.Parse(_repository.Create(entity));
        }

        public PersonDTO Update(PersonDTO person)
        {
            var entity = _converter.Parse(person);
            return _converter.Parse(_repository.Update(entity));
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}
