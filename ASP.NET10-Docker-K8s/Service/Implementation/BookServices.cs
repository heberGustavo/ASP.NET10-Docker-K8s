using ASP.NET10_Docker_K8s.Model;
using ASP.NET10_Docker_K8s.Repositories;
using ASP.NET10_Docker_K8s.Service.Interface;

namespace ASP.NET10_Docker_K8s.Service.Implementation
{
    public class BookServices : IBookServices
    {
        private readonly IBookRepository _repository;

        public BookServices(IBookRepository repository)
        {
            _repository = repository;
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}
