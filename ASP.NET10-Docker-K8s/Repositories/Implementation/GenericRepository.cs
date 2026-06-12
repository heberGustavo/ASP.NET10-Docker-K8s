using ASP.NET10_Docker_K8s.Model.Base;
using ASP.NET10_Docker_K8s.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET10_Docker_K8s.Repositories.Implementation
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MSSQLContext _context;
        private DbSet<T> _dataset;

        public GenericRepository(MSSQLContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T FindById(long id)
        {
            return _dataset.Find(id);
        }

        public T Create(T item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public T Update(T item)
        {
            var itemFound = FindById(item.Id);
            if (itemFound == null) return null;

            _context.Entry(itemFound).CurrentValues.SetValues(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(long id)
        {
            var itemFound = FindById(id);
            if (itemFound == null) return;

            _context.Remove(itemFound);
            _context.SaveChanges();
            return;
        }

        public bool Exists(long id)
        {
            return _dataset.Any(x => x.Id == id);
        }

    }
}
