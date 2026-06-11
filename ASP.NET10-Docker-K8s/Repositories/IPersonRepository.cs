using ASP.NET10_Docker_K8s.Model;

namespace ASP.NET10_Docker_K8s.Repositories
{
    public interface IPersonRepository
    {
        List<Person> FindAll();
        Person FindById(long id);
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);
    }
}
