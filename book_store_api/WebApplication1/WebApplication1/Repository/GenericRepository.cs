using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repository;

public class GenericRepository<TEntity>(BookStoreContext db)
    where TEntity : class
{
    public List<TEntity> GetAll()
    {
        return db.Set<TEntity>().ToList();
    }

    public TEntity? GetById(int id)
    {
        return db.Set<TEntity>().Find(id);
    }

    public void Insert(TEntity entity)
    {
        db.Set<TEntity>().Add(entity);
    }
    
    public void Update(TEntity entity)
    {
        db.Entry(entity).State = EntityState.Modified;
    }

    public bool Delete(int id)
    {
        var entity = GetById(id);
        if (entity == null)
        {
            return false;
        }
        db.Set<TEntity>().Remove(entity);
        return true;
    }
}