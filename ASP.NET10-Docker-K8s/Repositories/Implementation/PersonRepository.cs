using ASP.NET10_Docker_K8s.Model;
using ASP.NET10_Docker_K8s.Model.Context;

namespace ASP.NET10_Docker_K8s.Repositories.Implementation
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MSSQLContext _context;

        public PersonRepository(MSSQLContext context)
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
            if (personFound == null) return null;

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
