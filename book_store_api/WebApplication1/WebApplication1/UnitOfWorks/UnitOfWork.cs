using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.UnitOfWorks;

public class UnitOfWork(BookStoreContext db)
{
    private GenericRepository<Book>? _bookRepo;
    private GenericRepository<Order>? _orderRepo;
    private GenericRepository<OrderDetails>? _orderDetailsRepo;
    private GenericRepository<Author>? _authorRepo;
    private GenericRepository<Customer>? _customerRepo;
    private GenericRepository<Catalog>? _catalogRepo;

    public GenericRepository<Book> BookRepo
    {
        get { return _bookRepo ??= new GenericRepository<Book>(db); }
    }

    public GenericRepository<Order> OrderRepo
    {
        get
        {
            if (_orderRepo == null)
            {
                _orderRepo = new GenericRepository<Order>(db);
            }

            return _orderRepo;
        }
    }

    public GenericRepository<OrderDetails> OrderDetailsRepo
    {
        get
        {
            if (_orderDetailsRepo == null)
            {
                _orderDetailsRepo = new GenericRepository<OrderDetails>(db);
            }

            return _orderDetailsRepo;
        }
    }

    public GenericRepository<Author> AuthorRepo
    {
        get
        {
            if (_authorRepo == null)
            {
                _authorRepo = new GenericRepository<Author>(db);
            }

            return _authorRepo;
        }
    }

    public GenericRepository<Customer> CustomerRepo
    {
        get
        {
            if (_customerRepo == null)
            {
                _customerRepo = new GenericRepository<Customer>(db);
            }

            return _customerRepo;
        }
    }

    public GenericRepository<Catalog> CatalogRepo
    {
        get
        {
            if (_catalogRepo == null)
            {
                _catalogRepo = new GenericRepository<Catalog>(db);
            }

            return _catalogRepo;
        }
    }

    public void Save()
    {
        db.SaveChanges();
    }
}
