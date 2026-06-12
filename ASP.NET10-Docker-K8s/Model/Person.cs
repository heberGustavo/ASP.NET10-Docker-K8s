using ASP.NET10_Docker_K8s.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET10_Docker_K8s.Model
{
    [Table("person")]
    public class Person : BaseEntity
    {
        public Person() { }

        public Person(long id, string firstName, string lastName, string address, string gender)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Gender = gender;
        }

        [Required]
        [Column("first_name", TypeName = "varchar(80)")]
        [MaxLength(80)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Column("last_name", TypeName = "varchar(80)")]
        [MaxLength(80)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Column("address", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [Column("gender", TypeName = "varchar(6)")]
        [MaxLength(6)]
        public string Gender { get; set; } = string.Empty;
    }
}
