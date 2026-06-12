namespace ASP.NET10_Docker_K8s.Data.DTO
{
    public class BookDTO
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
