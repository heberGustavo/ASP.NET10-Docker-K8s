using ASP.NET10_Docker_K8s.Model;

namespace ASP.NET10_Docker_K8s.Repositories
{
    public interface IBookRepository
    {
        List<Book> FindAll();
        Book FindById(long id);
        Book Create(Book book);
        Book Update(Book book);
        void Delete(long id);
    }
}
