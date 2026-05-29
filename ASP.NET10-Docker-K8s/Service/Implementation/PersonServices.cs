using ASP.NET10_Docker_K8s.Model;
using ASP.NET10_Docker_K8s.Model.Context;
using ASP.NET10_Docker_K8s.Service.Interface;

namespace ASP.NET10_Docker_K8s.Service.Implementation
{
    public class PersonServices : IPersonServices
    {
        private MSSQLContext _context;

        public PersonServices(MSSQLContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.Find(id);
        }

        public Person Create(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            return person;
        }

        public Person Update(Person person)
        {
            var personFound = FindById(person.Id);
            if(personFound == null) return null;

            _context.Entry(personFound).CurrentValues.SetValues(person);
            _context.SaveChanges();
            return person;
        }

        public void Delete(long id)
        {
            var personFound = FindById(id);
            if (personFound == null) return;

            _context.Persons.Remove(personFound);
            _context.SaveChanges();
            return;
        }

    }
}
