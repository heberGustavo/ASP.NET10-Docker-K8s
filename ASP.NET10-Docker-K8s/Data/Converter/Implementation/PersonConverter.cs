using ASP.NET10_Docker_K8s.Data.Converter.Contract;
using ASP.NET10_Docker_K8s.Data.DTO;
using ASP.NET10_Docker_K8s.Model;

namespace ASP.NET10_Docker_K8s.Data.Converter.Implementation
{
    public class PersonConverter : IParser<Person, PersonDTO>, IParser<PersonDTO, Person>
    {
        #region Convert to PersonDTO

        public PersonDTO Parse(Person origin)
        {
            if (origin == null) return null;

            return new PersonDTO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<PersonDTO> ParseList(List<Person> origin)
        {
            if(origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        #endregion

        #region Convert to Person

        public Person Parse(PersonDTO origin)
        {
            if (origin == null) return null;

            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<Person> ParseList(List<PersonDTO> origin)
        {
            if(origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        #endregion
    }
}
