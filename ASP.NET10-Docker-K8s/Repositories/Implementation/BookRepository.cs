using ASP.NET10_Docker_K8s.Model;
using ASP.NET10_Docker_K8s.Model.Context;

namespace ASP.NET10_Docker_K8s.Repositories.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly MSSQLContext _context;

        public BookRepository(MSSQLContext context)
        {
            _context = context;
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(long id)
        {
            return _context.Books.Find(id);
        }

        public Book Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public Book Update(Book book)
        {
            var bookFound = FindById(book.Id);
            if (bookFound == null) return null;

            _context.Entry(bookFound).CurrentValues.SetValues(book);
            _context.SaveChanges();
            return book;
        }

        public void Delete(long id)
        {
            var bookFound = FindById(id);
            if (bookFound == null) return;

            _context.Books.Remove(bookFound);
            _context.SaveChanges();
            return;
        }
    }
}
