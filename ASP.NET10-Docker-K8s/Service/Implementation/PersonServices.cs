using ASP.NET10_Docker_K8s.Model;
using ASP.NET10_Docker_K8s.Service.Interface;

namespace ASP.NET10_Docker_K8s.Service.Implementation
{
    public class PersonServices : IPersonServices
    {
        public List<Person> FindAll()
        {
            var person = new List<Person>();

            for(int i = 1; i <= 10; i++)
            {
                person.Add(MockPerson(i));
            }

            return person;
        }

        public Person FindById(long id)
        {
            return MockPerson(id);
        }

        public Person Create(Person person)
        {
            person.Id = new Random().Next(1, 1000);
            return person;
        }

        public Person Update(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            return;
        }

        #region Private Methods

        private Person MockPerson(long id)
        {
            return new Person(id, $"Person {id}", $"LastName {id}", $"City {id} - SP", "Male");
        }

        #endregion
    }
}
