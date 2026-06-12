using ASP.NET10_Docker_K8s.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET10_Docker_K8s.Model
{
    [Table("books")]
    public class Book : BaseEntity
    {
        [Column("title", TypeName = "varchar(max)")]
        public string Title { get; set; } = string.Empty;

        [Column("author", TypeName = "varchar(max)")]
        public string Author { get; set; } = string.Empty;

        [Required]
        [Column("price", TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column("launch_date", TypeName = "datetime2(6)")]
        public DateTime LaunchDate { get; set; }
    }
}
