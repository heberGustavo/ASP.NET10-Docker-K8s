using ASP.NET10_Docker_K8s.Data.DTO;

namespace ASP.NET10_Docker_K8s.Service.Interface
{
    public interface IPersonServices
    {
        List<PersonDTO> FindAll();
        PersonDTO FindById(long id);
        PersonDTO Create(PersonDTO person);
        PersonDTO Update(PersonDTO person);
        void Delete(long id);
    }
}
